/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.Collections;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// Converts an edited <see cref="ReflectedObjectProxy"/> tree back into a real, immutable
/// instance of its target type by invoking that type's single constructor. Untouched
/// (Type.Missing-sentineled) parameters are passed through as Type.Missing so the
/// constructor's own default value applies — Activator.CreateInstance(type) cannot be used
/// here because these vendor record types have no true parameterless constructor overload.
/// This class is fully generic: it never references a specific command or payload type.
/// </summary>
public static class ObjectProxyBuilder
{
    public static object Build(Type targetType, ReflectedObjectProxy proxy)
    {
        var parameters = proxy.Constructor.GetParameters();
        var args = new object[parameters.Length];

        for (int i = 0; i < parameters.Length; i++)
        {
            var raw = proxy.GetRaw(parameters[i].Name!);
            args[i] = raw switch
            {
                ReflectedObjectProxy nested => Build(nested.TargetType, nested),
                ProxyList items => BuildList(items),
                ProxyDictionary entries => BuildDictionary(entries),
                _ => raw,
            };
        }

        var instance = proxy.Constructor.Invoke(args);

        // ExtendedProperties (see ParameterShape.TryGetExtendedPropertiesProperty) isn't one of
        // the constructor's own parameters, so it's assigned separately, after construction,
        // straight onto the built instance's setter.
        if (proxy.ExtendedPropertiesProperty is { } extendedProperties)
        {
            var raw = proxy.GetRaw(extendedProperties.Name);
            if (!ReferenceEquals(raw, Type.Missing))
            {
                extendedProperties.SetValue(instance, raw is ProxyDictionary entries ? BuildDictionary(entries) : raw);
            }
        }

        return instance;
    }

    private static object BuildList(ProxyList items)
    {
        var listType = typeof(System.Collections.Generic.List<>).MakeGenericType(items.ItemType);
        var list = (IList)Activator.CreateInstance(listType)!;
        foreach (var item in items)
        {
            list.Add(Build(item.TargetType, item));
        }

        return list;
    }

    private static object BuildDictionary(ProxyDictionary entries)
    {
        var dictionaryType = typeof(System.Collections.Generic.Dictionary<,>).MakeGenericType(typeof(string), entries.ValueType);
        var dictionary = (IDictionary)Activator.CreateInstance(dictionaryType)!;
        foreach (var (key, value) in entries)
        {
            dictionary.Add(key, Build(value.TargetType, value));
        }

        return dictionary;
    }

    /// <summary>
    /// The inverse of <see cref="Build"/>: reflects over a real instance (e.g. one produced by
    /// deserializing a JSON file, see <see cref="JsonFileLoaderEditor"/>) and rebuilds an
    /// editable <see cref="ReflectedObjectProxy"/> tree matching it, so it can be loaded into
    /// the PropertyGrid and still edited further afterward. Properties left null on the source
    /// instance are left unset (Type.Missing) on the proxy, same as a freshly created one.
    /// </summary>
    public static ReflectedObjectProxy Wrap(object instance, Type targetType)
    {
        var proxy = new ReflectedObjectProxy(targetType);
        if (instance is null)
        {
            return proxy;
        }

        foreach (var parameter in proxy.Constructor.GetParameters())
        {
            var property = targetType.GetProperty(parameter.Name!);
            var value = property?.GetValue(instance);
            if (value is null)
            {
                continue;
            }

            var parameterType = parameter.ParameterType;
            if (ParameterShape.IsComplexSingle(parameterType))
            {
                proxy.SetRaw(parameter.Name!, Wrap(value, parameterType));
            }
            else if (ParameterShape.IsComplexList(parameterType, out var itemType) && value is IEnumerable items)
            {
                var list = new ProxyList(itemType);
                foreach (var item in items)
                {
                    list.Add(Wrap(item, itemType));
                }

                proxy.SetRaw(parameter.Name!, list);
            }
            else if (ParameterShape.IsComplexDictionary(parameterType, out var valueType) && value is IDictionary sourceDictionary)
            {
                var dictionary = new ProxyDictionary(valueType);
                foreach (DictionaryEntry entry in sourceDictionary)
                {
                    dictionary[(string)entry.Key] = Wrap(entry.Value, valueType);
                }

                proxy.SetRaw(parameter.Name!, dictionary);
            }
            else
            {
                proxy.SetRaw(parameter.Name!, value);
            }
        }

        SeedExtendedProperties(proxy, instance, Wrap);
        return proxy;
    }

    /// <summary>
    /// Populates <paramref name="proxy"/>'s <see cref="ReflectedObjectProxy.ExtendedPropertiesProperty"/>
    /// slot (if <see cref="ParameterShape.TryGetExtendedPropertiesProperty"/> found one) from the
    /// identically-named property on <paramref name="source"/>, shared by <see cref="Wrap"/> and
    /// <see cref="WrapMatching"/> — the only difference between them is which recursive wrapper
    /// (<paramref name="wrapValue"/>) nested complex entries go through.
    /// </summary>
    private static void SeedExtendedProperties(ReflectedObjectProxy proxy, object source, Func<object, Type, ReflectedObjectProxy> wrapValue)
    {
        if (proxy.ExtendedPropertiesProperty is not { } extendedProperties ||
            source?.GetType().GetProperty(extendedProperties.Name)?.GetValue(source) is not IDictionary sourceDictionary ||
            sourceDictionary.Count == 0)
        {
            return;
        }

        if (ParameterShape.IsComplexDictionary(extendedProperties.PropertyType, out var valueType))
        {
            var dictionary = new ProxyDictionary(valueType);
            foreach (DictionaryEntry entry in sourceDictionary)
            {
                dictionary[(string)entry.Key] = wrapValue(entry.Value, valueType);
            }

            proxy.SetRaw(extendedProperties.Name, dictionary);
        }
        else
        {
            // Simple-valued (e.g. Dictionary<string, bool>): no per-entry wrapping needed, the
            // real dictionary instance is exactly what JsonFallbackConverter's ConvertTo expects.
            proxy.SetRaw(extendedProperties.Name, sourceDictionary);
        }
    }

    /// <summary>
    /// Seeds a new <see cref="ReflectedObjectProxy"/> of <paramref name="targetType"/> from a
    /// differently-shaped source instance, matching fields by name at every nesting level
    /// instead of assuming identical CLR types — e.g. defaulting Storage.SetStorage's
    /// SetStorageUnitClass entries from Storage.GetStorage's StorageUnitClass results, where the
    /// "Set" side of an XFS4IoT command pair mirrors the "Get" side's structure closely (it
    /// omits read-only fields) but is still a distinct generated type. A field present on the
    /// target but missing, null, or of an incompatible runtime type on the source is left unset
    /// (Type.Missing) rather than failing the whole seed — this is a best-effort default, not a
    /// strict conversion.
    /// </summary>
    public static ReflectedObjectProxy WrapMatching(object source, Type targetType)
    {
        var proxy = new ReflectedObjectProxy(targetType) { Reference = source };
        if (source is null)
        {
            return proxy;
        }

        var sourceType = source.GetType();
        foreach (var parameter in proxy.Constructor.GetParameters())
        {
            var value = sourceType.GetProperty(parameter.Name!)?.GetValue(source);
            if (value is null)
            {
                continue;
            }

            var parameterType = parameter.ParameterType;
            if (ParameterShape.IsComplexSingle(parameterType))
            {
                proxy.SetRaw(parameter.Name!, WrapMatching(value, parameterType));
            }
            else if (ParameterShape.IsComplexList(parameterType, out var itemType) && value is IEnumerable items)
            {
                var list = new ProxyList(itemType);
                foreach (var item in items)
                {
                    list.Add(WrapMatching(item, itemType));
                }

                proxy.SetRaw(parameter.Name!, list);
            }
            else if (ParameterShape.IsComplexDictionary(parameterType, out var valueType) && value is IDictionary sourceDictionary)
            {
                var dictionary = new ProxyDictionary(valueType);
                foreach (DictionaryEntry entry in sourceDictionary)
                {
                    dictionary[(string)entry.Key] = WrapMatching(entry.Value, valueType);
                }

                proxy.SetRaw(parameter.Name!, dictionary);
            }
            else if (parameterType.IsInstanceOfType(value))
            {
                proxy.SetRaw(parameter.Name!, value);
            }
        }

        SeedExtendedProperties(proxy, source, WrapMatching);
        return proxy;
    }
}

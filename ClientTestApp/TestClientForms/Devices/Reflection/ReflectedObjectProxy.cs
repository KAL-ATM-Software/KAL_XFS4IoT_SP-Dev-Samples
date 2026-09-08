/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace XFS4IoT.TestTool.Devices.Reflection;

/// <summary>
/// A mutable, PropertyGrid-friendly stand-in for an immutable XFS4IoT PayloadData record (or
/// any nested class within it). Every constructor parameter of the wrapped type becomes one
/// editable property; nested complex parameters and lists of complex items are themselves
/// wrapped recursively so PropertyGrid can expand arbitrarily deep structures without any
/// per-command code. Use <see cref="Reflection.ObjectProxyBuilder"/> to convert an edited
/// proxy back into a real instance of <see cref="TargetType"/> before sending it.
/// </summary>
public sealed class ReflectedObjectProxy : ICustomTypeDescriptor
{
    public ReflectedObjectProxy(Type targetType)
    {
        TargetType = targetType;
        Constructor = targetType.GetConstructors().Single();
        foreach (var parameter in Constructor.GetParameters())
        {
            _values[parameter.Name!] = Type.Missing;
        }

        if (ParameterShape.TryGetExtendedPropertiesProperty(targetType, out var extendedProperties))
        {
            ExtendedPropertiesProperty = extendedProperties;
            _values[extendedProperties.Name] = Type.Missing;
        }
    }

    public Type TargetType { get; }

    public ConstructorInfo Constructor { get; }

    /// <summary>
    /// Set when <see cref="TargetType"/> has an open-ended <c>ExtendedProperties</c> dictionary
    /// (see <see cref="ParameterShape.TryGetExtendedPropertiesProperty"/>) — e.g. Cash's per-type
    /// counts, keyed by banknote type name. <see cref="GetProperties"/> synthesizes an editable
    /// row for it exactly like a constructor parameter, and
    /// <see cref="Reflection.ObjectProxyBuilder.Build"/> assigns it onto the built instance
    /// afterward, since it isn't one of the constructor's own parameters.
    /// </summary>
    internal PropertyInfo ExtendedPropertiesProperty { get; }

    /// <summary>
    /// An optional same-position instance of a differently-shaped, richer sibling type (e.g. a
    /// Storage.SetStorage <c>SetStorageUnitClass</c> proxy's counterpart
    /// Storage.GetStorage <c>StorageUnitClass</c> result), set by
    /// <see cref="Reflection.ObjectProxyBuilder.WrapMatching"/>. Its properties that have no
    /// settable counterpart on this proxy's own <see cref="TargetType"/> (e.g. the read-only
    /// <c>capabilities</c>, or unit fields like <c>positionName</c> that "Set" commands never
    /// accept) are surfaced by <see cref="GetProperties"/> as extra, read-only rows — for
    /// reference while filling in the editable ones, never sent back when the command is built.
    /// </summary>
    public object Reference { get; set; }

    private readonly Dictionary<string, object> _values = new();

    internal object GetRaw(string name) => _values[name];

    internal void SetRaw(string name, object value) => _values[name] = value;

    internal bool IsSet(string name) => !ReferenceEquals(_values[name], Type.Missing);

    public PropertyDescriptorCollection GetProperties()
    {
        var descriptors = Constructor.GetParameters()
            .Select(p => (PropertyDescriptor)new ReflectedPropertyDescriptor(this, p))
            .ToList();

        if (ExtendedPropertiesProperty is not null)
        {
            descriptors.Add(new ReflectedPropertyDescriptor(this, ExtendedPropertiesProperty));
        }

        if (Reference is not null)
        {
            // "ExtensionData" is the raw JsonElement backing store behind ExtendedProperties
            // (see ParameterShape.TryGetExtendedPropertiesProperty) — plumbing, not information,
            // so it's never worth a reference row even when this proxy has no editable
            // counterpart for it.
            var settableNames = new HashSet<string>(descriptors.Select(d => d.Name), StringComparer.OrdinalIgnoreCase) { "ExtensionData" };
            descriptors.AddRange(Reference.GetType().GetProperties()
                .Where(p => !settableNames.Contains(p.Name))
                .Select(p => (PropertyDescriptor)new ReadOnlyPropertyDescriptor(Reference, p)));
        }

        return new PropertyDescriptorCollection(descriptors.ToArray());
    }

    AttributeCollection ICustomTypeDescriptor.GetAttributes() => AttributeCollection.Empty;
    string ICustomTypeDescriptor.GetClassName() => TargetType.Name;
    string ICustomTypeDescriptor.GetComponentName() => null;
    TypeConverter ICustomTypeDescriptor.GetConverter() => new();
    EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() => null;
    PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() => null;
    object ICustomTypeDescriptor.GetEditor(Type editorBaseType) => null;
    EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => EventDescriptorCollection.Empty;
    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes) => EventDescriptorCollection.Empty;
    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes) => GetProperties();
    object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd) => this;

    /// <summary>
    /// PropertyGrid's value column renders a nested complex property by converting it to a
    /// string (via <see cref="ExpandableObjectConverter"/>'s inherited <see cref="TypeConverter.ConvertTo"/>,
    /// which falls back to <see cref="object.ToString"/>). Without this override that column
    /// would show the CLR type name instead of being blank.
    /// </summary>
    public override string ToString() => string.Empty;
}

/// <summary>
/// A <see cref="List{ReflectedObjectProxy}"/> that additionally remembers the real CLR item
/// type it was created for (e.g. AidDataClass), since that information would otherwise be lost
/// once every item is wrapped in a type-erased <see cref="ReflectedObjectProxy"/>.
/// </summary>
public sealed class ProxyList : List<ReflectedObjectProxy>
{
    public ProxyList(Type itemType)
    {
        ItemType = itemType;
    }

    public Type ItemType { get; }

    /// <inheritdoc cref="ReflectedObjectProxy.ToString"/>
    public override string ToString() => string.Empty;
}

/// <summary>
/// A <see cref="Dictionary{String, ReflectedObjectProxy}"/> that additionally remembers the
/// real CLR value type it was created for (e.g. SetStorageUnitClass), mirroring
/// <see cref="ProxyList"/> for the string-keyed-dictionary payload shape (e.g.
/// Storage.SetStorage's Storage parameter, a Dictionary&lt;string, SetStorageUnitClass&gt;).
/// </summary>
public sealed class ProxyDictionary : Dictionary<string, ReflectedObjectProxy>
{
    public ProxyDictionary(Type valueType)
    {
        ValueType = valueType;
    }

    public Type ValueType { get; }

    /// <inheritdoc cref="ReflectedObjectProxy.ToString"/>
    public override string ToString() => string.Empty;
}

/// <summary>
/// Classifies a constructor parameter's type into one of the shapes <see cref="ReflectedObjectProxy"/>
/// knows how to render/edit.
/// </summary>
internal static class ParameterShape
{
    public static bool IsSimple(Type type)
    {
        var underlying = Nullable.GetUnderlyingType(type) ?? type;
        return underlying.IsPrimitive || underlying.IsEnum || underlying == typeof(string) || underlying == typeof(decimal);
    }

    public static bool IsByteList(Type type) => type == typeof(List<byte>);

    public static bool IsComplexList(Type type, out Type itemType)
    {
        itemType = null;
        if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(List<>))
        {
            return false;
        }

        var candidate = type.GetGenericArguments()[0];
        if (IsSimple(candidate))
        {
            return false;
        }

        itemType = candidate;
        return true;
    }

    /// <summary>
    /// Detects a string-keyed dictionary of complex values (e.g. Storage.SetStorage's
    /// Dictionary&lt;string, SetStorageUnitClass&gt; Storage parameter). Dictionary&lt;,&gt;
    /// doesn't implement IList, so WinForms' stock CollectionEditor — the fallback a
    /// PropertyGrid reaches for automatically when no shape below matches — can't add or
    /// remove entries against it (its "Add" button stays permanently disabled); this shape
    /// gets its own editor instead. Non-string keys or simple values fall through to the
    /// generic JSON fallback below.
    /// </summary>
    public static bool IsComplexDictionary(Type type, out Type valueType)
    {
        valueType = null;
        if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Dictionary<,>))
        {
            return false;
        }

        var genericArgs = type.GetGenericArguments();
        if (genericArgs[0] != typeof(string) || IsSimple(genericArgs[1]))
        {
            return false;
        }

        valueType = genericArgs[1];
        return true;
    }

    public static bool IsComplexSingle(Type type)
    {
        if (IsSimple(type) || IsByteList(type))
        {
            return false;
        }

        if (typeof(System.Collections.IEnumerable).IsAssignableFrom(type) && type != typeof(string))
        {
            return false;
        }

        return type.IsClass && type.GetConstructors().Length > 0;
    }

    /// <summary>
    /// Detects the vendor codegen's open-ended-keys convention: a settable
    /// <c>Dictionary&lt;string, T&gt; ExtendedProperties</c> property backed by a
    /// <c>[JsonExtensionData]</c> field, used wherever XFS4IoT allows arbitrary keys that can't
    /// be fixed constructor parameters (e.g. per-banknote-type counts, keyed by type name such as
    /// <c>typeEUR10</c>). Unlike every other shape here this isn't a constructor parameter at
    /// all — it's a regular mutable property alongside the type's constructor — so it needs its
    /// own detection and its own post-construction assignment in
    /// <see cref="Reflection.ObjectProxyBuilder.Build"/>.
    /// </summary>
    public static bool TryGetExtendedPropertiesProperty(Type targetType, out PropertyInfo property)
    {
        property = targetType.GetProperty("ExtendedProperties");
        if (property is null || !property.CanRead || !property.CanWrite)
        {
            property = null;
            return false;
        }

        var type = property.PropertyType;
        if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(Dictionary<,>) || type.GetGenericArguments()[0] != typeof(string))
        {
            property = null;
            return false;
        }

        return true;
    }
}

/// <summary>
/// A last-resort <see cref="TypeConverter"/> for parameter shapes that aren't one of the
/// polished cases above (e.g. Dictionary-typed payload fields such as PrintForm's Fields
/// parameter) — edited as a single JSON text value rather than left unsupported.
/// </summary>
internal sealed class JsonFallbackConverter : TypeConverter
{
    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        => sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);

    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        => destinationType == typeof(string) || base.CanConvertTo(context, destinationType);

    public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
    {
        if (value is string text && context?.PropertyDescriptor is not null)
        {
            return string.IsNullOrWhiteSpace(text)
                ? null
                : JsonSerializer.Deserialize(text, context.PropertyDescriptor.PropertyType);
        }

        return base.ConvertFrom(context, culture, value);
    }

    public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
        if (destinationType == typeof(string))
        {
            return value is null ? string.Empty : JsonSerializer.Serialize(value);
        }

        return base.ConvertTo(context, culture, value, destinationType);
    }
}

/// <summary>
/// A <see cref="PropertyDescriptor"/> synthesized from a single constructor parameter of a
/// <see cref="ReflectedObjectProxy"/>'s target type.
/// </summary>
internal sealed class ReflectedPropertyDescriptor : PropertyDescriptor
{
    public ReflectedPropertyDescriptor(ReflectedObjectProxy owner, ParameterInfo parameter)
        : base(parameter.Name!, BuildAttributes(parameter.ParameterType, GetParameterDescription(parameter)))
    {
        _owner = owner;
        _name = parameter.Name!;
        _type = parameter.ParameterType;
    }

    /// <summary>
    /// Backs the one property (per <see cref="ReflectedObjectProxy.ExtendedPropertiesProperty"/>)
    /// that isn't a constructor parameter at all — see
    /// <see cref="ParameterShape.TryGetExtendedPropertiesProperty"/>. Otherwise identical to the
    /// constructor-parameter case: same owner-keyed storage, same shape-based rendering.
    /// </summary>
    public ReflectedPropertyDescriptor(ReflectedObjectProxy owner, PropertyInfo property)
        : base(property.Name, BuildAttributes(property.PropertyType, XmlDocComments.GetSummary(property)))
    {
        _owner = owner;
        _name = property.Name;
        _type = property.PropertyType;
    }

    private readonly ReflectedObjectProxy _owner;
    private readonly string _name;
    private readonly Type _type;

    public override Type ComponentType => _owner.TargetType;
    public override bool IsReadOnly => false;

    public override Type PropertyType
    {
        get
        {
            var type = _type;
            if (ParameterShape.IsComplexSingle(type))
            {
                return typeof(ReflectedObjectProxy);
            }

            if (ParameterShape.IsComplexList(type, out _))
            {
                return typeof(ProxyList);
            }

            if (ParameterShape.IsComplexDictionary(type, out _))
            {
                return typeof(ProxyDictionary);
            }

            return type;
        }
    }

    public override bool CanResetValue(object component) => _owner.IsSet(_name);

    public override void ResetValue(object component) => _owner.SetRaw(_name, Type.Missing);

    public override bool ShouldSerializeValue(object component) => _owner.IsSet(_name);

    public override object GetValue(object component)
    {
        var name = _name;
        var type = _type;
        var raw = _owner.GetRaw(name);

        if (ParameterShape.IsComplexSingle(type))
        {
            if (ReferenceEquals(raw, Type.Missing))
            {
                raw = new ReflectedObjectProxy(type);
                _owner.SetRaw(name, raw);
            }

            return raw;
        }

        if (ParameterShape.IsComplexList(type, out var itemType))
        {
            if (ReferenceEquals(raw, Type.Missing))
            {
                raw = new ProxyList(itemType);
                _owner.SetRaw(name, raw);
            }

            return raw;
        }

        if (ParameterShape.IsComplexDictionary(type, out var valueType))
        {
            if (ReferenceEquals(raw, Type.Missing))
            {
                raw = new ProxyDictionary(valueType);
                _owner.SetRaw(name, raw);
            }

            return raw;
        }

        if (!ReferenceEquals(raw, Type.Missing))
        {
            return raw;
        }

        if (type == typeof(List<byte>))
        {
            return new List<byte>();
        }

        if (type.IsValueType && Nullable.GetUnderlyingType(type) is null)
        {
            return Activator.CreateInstance(type);
        }

        return null;
    }

    public override void SetValue(object component, object value)
    {
        _owner.SetRaw(_name, value);
        OnValueChanged(component, EventArgs.Empty);
    }

    /// <summary>
    /// Every property is grouped under a single "Properties" category — otherwise PropertyGrid
    /// falls back to its default "Misc" category label, since none of these dynamically
    /// synthesized properties would otherwise carry a [Category] attribute.
    /// </summary>
    private static readonly CategoryAttribute PropertiesCategory = new("Properties");

    /// <summary>
    /// Surface the vendor assembly's own XML doc &lt;summary&gt; for this constructor parameter
    /// (e.g. "Track 1 of the magnetic stripe will be read.") in the PropertyGrid's description
    /// pane, when the referenced package ships a .xml doc file next to its .dll (it does).
    /// A ParameterInfo carries no XML doc of its own, so it's looked up via the identically-named
    /// property the vendor's codegen always declares alongside the constructor.
    /// </summary>
    private static string GetParameterDescription(ParameterInfo parameter)
    {
        var declaringProperty = parameter.Member.DeclaringType?.GetProperty(parameter.Name!);
        return declaringProperty is not null ? XmlDocComments.GetSummary(declaringProperty) : null;
    }

    private static Attribute[] BuildAttributes(Type type, string description)
    {
        var attributes = new List<Attribute> { PropertiesCategory };

        if (description is not null)
        {
            attributes.Add(new DescriptionAttribute(description));
        }

        if (ParameterShape.IsByteList(type))
        {
            attributes.Add(new TypeConverterAttribute(typeof(HexByteListConverter)));
        }
        else if (ParameterShape.IsComplexList(type, out _))
        {
            attributes.Add(new EditorAttribute(typeof(ComplexListEditor), typeof(System.Drawing.Design.UITypeEditor)));
        }
        else if (ParameterShape.IsComplexDictionary(type, out _))
        {
            attributes.Add(new EditorAttribute(typeof(ComplexDictionaryEditor), typeof(System.Drawing.Design.UITypeEditor)));
        }
        else if (ParameterShape.IsComplexSingle(type))
        {
            attributes.Add(new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
            attributes.Add(new EditorAttribute(typeof(JsonFileLoaderEditor), typeof(System.Drawing.Design.UITypeEditor)));
        }
        else if (!ParameterShape.IsSimple(type) && Nullable.GetUnderlyingType(type) is null)
        {
            // Uncommon shapes (e.g. Dictionary<string, List<string>> in PrintFormCommand.Fields):
            // fall back to plain JSON text editing rather than leaving the field unsupported.
            attributes.Add(new TypeConverterAttribute(typeof(JsonFallbackConverter)));
        }

        return attributes.ToArray();
    }
}

/// <summary>
/// A read-only, reflection-driven <see cref="ICustomTypeDescriptor"/> view over a real
/// instance's public properties, wrapping complex property values recursively so PropertyGrid
/// can expand them. Backs the extra "Reference (read-only)" rows that
/// <see cref="ReflectedObjectProxy.GetProperties"/> adds from <see cref="ReflectedObjectProxy.Reference"/>
/// — informational display only, never converted back into a real instance.
/// </summary>
internal sealed class ReadOnlyObjectView : ICustomTypeDescriptor
{
    private ReadOnlyObjectView(object instance)
    {
        _instance = instance;
    }

    private readonly object _instance;

    /// <summary>
    /// Wraps <paramref name="value"/> for read-only display: primitives/enums/strings pass
    /// through as-is (PropertyGrid already renders those), a list of simple items is joined into
    /// one comma-separated string, and anything else (a list of complex items, a dictionary, or a
    /// complex object) is wrapped so it renders as an expandable read-only node.
    /// </summary>
    public static object Wrap(object value)
    {
        if (value is null)
        {
            return null;
        }

        var type = value.GetType();
        if (ParameterShape.IsSimple(type) || ParameterShape.IsByteList(type))
        {
            return value;
        }

        if (value is System.Collections.IEnumerable enumerable && type != typeof(string))
        {
            var items = enumerable.Cast<object>().ToList();
            if (items.Count == 0)
            {
                return string.Empty;
            }

            if (items[0] is not null && ParameterShape.IsSimple(items[0].GetType()))
            {
                return string.Join(", ", items);
            }

            return JsonSerializer.Serialize(value);
        }

        return new ReadOnlyObjectView(value);
    }

    public PropertyDescriptorCollection GetProperties()
    {
        var descriptors = _instance.GetType().GetProperties()
            .Where(p => p.GetIndexParameters().Length == 0)
            .Select(p => (PropertyDescriptor)new ReadOnlyPropertyDescriptor(_instance, p))
            .ToArray();
        return new PropertyDescriptorCollection(descriptors);
    }

    AttributeCollection ICustomTypeDescriptor.GetAttributes() => AttributeCollection.Empty;
    string ICustomTypeDescriptor.GetClassName() => _instance.GetType().Name;
    string ICustomTypeDescriptor.GetComponentName() => null;
    TypeConverter ICustomTypeDescriptor.GetConverter() => new ExpandableObjectConverter();
    EventDescriptor ICustomTypeDescriptor.GetDefaultEvent() => null;
    PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty() => null;
    object ICustomTypeDescriptor.GetEditor(Type editorBaseType) => null;
    EventDescriptorCollection ICustomTypeDescriptor.GetEvents() => EventDescriptorCollection.Empty;
    EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes) => EventDescriptorCollection.Empty;
    PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes) => GetProperties();
    object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd) => this;

    /// <inheritdoc cref="ReflectedObjectProxy.ToString"/>
    public override string ToString() => string.Empty;
}

/// <summary>
/// A <see cref="PropertyDescriptor"/> for one property of a <see cref="ReflectedObjectProxy.Reference"/>
/// instance (or of a value nested within one, via <see cref="ReadOnlyObjectView"/>). Always
/// read-only: these rows exist purely so the operator can see what the connected service last
/// reported (e.g. capabilities, or status fields a "Set" command can't change) without it being
/// mistaken for something editable or sent back to the service.
/// </summary>
internal sealed class ReadOnlyPropertyDescriptor : PropertyDescriptor
{
    public ReadOnlyPropertyDescriptor(object owner, PropertyInfo property)
        : base(property.Name, BuildAttributes(owner, property))
    {
        _owner = owner;
        _property = property;
    }

    private readonly object _owner;
    private readonly PropertyInfo _property;

    public override Type ComponentType => _owner.GetType();
    public override Type PropertyType => typeof(object);
    public override bool IsReadOnly => true;
    public override bool CanResetValue(object component) => false;
    public override void ResetValue(object component) { }
    public override bool ShouldSerializeValue(object component) => false;
    public override object GetValue(object component) => ReadOnlyObjectView.Wrap(_property.GetValue(_owner));
    public override void SetValue(object component, object value) { }

    private static readonly CategoryAttribute ReferenceCategory = new("Reference (read-only)");

    private static Attribute[] BuildAttributes(object owner, PropertyInfo property)
    {
        var attributes = new List<Attribute> { ReferenceCategory };

        var description = XmlDocComments.GetSummary(property);
        if (description is not null)
        {
            attributes.Add(new DescriptionAttribute(description));
        }

        if (ReadOnlyObjectView.Wrap(property.GetValue(owner)) is ReadOnlyObjectView)
        {
            attributes.Add(new TypeConverterAttribute(typeof(ExpandableObjectConverter)));
        }

        return attributes.ToArray();
    }
}

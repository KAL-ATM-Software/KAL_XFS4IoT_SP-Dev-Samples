using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XFS4IoT;
using XFS4IoT.Completions;
using XFS4IoTFramework.Biometric;
using XFS4IoTFramework.Common;
using XFS4IoTServer;

namespace KAL.XFS4IoTSP.Biometric.Sample
{
    public class BiometricSample : IBiometricDevice, ICommonDevice
    {
        public BiometricSample(ILogger logger)
        {
            _logger = logger;

            BiometricStatus = new(BiometricStatusClass.SubjectStatusEnum.NotPresent,
                                  false,
                                  BiometricCapabilitiesClass.PersistenceModesEnum.Persist,
                                  1024 * 1024);

            CommonStatus = new(CommonStatusClass.DeviceEnum.Online,
                               CommonStatusClass.PositionStatusEnum.InPosition,
                               0,
                               CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                               CommonStatusClass.ExchangeEnum.NotSupported,
                               CommonStatusClass.EndToEndSecurityEnum.NotSupported);
        }

        private readonly ILogger _logger;

        // Biometric Sample to use within the Sample project.
        private readonly List<byte> SampleData = Enumerable.Range(0, 255).Select(c => (byte)c).ToList();
        private List<byte> LastScannedData = null;

        public Dictionary<string, BiometricDataType> StorageInfo { get => internalTemplates.ToDictionary(c => c.Key, c => c.Value.DataType); }
        private Dictionary<string, BiometricData> internalTemplates { get; set; } = new();
        private int internalTemplateId = 0;

        public BiometricStatusClass BiometricStatus { get; set; }

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; }

        private IBiometricService BiometricService => SetServiceProvider.IsA<IBiometricService>();

        public CommonStatusClass CommonStatus { get; set; }

        public CommonCapabilitiesClass CommonCapabilities { get; set; } = new CommonCapabilitiesClass(
                CommonInterface: new CommonCapabilitiesClass.CommonInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    }
                ),
                BiometricInterface: new CommonCapabilitiesClass.BiometricInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Clear,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.GetStorageInfo,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Import,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Match,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Read,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.SetDataPersistence
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.PresentSubjectEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.SubjectDetectedEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.RemoveSubjectEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.SubjectRemovedEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.DataClearedEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.OrientationEvent
                    }
                ),
                DeviceInformation: new List<CommonCapabilitiesClass.DeviceInformationClass>()
                {
                    new CommonCapabilitiesClass.DeviceInformationClass(
                            ModelName: "Simulator",
                            SerialNumber: "123456-78900001",
                            RevisionNumber: "1.0",
                            ModelDescription: "KAL simualtor",
                            Firmware: new List<CommonCapabilitiesClass.FirmwareClass>()
                            {
                                new CommonCapabilitiesClass.FirmwareClass(
                                        FirmwareName: "XFS4 SP",
                                        FirmwareVersion: "1.0",
                                        HardwareRevision: "1.0")
                            },
                            Software: new List<CommonCapabilitiesClass.SoftwareClass>()
                            {
                                new CommonCapabilitiesClass.SoftwareClass(
                                        SoftwareName: "XFS4 SP",
                                        SoftwareVersion: "1.0")
                            })
                },
                PowerSaveControl: false,
                AntiFraudModule: false);

        public BiometricCapabilitiesClass BiometricCapabilities { get; set; } = new BiometricCapabilitiesClass(
                BiometricCapabilitiesClass.DeviceTypeEnum.FingerVein,
                1,
                1024*1024,
                BiometricCapabilitiesClass.FormatEnum.ReservedTemplate1,
                BiometricCapabilitiesClass.AlgorithmEnum.None,
                BiometricCapabilitiesClass.StorageEnum.Clear,
                BiometricCapabilitiesClass.PersistenceModesEnum.Clear | BiometricCapabilitiesClass.PersistenceModesEnum.Persist,
                BiometricCapabilitiesClass.MatchModesEnum.CombinedMatch | BiometricCapabilitiesClass.MatchModesEnum.StoredMatch,
                BiometricCapabilitiesClass.ScanModesEnum.Match | BiometricCapabilitiesClass.ScanModesEnum.Scan,
                BiometricCapabilitiesClass.CompareModesEnum.Verify,
                BiometricCapabilitiesClass.ClearModesEnum.ImportedData | BiometricCapabilitiesClass.ClearModesEnum.ScannedData);

        public Task<DeviceResult> ClearAsync(ClearDataRequest ClearMode, CancellationToken cancellation)
        {
            if(ClearMode.ClearData.HasFlag(BiometricCapabilitiesClass.ClearModesEnum.ImportedData))
                internalTemplates.Clear();

            if (ClearMode.ClearData.HasFlag(BiometricCapabilitiesClass.ClearModesEnum.ScannedData))
            {
                LastScannedData = null;
                BiometricStatus.Capture = false;
            }

            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        public Task<ImportResult> ImportAsync(ImportRequest request, CancellationToken cancellation)
        {
            Dictionary<string, BiometricDataType> templatesImported = new();
            foreach (var item in request.Data)
            {
                var id = "id" + internalTemplateId++;
                templatesImported.Add(id, item.DataType);
                internalTemplates.Add(id, item);
            }
            return Task.FromResult(new ImportResult(MessagePayload.CompletionCodeEnum.Success, templatesImported));
        }

        public Task<MatchResult> MatchAsync(MatchRequest request, CancellationToken cancellation)
        {
            if (LastScannedData is not { Count: > 0 })
                return Task.FromResult(new MatchResult(MessagePayload.CompletionCodeEnum.CommandErrorCode, "No Captured data available.", XFS4IoT.Biometric.Completions.MatchCompletion.PayloadData.ErrorCodeEnum.NoCaptureData));

            if (!internalTemplates.ContainsKey(request.Identifier))
                return Task.FromResult(new MatchResult(MessagePayload.CompletionCodeEnum.CommandErrorCode, "Invalid Identifier", XFS4IoT.Biometric.Completions.MatchCompletion.PayloadData.ErrorCodeEnum.NoImportedData));

            var template = internalTemplates[request.Identifier];
            bool matched = template.Data.Count == LastScannedData.Count;
            for (int i = 0; i < LastScannedData.Count && matched; i++)
                if (template.Data[i] != LastScannedData[i])
                    matched = false;

            return Task.FromResult(new MatchResult(MessagePayload.CompletionCodeEnum.Success,
                matched 
                ? new Dictionary<string, MatchCandidate>() { { request.Identifier, new MatchCandidate(100, LastScannedData) } }
                : null));
        }

        public async Task<ReadResult> ReadAsync(ReadRequest request, CancellationToken cancellation)
        {
            await BiometricService.PresentSubjectEvent();

            await Task.Delay(1000, cancellation);

            BiometricStatus.Subject = BiometricStatusClass.SubjectStatusEnum.Present;
            await BiometricService.SubjectDetectedEvent();

            await Task.Delay(1000, cancellation);

            await BiometricService.RemoveSubjectEvent();

            await Task.Delay(1000, cancellation);

            BiometricStatus.Subject = BiometricStatusClass.SubjectStatusEnum.NotPresent;
            await BiometricService.SubjectRemovedEvent();

            if (BiometricStatus.DataPersistence == BiometricCapabilitiesClass.PersistenceModesEnum.Persist)
            {
                LastScannedData = SampleData;
                BiometricStatus.Capture = true;
            }

            if (request.DataTypes is { Count: > 0 })
            return new ReadResult(MessagePayload.CompletionCodeEnum.Success, new List<BiometricData>() 
            { 
                new BiometricData(new BiometricDataType(BiometricCapabilitiesClass.FormatEnum.ReservedTemplate1), SampleData) 
            });

            return new ReadResult(MessagePayload.CompletionCodeEnum.Success, null);
        }

        public Task<DeviceResult> ResetDeviceAsync(ClearDataRequest ClearMode, CancellationToken cancellation)
        {
            if (ClearMode.ClearData.HasFlag(BiometricCapabilitiesClass.ClearModesEnum.ImportedData))
                internalTemplates.Clear();

            if (ClearMode.ClearData.HasFlag(BiometricCapabilitiesClass.ClearModesEnum.ScannedData))
            {
                LastScannedData = null;
                BiometricStatus.Capture = false;
            }

            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        public Task RunAsync()
        {
            return Task.CompletedTask;
        }

        public Task<DeviceResult> SetDataPersistenceAsync(BiometricCapabilitiesClass.PersistenceModesEnum Mode, CancellationToken cancellation)
        {
            BiometricStatus.DataPersistence = Mode;
            return Task.FromResult(new DeviceResult(MessagePayload.CompletionCodeEnum.Success));
        }

        public Task<SetMatchResult> SetMatchAsync(MatchRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        #region Common Device

        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request)
            => throw new NotSupportedException();

        public Task<DeviceResult> ClearCommandNonce()
            => throw new NotSupportedException();

        public Task<GetCommandNonceResult> GetCommandNonce()
            => throw new NotSupportedException();

        public Task<GetTransactionStateResult> GetTransactionState()
            => throw new NotSupportedException();

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel)
            => throw new NotSupportedException();

        #endregion
    }
}

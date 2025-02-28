/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
 * 
\***********************************************************************************************/

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
using XFS4IoTFramework.KeyManagement;
using XFS4IoTServer;

namespace Biometric.BiometricTemplate
{
    public class BiometricTemplate(ILogger logger) : IBiometricDevice, ICommonDevice, IKeyManagementDevice
    {
        private readonly ILogger _logger = logger;

        public Dictionary<string, BiometricDataType> StorageInfo { get => []; }

        public BiometricStatusClass BiometricStatus { get; set; } = new(
                BiometricStatusClass.SubjectStatusEnum.NotPresent,
                false,
                BiometricCapabilitiesClass.PersistenceModesEnum.Persist,
                1024 * 1024);

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; }

        public CommonStatusClass CommonStatus { get; set; } = new(
                CommonStatusClass.DeviceEnum.Online,
                CommonStatusClass.PositionStatusEnum.InPosition,
                0,
                CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                CommonStatusClass.ExchangeEnum.NotSupported,
                CommonStatusClass.EndToEndSecurityEnum.NotSupported);

        public CommonCapabilitiesClass CommonCapabilities { get; set; } = new CommonCapabilitiesClass(
                CommonInterface: new CommonCapabilitiesClass.CommonInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    ]
                ),
                BiometricInterface: new CommonCapabilitiesClass.BiometricInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Clear,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.GetStorageInfo,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Import,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Match,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Read,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.BiometricInterfaceClass.CommandEnum.SetDataPersistence
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.PresentSubjectEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.SubjectDetectedEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.RemoveSubjectEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.SubjectRemovedEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.DataClearedEvent,
                        CommonCapabilitiesClass.BiometricInterfaceClass.EventEnum.OrientationEvent
                    ]
                ),
                DeviceInformation:
                [
                    new(
                            ModelName: "ModelName",
                            SerialNumber: "SerialNumber",
                            RevisionNumber: "RevisionNumber",
                            ModelDescription: "ModelDescription",
                            Firmware:
                            [
                                new CommonCapabilitiesClass.FirmwareClass(
                                        FirmwareName: "XFS4 SP",
                                        FirmwareVersion: "1.0",
                                        HardwareRevision: "1.0")
                            ],
                            Software:
                            [
                                new(
                                        SoftwareName: "XFS4 SP",
                                        SoftwareVersion: "1.0")
                            ])
                ],
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
        public KeyManagementStatusClass KeyManagementStatus { get; set; } = new(
                KeyManagementStatusClass.EncryptionStateEnum.NotInitialized,
                KeyManagementStatusClass.CertificateStateEnum.NotSupported);
        public KeyManagementCapabilitiesClass KeyManagementCapabilities { get; set; } = 
            new KeyManagementCapabilitiesClass(
                5,
                KeyManagementCapabilitiesClass.KeyCheckModeEnum.NotSupported,
                "",
                KeyManagementCapabilitiesClass.RSAAuthenticationSchemeEnum.NotSupported,
                KeyManagementCapabilitiesClass.RSASignatureAlgorithmEnum.NotSupported,
                KeyManagementCapabilitiesClass.RSACryptAlgorithmEnum.NotSupported,
                KeyManagementCapabilitiesClass.RSAKeyCheckModeEnum.NotSupported,
                KeyManagementCapabilitiesClass.SignatureSchemeEnum.NotSupported,
                KeyManagementCapabilitiesClass.EMVImportSchemeEnum.NotSupported,
                KeyManagementCapabilitiesClass.KeyBlockImportFormatEmum.NotSupported,
                false,
                KeyManagementCapabilitiesClass.DESKeyLengthEmum.NotSupported,
                KeyManagementCapabilitiesClass.CertificateTypeEnum.NotSupported,
                [],
                KeyManagementCapabilitiesClass.CRKLLoadOptionEnum.NotSupported,
                KeyManagementCapabilitiesClass.SymmetricKeyManagementMethodEnum.NotSupported,
                [],
                [],
                []);

        public Task<DeviceResult> ClearAsync(ClearDataRequest ClearMode, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ImportResult> ImportAsync(ImportRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<MatchResult> MatchAsync(MatchRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ReadResult> ReadAsync(ReadCommandEvents events, ReadRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceResult> ResetDeviceAsync(ClearDataRequest ClearMode, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task RunAsync(CancellationToken Token)
        {
            throw new NotImplementedException();
        }

        public Task<DeviceResult> SetDataPersistenceAsync(BiometricCapabilitiesClass.PersistenceModesEnum Mode, CancellationToken cancellation)
        {
            throw new NotImplementedException();
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

        #region KeyManagement Device

        public Task<ImportKeyResult> ImportKeyPart(ImportKeyPartRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ImportKeyResult> AssemblyKeyParts(AssemblyKeyPartsRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ImportKeyResult> ImportKey(ImportKeyRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<DeviceResult> DeleteKey(DeleteKeyRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<GenerateKCVResult> GenerateKCV(GenerateKCVRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<InitializationResult> Initialization(InitializationRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<DeriveKeyResult> DeriveKey(DeriveKeyRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<DeviceResult> ResetDevice(CancellationToken cancellation)
        {
            return Task.FromResult(new DeviceResult(MessageHeader.CompletionCodeEnum.Success));
        }

        public Task<RSASignedItemResult> ExportEPPId(ExportEPPIdRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<RSASignedItemResult> ExportRSAPublicKey(ExportRSAPublicKeyRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<GenerateRSAKeyPairResult> GenerateRSAKeyPair(GenerateRSAKeyPairRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ExportCertificateResult> ExportCertificate(ExportCertificateRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ReplaceCertificateResult> ReplaceCertificate(ReplaceCertificateRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<StartKeyExchangeResult> StartKeyExchange(CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ImportCertificateResult> ImportCertificate(ImportCertificateRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<StartAuthenticateResult> StartAuthenticate(StartAuthenticateRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ImportKeyTokenResult> ImportKeyToken(ImportKeyTokenRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ImportEMVPublicKeyResult> ImportEMVPublicKey(ImportEMVPublicKeyRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        #endregion
    }
}

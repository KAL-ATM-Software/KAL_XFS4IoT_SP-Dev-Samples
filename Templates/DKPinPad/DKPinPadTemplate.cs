/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2025
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using XFS4IoT;
using XFS4IoTFramework.PinPad;
using XFS4IoTFramework.Keyboard;
using XFS4IoTFramework.Crypto;
using XFS4IoTFramework.KeyManagement;
using XFS4IoTFramework.Common;
using XFS4IoTFramework.German;
using XFS4IoTServer;

namespace PinPad.DKPinPadTemplate
{
    /// <summary>
    /// Sample PinPad device class to implement
    /// </summary>
    public class DKPinPadTemplate : IPinPadDevice, IKeyboardDevice, ICryptoDevice, IKeyManagementDevice, ICommonDevice, IGermanDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public DKPinPadTemplate(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(DKPinPadTemplate)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(
                CommonStatusClass.DeviceEnum.Online,
                CommonStatusClass.PositionStatusEnum.InPosition,
                0,
                CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                CommonStatusClass.ExchangeEnum.NotSupported,
                CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            KeyManagementStatus = new KeyManagementStatusClass(encryptionState,
                                                               certState);

            KeyboardStatus = new KeyboardStatusClass(KeyboardStatusClass.AutoBeepModeEnum.InActive);
        }

        #region Keyboard Interface
        /// <summary>
        /// This command allows an application to retrieve layout information for any device. 
        /// Either one layout or all defined layouts can be retrieved with a single request of this command. 
        /// There can be a layout for each of the different types of keyboard entry modes, if the vendor and the hardware support these different methods. The types of keyboard entry modes are: (1) Data Entry mode which corresponds to the [Keyboard.DataEntry](#keyboard.dataentry) command,(2) PIN Entry mode which corresponds to the [Keyboard.PinEntry](#keyboard.pinentry) command, (3) Secure Key Entry mode which corresponds to the [Keyboard.SecureKeyEntry](#keyboard.securekeyentry) command. The layouts can be preloaded into the device, if the device supports this, or a single layout can be loaded into the device immediately prior to the keyboard command being requested.
        /// </summary>
        public Dictionary<EntryModeEnum, List<FrameClass>> GetLayoutInfo()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function stores the pin entry via the Keyboard device. From the point this function is invoked, pin digit entries are not passed to the application. 
        /// For each pin digit, or any other active key entered, an execute notification event KeyEvent is sent in order to allow an application to perform the appropriate display action (i.e. when the pin pad has no integrated display). 
        /// The application is not informed of the value entered. 
        /// The execute notification only informs that a key has been depressed. The EnterDataEvent will be generated when the Keyboard is ready for the user to start entering data.
        /// Some Keyboard devices do not inform the application as each PIN digit is entered, but locally process the PIN entry based upon minimum pin length and maximum PIN length input parameters. 
        /// When the maximum number of pin digits is entered and the flag autoEnd is true, or a terminating key is pressed after the minimum number of pin digits is entered, the command completes.
        /// If the Cancel key is a terminator key and is pressed, then the command will complete successfully even if the minimum number of pin digits has not been entered. 
        /// Terminating FDKs can have the functionality of Enter (terminates only if minimum length has been reached) or Cancel (can terminate before minimum length is reached). 
        /// The configuration of this functionality is vendor specific.If maxLen is zero, the Service Provider does not terminate the command unless the application sets terminateKeys or terminateFDKs. 
        /// In the event that terminateKeys or terminateFDKs are not set and maxLen is zero, the command will not terminate and the application must issue a Cancel command. 
        /// If active the fkCancel and fkClear keys will cause the PIN buffer to be cleared. 
        /// The fkBackspace key will cause the last key in the PIN buffer to be removed. 
        /// Terminating keys have to be active keys to operate. 
        /// If this command is canceled by a CancelAsyncRequest the PIN buffer is not cleared. 
        /// If maxLen has been met and autoEnd is set to False, then all numeric keys will automatically be disabled. 
        /// If the clear or backspace key is pressed to reduce the number of entered keys, the numeric keys will be re-enabled. 
        /// If the enter key (or FDK representing the enter key - note that the association of an FDK to enter functionality is vendor specific) is pressed prior to minLen being met, 
        /// then the enter key or FDK is ignored. In some cases the Keyboard device cannot ignore the enter key then the command will complete normally.
        /// To handle these types of devices the application should use the output parameter digits property to check that sufficient digits have been entered.  
        /// The application should then get the user to re-enter their PIN with the correct number of digits. 
        /// If the application makes a call to [PinPad.GetPinblock](#pinpad.getpinblock) or a local verification command without the minimum PIN digits having been entered, 
        /// either the command will fail or the PIN verification will fail. It is the responsibility of the application to identify the mapping between the FDK code and the physical location of the FDK.
        /// </summary>
        public Task<PinEntryResult> PinEntry(KeyboardCommandEvents events, PinEntryRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function enables keyboard insercure mode and report entered key in clear text with solicited events. 
        /// For Keyboard device, this command will clear the pin unless the application has requested that the pin be maintained through the MaintainPin command.
        /// </summary>
        public Task<DataEntryResult> DataEntry(KeyboardCommandEvents events, DataEntryRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command allows a full length symmetric encryption key part to be entered directly into the device without being exposed outside of the device.
        /// From the point this function is invoked, encryption key digits (zero to nine and a to f) are not passed to the application. For each encryption key digit, 
        /// or any other active key entered (except for shift), an execute notification event KeyEvent is sent in order to allow an application to perform the appropriate display action 
        /// (i.e. when the device has no integrated display). 
        /// When an encryption key digit is entered the application is not informed of the value entered, instead zero is returned. 
        /// The EnterDataEvent will be generated when the device is ready for the user to start entering data. 
        /// The keys that can be enabled by this command are defined by the FuncKeyDetail parameter of the SecureKeyEntry command. 
        /// Function keys which are not associated with an encryption key digit may be enabled but will not contribute to the secure entry buffer (unless they are Cancel, Clear or Backspace) and will not count towards the length of the key entry.
        /// The Cancel and Clear keys will cause the encryption key buffer to be cleared. 
        /// The Backspace key will cause the last encryption key digit in the encryption key buffer to be removed.
        /// If autoEnd is TRUE the command will automatically complete when the required number of encryption key digits have been added to the buffer. 
        /// If autoEnd is FALSE then the command will not automatically complete and Enter, Cancel or any terminating key must be pressed. 
        /// When keyLen hex encryption key digits have been entered then all encryption key digits keys are disabled. 
        /// If the Clear or Backspace key is pressed to reduce the number of entered encryption key digits below usKeyLen, the same keys will be reenabled. 
        /// Terminating keys have to be active keys to operate.If an FDK is associated with Enter, Cancel, Clear or Backspace then the FDK must be activated to operate. 
        /// The Enter and Cancel FDKs must also be marked as a terminator if they are to terminate entry. 
        /// These FDKs are reported as normal FDKs within the KeyEvent, applications must be aware of those FDKs associated with Cancel, Clear, Backspace and Enter and handle any user interaction as required. 
        /// For example, if the fdk01 is associated with Clear, then the application must include the fdk01 FDK code in the activeFDKs parameter (if the clear functionality is required). 
        /// In addition when this FDK is pressed the [Keyboard.KeyEvent](#keyboard.keyevent) will contain the fdk01 mask value in the digit property. 
        /// The application must update the user interface to reflect the effect of the clear on the encryption key digits entered so far. 
        /// On some devices that are configured as either regularUnique or irregularUnique all the function keys on the device will be associated with hex digits and there may be no FDKs available either. 
        /// On these devices there may be no way to correct mistakes or cancel the key encryption entry before all the encryption key digits are entered, so the application must set the autoEnd flag to TRUE and wait for the command to auto-complete. 
        /// Applications should check the KCV to avoid storing an incorrect key component. 
        /// Encryption key parts entered with this command are stored through either the ImportKey. 
        /// Each key part can only be stored once after which the secure key buffer will be cleared automatically.
        /// </summary>
        public Task<SecureKeyEntryResult> SecureKeyEntry(KeyboardCommandEvents events, SecureKeyEntryRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to enable or disable the device from emitting a beep tone on subsequent key presses of active or in-active keys.
        /// This command is valid only on devices which have the capability to support application control of automatic beeping. 
        /// </summary>
        public Task<DeviceResult> SetKeypressBeep(KeyboardBeepEnum Beep, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command allows an application to configure a layout for any device. One or more layouts can be defined with a single request of this command.
        /// There can be a layout for each of the different types of keyboard entry modes, if the vendor and the hardware supports these different methods.
        /// The types of keyboard entry modes are (1) Mouse mode,(2) Data mode which corresponds to the DataEntry] command,
        /// (3) PIN mode which corresponds to the PinEntry command,
        /// (4) Secure mode which corresponds to the SecureKeyEntry command. 
        /// One or more layouts can be preloaded into the device, if the device supports this, or a single layout can be loaded into the device immediately prior to the keyboard command being requested. If a [Keyboard.DataEntry](#keyboard.dataentry), [Keyboard.PinEntry](#keyboard.pinentry), or [Keyboard.SecureKeyEntry](#keyboard.securekeyentry) command is already in progress (or queued), then this command is rejected with a command result of SequenceError. Layouts defined with this command are persistent.
        /// </summary>
        public Task<DefineLayoutResult> DefineLayout(Dictionary<EntryModeEnum, List<FrameClass>> request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Keyboard Status
        /// </summary>
        public KeyboardStatusClass KeyboardStatus { get; set; }

        /// <summary>
        /// Keyboard Capabilities
        /// </summary>
        public KeyboardCapabilitiesClass KeyboardCapabilities { get; set; } = new KeyboardCapabilitiesClass(
            AutoBeep: KeyboardCapabilitiesClass.KeyboardBeepEnum.ActiveAvailable | 
                      KeyboardCapabilitiesClass.KeyboardBeepEnum.ActiveSelectable| 
                      KeyboardCapabilitiesClass.KeyboardBeepEnum.InActiveAvailable | 
                      KeyboardCapabilitiesClass.KeyboardBeepEnum.InActiveSelectable,
            ETSCaps: null);


        #endregion

        #region PinPad Interface
        /// <summary>
        /// This command is used to report information in order to verify the PCI Security Standards Council PIN transaction security (PTS) certification held by the PIN device. 
        /// The command provides detailed information in order to verify the certification level of the device. 
        /// Support of this command by the Service Provider does not imply in anyway the certification level achieved by the device
        /// </summary>
        public PCIPTSDeviceIdClass GetPCIPTSDeviceId()
        {
            return new PCIPTSDeviceIdClass("ManufacturerIdentifier",
                                           "ModelIdentifier",
                                           "HadrwareIdentifier",
                                           "FirmwareIdentifier",
                                           "ApplicationIdentifier");
        }

        /// <summary>
        /// The PIN, which was entered with the GetPin command, is combined with the requisite data specified by the DES validation algorithm and locally verified for correctness. The result of the verification is returned to the application. This command will clear the PIN unless the application has requested that the PIN be maintained through the [PinPad.MaintinPin](#pinpad.maintainpin) command.
        /// </summary>
        public Task<VerifyPINLocalResult> VerifyPINLocalDES(VerifyPINLocalDESRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The PIN, which was entered with the GetPin command, is combined with the requisite data specified by the VISA validation algorithm and locally verified for correctness. The result of the verification is returned to the application. This command will clear the PIN unless the application has requested that the PIN be maintained through the [PinPad.MaintinPin](#pinpad.maintainpin) command.
        /// </summary>
        public Task<VerifyPINLocalResult> VerifyPINLocalVISA(VerifyPINLocalVISARequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to control if the PIN is maintained after a PIN processing command for subsequent use by other PIN processing commands. 
        /// This command is also used to clear the PIN buffer when the PIN is no longer required.
        /// </summary>
        public Task<DeviceResult> MaintainPin(bool MaintainPIN, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function should be used for devices which need to know the data for the PIN block before the PIN is entered by the user. 
        /// keyboard interface GetPin and GetPinBlock should be called after this command.
        /// For all other devices Unsupported will be returned here. If this command is required and it is not called, the Keyboard.GetPin command will fail with the generic error SequenceError. If the input parameters passed to this commad and [PinPad.GetPinBlock](#pinpad.getpinblock) are not identical, the [PinPad.GetPinBlock](#pinpad.getpinblock) command will fail with the generic error InvalidData. The data associated with this command will be cleared on a [PinPad.GetPinBlock](#pinpad.getpinblock) command.
        /// </summary>
        public Task<DeviceResult> SetPinBlockData(PINBlockRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This function takes the account information and a PIN entered by the user to build a formatted PIN.Encrypting this formatted PIN once or twice returns a PIN block which can be written on a magnetic card or sent to a host. 
        /// The PIN block can be calculated using one of the algorithms specified in the device capabilities.
        /// This command will clear the PIN unless the application has requested that the PIN be maintained through the MaintinPin command enabled.
        /// </summary>
        public Task<PINBlockResult> GetPinBlock(PinPadCommandEvents events, PINBlockRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The PIN, which was entered with the EnterPin command, is combined with the requisite data specified by the IDC presentation algorithm and presented to the smartcard contained in the ID card unit.
        /// The result of the presentation is returned to the application. 
        /// This command will clear the PIN unless the application has requested that the PIN be maintained through the MaintainPin command.
        /// </summary>
        public Task<PresentIDCResult> PresentIDC(PresentIDCRequest request,
                                          CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// PinPad Capabilities
        /// </summary>
        public PinPadCapabilitiesClass PinPadCapabilities { get; set; } = new PinPadCapabilitiesClass(
            PINFormat: PinPadCapabilitiesClass.PINFormatEnum.ANSI | PinPadCapabilitiesClass.PINFormatEnum.ISO0,
            PresentationAlgorithm: PinPadCapabilitiesClass.PresentationAlgorithmEnum.NotSupported,
            DisplayType: PinPadCapabilitiesClass.DisplayTypeEnum.NotSupported,
            IDConnect: false,
            ValidationAlgorithm: PinPadCapabilitiesClass.ValidationAlgorithmEnum.DES | PinPadCapabilitiesClass.ValidationAlgorithmEnum.VISA,
            PinCanPersistAfterUse: false,
            TypeCombined: false,
            SetPinblockDataRequired: false,
            PinBlockAttributes: new()
            {
                { "P0", new() { { "T", new() { { "E", new(PinPadCapabilitiesClass.PinBlockEncryptionAlgorithm.EncryptionAlgorithmEnum.ECB | PinPadCapabilitiesClass.PinBlockEncryptionAlgorithm.EncryptionAlgorithmEnum.CBC) } } } } }
            }
            );

        #endregion

        #region KeyManagement Interface
        /// <summary>
        /// Importing key components temporarily while in secure key loading process 
        /// </summary>
        public Task<ImportKeyResult> ImportKeyPart(ImportKeyPartRequest request,
                                                   CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Last part of loading key components stored temporarily in secure key buffer into the EPP
        /// </summary>
        public Task<ImportKeyResult> AssemblyKeyParts(AssemblyKeyPartsRequest request,
                                                      CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The encryption key passed by the application is loaded in the encryption module. 
        /// For secret keys, the key must be passed encrypted with an accompanying "key encrypting key" or "key block protection key". For public keys, they key is not required to be encrypted but is required to have verification data in order to be loaded.
        /// </summary>
        public Task<ImportKeyResult> ImportKey(ImportKeyRequest request,
                                               CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command can be used to delete a key without authentication.
        /// Where an authenticated delete is required, the StartAuthenticate command should be used.
        /// </summary>
        public Task<DeviceResult> DeleteKey(DeleteKeyRequest request,
                                            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command returns the Key Check Value (KCV) for the specified key. 
        /// </summary>
        public Task<GenerateKCVResult> GenerateKCV(GenerateKCVRequest request,
                                                   CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The encryption module must be initialized before any encryption function can be used.Every call to Initialization destroys all application keys that have been loaded or imported.
        /// it does not affect those keys loaded during manufacturing.
        /// Usually this command is called by an operator task and not by the application program.
        /// Public keys imported under the RSA Signature based remote key loading scheme when public key deletion authentication is required will not be affected. 
        /// However, if this command is requested in authenticated mode, public keys that require authentication for deletion will be deleted. 
        /// This includes public keys imported under either the RSA Signature based remote key loading scheme or the TR34 RSA Certificate based remote key loading scheme. 
        /// Initialization also involves loading 'initial' application keys and local vendor dependent keys. 
        /// These can be supplied, for example, by an operator through a keyboard, a local configuration file, 
        /// remote RSA key management or possibly by means of some secure hardware that can be attached to the device. 
        /// The application 'initial' keys would normally get updated by the application during a Importkey command as soon as possible.
        /// Local vendor dependent static keys (e.g. storage, firmware and offset keys) would normally be transparent to the application and by definition cannot be dynamically changed.
        /// Where initial keys are not available immediately when this command is issued (i.e. when operator intervention is required), 
        /// the Service Provider returns accessDenied and the application must await the initializedevent.
        /// During initialization an optional encrypted ID key can be stored in the HW module. 
        /// The ID key and the corresponding encryption key can be passed as parameters.
        /// if not, they are generated automatically by the encryption module.The encrypted ID is returned to the application and serves as authorization for the key import function.The capabilities indicates whether or not the device will support this feature.
        /// This function also resets the hsm terminal data, except session key index and trace number. 
        /// This function resets all certificate data and authentication public/private keys back to their initial states at the time of production (except for those public keys imported under the RSA Signature based remote key loading scheme when public key deletion authentication is required).
        /// Key-pairs created with [KeyManagement.GenerateRSAKeyPair](#keymanagement.generatersakeypair) are deleted.
        /// Any keys installed during production, which have been permanently replaced, will not be reset.
        /// Any Verification certificates that may have been loaded must be reloaded.The Certificate state will remain the same, 
        /// but the LoadCertificate or ReplaceCertificate commands must be called again.When multiple ZKA HSMs are present, 
        /// this command deletes all keys loaded within all ZKA logical HSMs.
        /// </summary>
        public Task<InitializationResult> Initialization(InitializationRequest request,
                                                         CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The encryption key in the secure key buffer or passed by the application is loaded in the encryption module.
        /// The key can be passed in clear text mode or encrypted with an accompanying 'key encryption key'. 
        /// A key can be loaded in multiple unencrypted parts by combining the construct or secureConstruct value with the final usage flags within the use field. 
        /// If the construct flag is used then the application must provide the key data through the value parameter,
        /// If secureConstruct is used then the encryption key part in the secure key buffer previously populated with the 
        /// keyboard.SecureKeyEntry command is used and value is ignored. 
        /// Key parts loaded with the secureConstruct flag can only be stored once as the encryption key in the secure key buffer is no longer available after this command has been executed. 
        /// The construct and secureConstruct construction flags cannot be used in combination. 
        /// </summary>
        public Task<DeriveKeyResult> DeriveKey(DeriveKeyRequest request,
                                               CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Sends a service reset to the Service Provider. 
        /// </summary>
        public Task<DeviceResult> ResetDevice(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This command is used to export data elements from the device, which have been signed by an offline Signature Issuer or
        /// a private key within the EPP. 
        /// This command is used when the default keys and Signature Issuer signatures, installed during manufacture, 
        /// are to be used for remote key loading. This command allows the following data items are to be exported:
        /// - The Security Item which uniquely identifies the device. 
        ///   This value may be used to uniquely identify a device and therefore confer trust upon any key or data obtained from this device.
        /// - The RSA public key component of a public/private key pair that exists within the device.
        ///   These public/private key pairs are installed during manufacture.
        ///   Typically, an exported public key is used by the host to encipher the symmetric key.
        /// </summary>
        public Task<RSASignedItemResult> ExportEPPId(ExportEPPIdRequest request,
                                                     CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<RSASignedItemResult> ExportRSAPublicKey(ExportRSAPublicKeyRequest request,
                                                            CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command will generate a new RSA key pair.
        /// The public key generated as a result of this command can subsequently be obtained by calling 
        /// ExportRSAEPPSignedItem.The newly generated key pair can only be used for the use defined in the use flag.
        /// This flag defines the use of the private key; its public key can only be used for the inverse function.
        /// </summary>
        public Task<GenerateRSAKeyPairResult> GenerateRSAKeyPair(GenerateRSAKeyPairRequest request,
                                                                 CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to read out the encryptor's certificate, which has been signed by the trusted Certificate Authority and is sent to the host. 
        /// This command only needs to be called once if no new Certificate Authority has taken over.
        /// The output of this command will specify in the PKCS #7 message the resulting Primary or Secondary certificate.
        /// </summary>
        public Task<ExportCertificateResult> ExportCertificate(ExportCertificateRequest request,
                                                               CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to replace the existing primary or secondary Certificate Authority certificate already loaded into the KeyManagement.
        /// This operation must be done by an Initial Certificate Authority or by a Sub-Certificate Authority.
        /// These operations will replace either the primary or secondary Certificate Authority public verification key inside of the KeyManagement.
        /// After this command is complete, the application should send the LoadCertificate and GetCertificate commands to ensure that the new HOST and the encryptor have all the information required to perform the remote key loading process.
        /// </summary>
        public Task<ReplaceCertificateResult> ReplaceCertificate(ReplaceCertificateRequest request,
                                                                 CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to start communication with the host, including transferring the host's Key Transport Key, 
        /// replacing the Host certificate, and requesting initialization remotely. 
        /// This output value is returned to the host and is used in the ImportKey and LoadCertificate to verify that the encryptor is talking to the proper host.
        /// The ImportKey command end the key exchange process.
        /// </summary>
        public Task<StartKeyExchangeResult> StartKeyExchange(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// This command is used to load a host certificate to make remote key loading possible. 
        /// This command can be used to load a host certificate when there is not already one present in the encryptor as well as replace the existing host certificate with a new host certificate.
        /// The type of certificate (Primary or Secondary) to be loaded will be embedded within the actual certificate structure.
        /// </summary>
        public Task<ImportCertificateResult> ImportCertificate(ImportCertificateRequest request,
                                                               CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to retrieve the data that needs to be signed and hence provided to the Authenticate command in order to perform an authenticated action on the device.
        /// If this command returns data to be signed then the Authenticate command must be used to call the command referenced by the payload.
        /// Any attempt to call the referenced command without using the Authenticate command, if authentication is required, 
        /// shall result in AuthRequired. 
        /// </summary>
        public Task<StartAuthenticateResult> StartAuthenticate(StartAuthenticateRequest request, 
                                                               CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ImportKeyTokenResult> ImportKeyToken(ImportKeyTokenRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        public Task<ImportEMVPublicKeyResult> ImportEMVPublicKey(ImportEMVPublicKeyRequest request, CancellationToken cancellation)
            => throw new NotSupportedException();

        /// <summary>
        /// KeyManagement Status
        /// </summary>
        public KeyManagementStatusClass KeyManagementStatus { get; set; }

        /// <summary>
        /// KeyManagement Capabilities
        /// </summary>
        public KeyManagementCapabilitiesClass KeyManagementCapabilities { get; set; } = new KeyManagementCapabilitiesClass(
            MaxKeys: 100,
            KeyCheckModes: KeyManagementCapabilitiesClass.KeyCheckModeEnum.Self | KeyManagementCapabilitiesClass.KeyCheckModeEnum.Zero,
            HSMVendor: string.Empty,
            RSAAuthenticationScheme: KeyManagementCapabilitiesClass.RSAAuthenticationSchemeEnum.SecondPartySignature | KeyManagementCapabilitiesClass.RSAAuthenticationSchemeEnum.ThirdPartyCertificate,
            RSASignatureAlgorithm: KeyManagementCapabilitiesClass.RSASignatureAlgorithmEnum.RSASSA_PKCS1_V1_5,
            RSACryptAlgorithm: KeyManagementCapabilitiesClass.RSACryptAlgorithmEnum.RSAES_PKCS1_V1_5,
            RSAKeyCheckMode: KeyManagementCapabilitiesClass.RSAKeyCheckModeEnum.SHA1 | 
                             KeyManagementCapabilitiesClass.RSAKeyCheckModeEnum.SHA256,
            SignatureScheme: KeyManagementCapabilitiesClass.SignatureSchemeEnum.ExportEPPID | 
                             KeyManagementCapabilitiesClass.SignatureSchemeEnum.RandomNumber | 
                             KeyManagementCapabilitiesClass.SignatureSchemeEnum.EnhancedRKL,
            EMVImportSchemes: KeyManagementCapabilitiesClass.EMVImportSchemeEnum.NotSupported,
            KeyBlockImportFormats: KeyManagementCapabilitiesClass.KeyBlockImportFormatEmum.KEYBLOCKA | 
                                   KeyManagementCapabilitiesClass.KeyBlockImportFormatEmum.KEYBLOCKB | 
                                   KeyManagementCapabilitiesClass.KeyBlockImportFormatEmum.KEYBLOCKC,
            KeyImportThroughParts: true,
            DESKeyLength: KeyManagementCapabilitiesClass.DESKeyLengthEmum.Double,
            CertificateTypes: KeyManagementCapabilitiesClass.CertificateTypeEnum.HostKey | 
                              KeyManagementCapabilitiesClass.CertificateTypeEnum.EncKey | 
                              KeyManagementCapabilitiesClass.CertificateTypeEnum.VerificationKey,
            LoadCertificationOptions:
            [
                new KeyManagementCapabilitiesClass.SingerCapabilities(KeyManagementCapabilitiesClass.LoadCertificateSignerEnum.CA_TR34, KeyManagementCapabilitiesClass.LoadCertificateOptionEnum.NewHost, false)
            ],
            CRKLLoadOption: KeyManagementCapabilitiesClass.CRKLLoadOptionEnum.NotSupported,
            SymmetricKeyManagementMethods: KeyManagementCapabilitiesClass.SymmetricKeyManagementMethodEnum.MasterKey,
            KeyAttributes: new()
            {
                { "00", new() { { "T", new() { { "V", null } } } } },
                { "D0", new() { { "T", new() { { "E", null } } } } },
                { "D1", new() { { "R", new() { { "E", null } } } } },
                { "I0", new() { { "T", new() { { "D", null } } } } },
                { "K0", new() { { "T", new() { { "B", null }, { "D", null }, { "E", null } } } } },
                { "K1", new() { { "R", new() { { "T", null } } } } },
                { "K2", new() { { "R", new() { { "T", null } } } } },
                { "M0", new() { { "T", new() { { "C", null }, { "G", null }, { "V", null } } } } },
                { "P0", new() { { "T", new() { { "E", null } } } } },
                { "S0", new() { { "R", new() { { "S", null }, { "V", null } } } } },
                { "S1", new() { { "R", new() { { "T", null }, { "V", null } } } } },
                { "SS", new() { { "R", new() { { "S", null }, { "V", null } } } } }
            },
            DecryptAttributes: new()
            {
                { "T", new(KeyManagementCapabilitiesClass.DecryptMethodClass.DecryptMethodEnum.ECB | KeyManagementCapabilitiesClass.DecryptMethodClass.DecryptMethodEnum.CBC) },
                { "R", new(KeyManagementCapabilitiesClass.DecryptMethodClass.DecryptMethodEnum.RSAES_PKCS1_V1_5) }
            },
            VerifyAttributes: new()
            {
                { "M0", new() { { "T", new() { { "V", new KeyManagementCapabilitiesClass.VerifyMethodClass(KeyManagementCapabilitiesClass.VerifyMethodClass.CryptoMethodEnum.KCVSelf | KeyManagementCapabilitiesClass.VerifyMethodClass.CryptoMethodEnum.KCVZero) } } } } },
                { "S0", new() { { "R", new() { { "V", new KeyManagementCapabilitiesClass.VerifyMethodClass(KeyManagementCapabilitiesClass.VerifyMethodClass.CryptoMethodEnum.RSASSA_PKCS1_V1_5) } } } } },
                { "S1", new() { { "R", new() { { "V", new KeyManagementCapabilitiesClass.VerifyMethodClass(KeyManagementCapabilitiesClass.VerifyMethodClass.CryptoMethodEnum.RSASSA_PKCS1_V1_5) } } } } },
                { "S2", new() { { "R", new() { { "V", new KeyManagementCapabilitiesClass.VerifyMethodClass(KeyManagementCapabilitiesClass.VerifyMethodClass.CryptoMethodEnum.RSASSA_PKCS1_V1_5) } } } } },
            }
            );

        #endregion

        #region Crypto Interface
        /// <summary>
        /// This command is used to generate a random number. 
        /// </summary>
        public Task<GenerateRandomNumberResult> GenerateRandomNumber(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The input data is either encrypted or decrypted using the specified or selected encryption mode.
        /// The input datais padded to the necessary length mandated by the encryption algorithm using the padding parameter. 
        /// This inputdata is padded to necessary length mandated by the signature algorithm using padding parameter.
        /// Applications canuse an alternative padding method by pre-formatting the data passed and combining this with the standard padding method.
        /// The start value (or Initialization Vector) can be provided as input data to this command, or it can beimported via TR-31 prior to requesting this command and referenced by name.
        /// The start value and start value keyare both optional parameters.
        /// </summary>
        public Task<CryptoDataResult> Crypto(CryptoCommandEvents events,
                                             CryptoDataRequest request,
                                             CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command can be used for asymmetric signature generation.
        /// This input data is padded to necessary length mandated by the signature algorithm using padding parameter.
        /// Applications can use an alternative padding method by pre-formatting the data passed and combining this withthe standard padding method. 
        /// </summary>
        public Task<GenerateAuthenticationDataResult> GenerateSignature(CryptoCommandEvents events,
                                                                        GenerateSignatureRequest request,
                                                                        CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// This command can be used for Message Authentication Code generation (i.e. macing).
        /// The input data ispadded to the necessary length mandated by the encryption algorithm using the padding parameter.
        public Task<GenerateAuthenticationDataResult> GenerateMAC(CryptoCommandEvents events,
                                                                  GenerateMACRequest request,
                                                                  CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command can be used for signature verification.
        /// This input data is padded to necessarylength mandated by the signature algorithm using padding parameter.
        /// Applications can use an alternative paddingmethod by pre-formatting the data passed and combining this with the standard padding method.
        /// The start value (orInitialization Vector) can be provided as input data to this command, or it can be imported via TR-31 prior to requesting this command and referenced by name. 
        /// The start value and start value key are both optional parameters.
        /// </summary>
        public Task<VerifyAuthenticationDataResult> VerifySignature(CryptoCommandEvents events,
                                                                    VerifySignatureRequest request,
                                                                    CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// This command can be used for MAC verification.
        /// The input data is padded to the necessary length mandated by the encryption algorithm using the padding parameter.
        public Task<VerifyAuthenticationDataResult> VerifyMAC(CryptoCommandEvents events,
                                                              VerifyMACRequest request,
                                                              CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This command is used to compute a hash code on a stream of data using the specified hash algorithm. 
        /// This command can be used to verify EMV static and dynamic data.
        /// </summary>
        public Task<GenerateDigestResult> GenerateDigest(GenerateDigestRequest request,
                                                         CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Crypto Capabilities
        /// </summary>
        public CryptoCapabilitiesClass CryptoCapabilities { get; set; } = new CryptoCapabilitiesClass(
            EMVHashAlgorithms: CryptoCapabilitiesClass.EMVHashAlgorithmEnum.SHA1_Digest | CryptoCapabilitiesClass.EMVHashAlgorithmEnum.SHA256_Digest,
            CryptoAttributes: new()
            {
                { "D0", new() { { "T", new() { { "E", new CryptoCapabilitiesClass.CryptoAttributesClass(CryptoCapabilitiesClass.CryptoAttributesClass.CryptoMethodEnum.ECB | CryptoCapabilitiesClass.CryptoAttributesClass.CryptoMethodEnum.CBC) } } } } },
                { "D1", new() { { "R", new() { { "E", new CryptoCapabilitiesClass.CryptoAttributesClass(CryptoCapabilitiesClass.CryptoAttributesClass.CryptoMethodEnum.ECB | CryptoCapabilitiesClass.CryptoAttributesClass.CryptoMethodEnum.CBC) } } } } }
            },
            AuthenticationAttributes: new()
            {
                { "M0", new() { { "T", new() { { "G", null } } } } },
                { "S0", new() { { "R", new() { { "S", new(CryptoCapabilitiesClass.VerifyAuthenticationAttributesClass.RSASignatureAlgorithmEnum.RSASSA_PKCS1_V1_5, CryptoCapabilitiesClass.HashAlgorithmEnum.SHA1 | CryptoCapabilitiesClass.HashAlgorithmEnum.SHA256) } } } } }
            },
            VerifyAttributes: new()
            {
                { "M0", new() { { "T", new() { { "V", null } } } } },
                { "S0", new() { { "R", new() { { "V", new(CryptoCapabilitiesClass.VerifyAuthenticationAttributesClass.RSASignatureAlgorithmEnum.RSASSA_PKCS1_V1_5, CryptoCapabilitiesClass.HashAlgorithmEnum.SHA1 | CryptoCapabilitiesClass.HashAlgorithmEnum.SHA256) } } } } }
            });

        #endregion

        #region German Interface
        /// <summary>
        /// Returns the current HSM terminal data.
        /// </summary>
        public Task<GetHSMTDataResponse> GetHSMTDataAsync(CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This operation allows the application to set the HSM terminal data 
        /// (except keys, trace number and session key index). 
        /// Terminal data that is included but not supported by the hardware will be ignored.
        /// </summary>
        public Task<SetHSMTDataResponse> SetHSMTDataAsync(SetHSMTDataRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This operation handles all messages that should be sent through secure messaging to an authorization 
        /// or personalization system. The encryption module adds the security relevant fields to the message 
        /// and returns the modified message in the output structure. 
        /// All messages must be presented to the encryptor via this operation even if they do not contain 
        /// security fields in order to keep track of the transaction status in the internal state machine.          
        /// </summary>
        public Task<SecureMsgSendResponse> SecureMsgSendAsync(SecureMsgSendRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This operation handles all messages that are received through a secure messaging from an authorization 
        /// or personalization system.The encryption module checks the security relevant properties. 
        /// All messages must be presented to the encryptor via this operation even if they do not contain 
        /// security relevant properties in order to keep track of the transaction status in the internal 
        /// state machine.
        /// </summary>
        public Task<SecureMsgReceiveResponse> SecureMsgReceiveAsync(SecureMsgReceiveRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This operation is used to set the HSM out of order (Außerbetriebnahme).
        /// At the same time the online time can be set to control when the OPT online dialog
        /// shall be started to initialize the HSM again.
        /// When this time is reached an German.OPTRequiredEvent could be sent.
        /// </summary>
        public Task<HSMInitResponse> HSMInitAsync(HSMInitRequest request, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// German specific capabilities
        /// </summary>
        public GermanCapabilitiesClass GermanCapabilities { get; set; }
        #endregion
        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling MediaRemovedEvent after card is ejected successfully.
        /// </summary>
        /// <returns></returns>
        public Task RunAsync(CancellationToken Token)
        {
            return Task.CompletedTask;
        }

        #region COMMON Interface

        /// <summary>
        /// Stores Commons status
        /// </summary>
        public CommonStatusClass CommonStatus { get; set; }

        /// <summary>
        /// Stores Common Capabilities
        /// </summary>
        public CommonCapabilitiesClass CommonCapabilities { get; set; } = new CommonCapabilitiesClass(
                CommonInterface: new CommonCapabilitiesClass.CommonInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.StatusChangedEvent,
                        CommonCapabilitiesClass.CommonInterfaceClass.EventEnum.ErrorEvent
                    ]
                ),
                KeyManagementInterface: new CommonCapabilitiesClass.KeyManagementInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.DeleteKey,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.ExportRSADeviceSignedItem,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.GenerateKCV,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.GenerateRSAKeyPair,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.GetCertificate,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.ImportKey,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.Initialization,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.LoadCertificate,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.ReplaceCertificate,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.StartAuthenticate,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.GetKeyDetail,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.EventEnum.CertificateChangeEvent,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.EventEnum.InitializedEvent,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.EventEnum.DUKPTKSNEvent,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.EventEnum.IllegalKeyAccessEvent,
                    ]
                ),
                CryptoInterface: new CommonCapabilitiesClass.CryptoInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.CryptoData,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.Digest,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.GenerateAuthentication,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.GenerateRandom,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.VerifyAuthentication,
                    ]
                ),
                PinPadInterface: new CommonCapabilitiesClass.PinPadInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.GetPinBlock,
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.GetQueryPCIPTSDeviceId,
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.LocalDES,
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.LocalVisa,
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.MaintainPin,
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.PresentIDC,
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.PinPadInterfaceClass.CommandEnum.SetPinBlockData,
                    ]
                ),
                KeyboardInterface: new CommonCapabilitiesClass.KeyboardInterfaceClass
                (
                    Commands:
                    [
                        CommonCapabilitiesClass.KeyboardInterfaceClass.CommandEnum.DataEntry,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.CommandEnum.DefineLayout,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.CommandEnum.GetLayout,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.CommandEnum.KeypressBeep,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.CommandEnum.PinEntry,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.CommandEnum.Reset,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.CommandEnum.SecureKeyEntry,
                    ],
                    Events:
                    [
                        CommonCapabilitiesClass.KeyboardInterfaceClass.EventEnum.EnterDataEvent,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.EventEnum.KeyEvent,
                        CommonCapabilitiesClass.KeyboardInterfaceClass.EventEnum.LayoutEvent,
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
                                new CommonCapabilitiesClass.SoftwareClass(
                                        SoftwareName: "XFS4 SP",
                                        SoftwareVersion: "1.0")
                            ])
                ],
                PowerSaveControl: false,
                AntiFraudModule: false,
                EndToEndSecurity: new CommonCapabilitiesClass.EndToEndSecurityClass
                (
                    Required: CommonCapabilitiesClass.EndToEndSecurityClass.RequiredEnum.Always,
                    HardwareSecurityElement: false, // Sample is software. Real hardware should use an HSE. 
                    ResponseSecurityEnabled: CommonCapabilitiesClass.EndToEndSecurityClass.ResponseSecurityEnabledEnum.NotSupported // ToDo: GetPresentStatus token support
                ));

        public Task<DeviceResult> PowerSaveControl(int MaxPowerSaveRecoveryTime, CancellationToken cancel) => throw new NotImplementedException();
        public Task<DeviceResult> SetTransactionState(SetTransactionStateRequest request) => throw new NotImplementedException();
        public Task<GetTransactionStateResult> GetTransactionState() => throw new NotImplementedException();
        public Task<GetCommandNonceResult> GetCommandNonce() => throw new NotImplementedException();
        public Task<DeviceResult> ClearCommandNonce() => throw new NotImplementedException();

        #endregion

        private static List<byte> GenerateRandomNumber()
        {
            throw new NotImplementedException();
        }

        private class LoadedKeyInfo
        {
            public enum AlgorithmKeyEnum
            {
            }

            public LoadedKeyInfo(string KeyName,
                                 AlgorithmKeyEnum Algorithm,
                                 List<byte> KeyData)
            {
                this.KeyName = KeyName;
                this.Algorithm = Algorithm;
                this.KeyData = KeyData;
            }

            public string KeyName { get; init; }

            public List<byte> KeyData { get; init; }

            public AlgorithmKeyEnum Algorithm { get; init; }
        }

        private bool StoreKeys(Dictionary<string, LoadedKeyInfo> obj)
        {
            throw new NotImplementedException();
        }

        private Dictionary<string, LoadedKeyInfo> GetKeys()
        {
            throw new NotImplementedException();
        }

        public XFS4IoTServer.IServiceProvider SetServiceProvider { get; set; }

        private ILogger Logger { get; }

        private readonly KeyManagementStatusClass.EncryptionStateEnum encryptionState = KeyManagementStatusClass.EncryptionStateEnum.NotInitialized;
        private readonly KeyManagementStatusClass.CertificateStateEnum certState = KeyManagementStatusClass.CertificateStateEnum.Primary;

        private readonly Dictionary<EntryModeEnum, List<FrameClass>> keyLayouts = [];

        private static class Constants
        {
            public const int RandomNumberLength = 8;
            public const string EPPUID = "EPPUID";
            public const string EPPVendorKeyName = "EPPVendorKeyName";
            public const string EPPVendorSigKeyName = "EPPVendorSigKeyName";
            public const string PERSIT = "PERSIT";
        }
    }
}
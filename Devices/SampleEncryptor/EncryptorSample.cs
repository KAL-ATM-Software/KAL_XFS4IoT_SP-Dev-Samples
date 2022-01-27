/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
#pragma warning disable CA1416 // Validate platform compatibility, only works for windows

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text;
using System.Linq;
using System.IO;
using XFS4IoT;
using XFS4IoTFramework.Crypto;
using XFS4IoTFramework.KeyManagement;
using XFS4IoTFramework.Common;
using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;
using XFS4IoT.Common;
using XFS4IoT.KeyManagement.Completions;
using XFS4IoT.Crypto.Completions;
using XFS4IoT.Completions;
using XFS4IoTServer;

namespace KAL.XFS4IoTSP.Encryptor.Sample
{
    /// <summary>
    /// Sample Encryptor device class to implement
    /// </summary>
    public class EncryptorSample : ICryptoDevice, IKeyManagementDevice, ICommonDevice
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Logger"></param>
        public EncryptorSample(ILogger Logger)
        {
            Logger.IsNotNull($"Invalid parameter received in the {nameof(EncryptorSample)} constructor. {nameof(Logger)}");
            this.Logger = Logger;

            CommonStatus = new CommonStatusClass(CommonStatusClass.DeviceEnum.Online,
                                                 CommonStatusClass.PositionStatusEnum.InPosition,
                                                 0,
                                                 CommonStatusClass.AntiFraudModuleEnum.NotSupported,
                                                 CommonStatusClass.ExchangeEnum.NotSupported,
                                                 CommonStatusClass.EndToEndSecurityEnum.NotSupported);

            KeyManagementStatus = new KeyManagementStatusClass(KeyManagementStatusClass.EncryptionStateEnum.Initialized,
                                                               KeyManagementStatusClass.CertificateStateEnum.Primary);
        }

        #region KeyManagement interface
        /// <summary>
        /// Importing key components temporarily while in secure key loading process 
        /// </summary>
        public async Task<ImportKeyResult> ImportKeyPart(ImportKeyPartRequest request,
                                                         CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);
            // Keyboard interface is not supported in the Encryptor SP
            return new ImportKeyResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand);
        }


        /// <summary>
        /// Last part of loading key components stored temporarily in secure key buffer into the EPP
        /// </summary>
        public async Task<ImportKeyResult> AssemblyKeyParts(AssemblyKeyPartsRequest request,
                                                            CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);
            // Keyboard interface is not supported in the Encryptor SP
            return new ImportKeyResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand);
        }

        /// <summary>
        /// The encryption key passed by the application is loaded in the encryption module. 
        /// For secret keys, the key must be passed encrypted with an accompanying "key encrypting key" or "key block protection key". For public keys, they key is not required to be encrypted but is required to have verification data in order to be loaded.
        /// </summary>
        public async Task<ImportKeyResult> ImportKey(ImportKeyRequest request,
                                                     CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            Dictionary<string, LoadedKeyInfo> loadedKeys = GetKeys();
            if (loadedKeys.ContainsKey(request.KeyName))
            {
                return new ImportKeyResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                           $"Specified key already exist. {request.KeyName}",
                                           ImportKeyCompletion.PayloadData.ErrorCodeEnum.DuplicateKey);
            }

            if (request.Algorithm != "T" &&
                request.Algorithm != "R")
            {
                return new ImportKeyResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                           $"Specified algorithm is not supproted. {request.Algorithm}",
                                           ImportKeyCompletion.PayloadData.ErrorCodeEnum.AlgorithmNotSupported);
            }

            loadedKeys.Add(request.KeyName, new(request.KeyName, LoadedKeyInfo.AlgorithmKeyEnum.TDES, request.KeyData));
            StoreKeys(loadedKeys);

            List<byte> keyCheckValue = null;
            int keyLength = 0;
            ImportKeyResult.VerifyAttributeClass verifyAttrib = null;

            TripleDES tDESEncrypt = new TripleDESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Key = request.KeyData.ToArray()
            };

            if (request.VerifyAttribute is null)
            {
                byte[] checkKey = null;

                if (request.Algorithm != "R")
                {
                    checkKey = new byte[request.KeyData.Count];
                    for (int i = 0; i < checkKey.Length; i++)
                        checkKey[i] = 0;
                }
                else
                {
                    verifyAttrib = new ImportKeyResult.VerifyAttributeClass("00", "R", "V", ImportKeyRequest.VerifyAttributeClass.VerifyMethodEnum.RSASSA_PSS, ImportKeyRequest.VerifyAttributeClass.HashAlgorithmEnum.SHA256);
                    keyCheckValue = new SHA256CryptoServiceProvider().ComputeHash(request.KeyData.ToArray()).ToList();
                    keyLength = 2048;
                }

                if (checkKey is not null)
                {
                    ICryptoTransform transForm = tDESEncrypt.CreateEncryptor();
                    MemoryStream memStream = new();
                    CryptoStream cryptoStream = new(memStream, transForm, CryptoStreamMode.Write);
                    cryptoStream.Write(checkKey, 0, checkKey.Length);
                    cryptoStream.FlushFinalBlock();

                    verifyAttrib = new ImportKeyResult.VerifyAttributeClass("00", "T", "V", ImportKeyRequest.VerifyAttributeClass.VerifyMethodEnum.KCVZero);
                    keyLength = request.KeyData.Count;

                    keyCheckValue = memStream.ToArray().ToList();
                    keyCheckValue = keyCheckValue.GetRange(0, 3);
                    keyLength *= 8;
                }
            }

            return new ImportKeyResult(MessagePayload.CompletionCodeEnum.Success,
                                       new KeyInformationBase(),
                                       keyCheckValue,
                                       verifyAttrib,
                                       keyLength);
        }

        /// <summary>
        /// This command can be used to delete a key without authentication.
        /// Where an authenticated delete is required, the StartAuthenticate command should be used.
        /// </summary>
        public async Task<DeviceResult> DeleteKey(DeleteKeyRequest request,
                                                  CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            try
            {
                RSACryptoServiceProvider rsaServiceProvider = new(new CspParameters()
                {
                    Flags = CspProviderFlags.UseExistingKey,
                    KeyContainerName = request.KeyName
                });
                rsaServiceProvider.Clear();
                return new DeviceResult(MessagePayload.CompletionCodeEnum.Success);
            }
            catch (Exception)
            { }

            Dictionary<string, LoadedKeyInfo> keys = GetKeys();
            foreach (var key in keys)
            {
                if (key.Key == request.KeyName)
                {
                    keys.Remove(request.KeyName);
                    break;
                }
            }
            StoreKeys(keys);

            return new DeviceResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This command returns the Key Check Value (KCV) for the specified key. 
        /// </summary>
        public async Task<GenerateKCVResult> GenerateKCV(GenerateKCVRequest request,
                                                         CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            Dictionary<string, LoadedKeyInfo> keys = GetKeys();

            if (!keys.ContainsKey(request.KeyName))
            {
                bool rsaKeyRequested = true;
                try
                {
                    RSACryptoServiceProvider rsaServiceProvider = new(new CspParameters()
                    {
                        Flags = CspProviderFlags.UseExistingKey,
                        KeyContainerName = request.KeyName
                    });
                }
                catch (Exception)
                {
                    rsaKeyRequested = false;
                }

                return new GenerateKCVResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                             rsaKeyRequested ? $"RSA KVC is not supported by the GenerateKCV. {request.KeyName}" : $"Key not found. {request.KeyName}",
                                             rsaKeyRequested ? GenerateKCVCompletion.PayloadData.ErrorCodeEnum.AccessDenied : GenerateKCVCompletion.PayloadData.ErrorCodeEnum.KeyNotFound);
            }

            TripleDES tDESEncrypt = new TripleDESCryptoServiceProvider
            {
                Mode = CipherMode.ECB,
                Key = keys[request.KeyName].KeyData.ToArray()
            };
            byte[] checkKey = tDESEncrypt.Key;
            if (request.KVCMode == GenerateKCVRequest.KeyCheckValueEnum.Zero)
            {
                for (int i = 0; i < checkKey.Length; i++)
                    checkKey[i] = 0;
            }

            ICryptoTransform transForm = tDESEncrypt.CreateEncryptor();
            MemoryStream memStream = new();
            CryptoStream cryptoStream = new(memStream, transForm, CryptoStreamMode.Write);
            cryptoStream.Write(checkKey, 0, checkKey.Length);
            cryptoStream.FlushFinalBlock();

            return new GenerateKCVResult(MessagePayload.CompletionCodeEnum.Success,
                                         memStream.ToArray().ToList());
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
        public async Task<InitializationResult> Initialization(InitializationRequest request,
                                                               CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            Dictionary<string, LoadedKeyInfo> keys = GetKeys();
            foreach (var key in keys)
            {
                if (key.Key == Constants.MasterKeyName)
                    continue;

                keys.Remove(key.Key);
            }
            StoreKeys(keys);

            initializedSignal.Release();


            return new InitializationResult(MessagePayload.CompletionCodeEnum.Success);
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
        public async Task<DeriveKeyResult> DeriveKey(DeriveKeyRequest request,
                                                     CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);
            return new DeriveKeyResult(MessagePayload.CompletionCodeEnum.UnsupportedCommand);
        }

        /// <summary>
        /// Sends a service reset to the Service Provider. 
        /// </summary>
        public async Task<DeviceResult> ResetDevice(CancellationToken cancellation)
        {
            await Task.Delay(1000, cancellation);

            initializedSignal.Release();


            return new InitializationResult(MessagePayload.CompletionCodeEnum.Success);
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
        public async Task<RSASignedItemResult> ExportEPPId(ExportEPPIdRequest request,
                                                           CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            List<byte> eppID = Encoding.ASCII.GetBytes(Constants.EPPUID).ToList();

            // Sign ID with EPP private key
            RSACryptoServiceProvider rsaServiceProvider = new(new CspParameters()
            {
                KeyContainerName = Constants.EPPVendorKeyName
            }); ;

            List<byte> signed = rsaServiceProvider.SignHash(eppID.ToArray(), CryptoConfig.MapNameToOID("SHA256")).ToList();

            return new RSASignedItemResult(MessagePayload.CompletionCodeEnum.Success,
                                           Data: eppID,
                                           SignatureAlgorithm: RSASignedItemResult.RSASignatureAlgorithmEnum.RSASSA_PKCS1_V1_5,
                                           Signature: signed);
        }

        public async Task<RSASignedItemResult> ExportRSAPublicKey(ExportRSAPublicKeyRequest request,
                                                                  CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            RSACryptoServiceProvider rsaServiceProvider = new(new CspParameters()
            {
                KeyContainerName = Constants.EPPVendorKeyName
            });

            List<byte> publicKey = rsaServiceProvider.ExportRSAPublicKey().ToList();
            List<byte> signed = rsaServiceProvider.SignHash(publicKey.ToArray(), CryptoConfig.MapNameToOID("SHA256")).ToList();

            return new RSASignedItemResult(MessagePayload.CompletionCodeEnum.Success,
                                           Data: publicKey,
                                           SignatureAlgorithm: RSASignedItemResult.RSASignatureAlgorithmEnum.RSASSA_PKCS1_V1_5,
                                           Signature: signed);
        }

        /// <summary>
        /// This command will generate a new RSA key pair.
        /// The public key generated as a result of this command can subsequently be obtained by calling 
        /// ExportRSAEPPSignedItem.The newly generated key pair can only be used for the use defined in the use flag.
        /// This flag defines the use of the private key; its public key can only be used for the inverse function.
        /// </summary>
        public async Task<GenerateRSAKeyPairResult> GenerateRSAKeyPair(GenerateRSAKeyPairRequest request,
                                                                       CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            RSACryptoServiceProvider rsaServiceProvider = null;
            try
            {
                rsaServiceProvider = new(new CspParameters()
                {
                    Flags = CspProviderFlags.UseExistingKey,
                    KeyContainerName = request.KeyName
                });
            }
            catch (Exception)
            { }

            if (rsaServiceProvider is not null)
            {
                return new GenerateRSAKeyPairResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                                    $"Requested key exist. {request.KeyName}",
                                                    GenerateRSAKeyPairCompletion.PayloadData.ErrorCodeEnum.DuplicateKey);
            }

            rsaServiceProvider = new(new CspParameters()
            {
                KeyContainerName = request.KeyName
            });

            return new GenerateRSAKeyPairResult(MessagePayload.CompletionCodeEnum.Success,
                                                new GenerateRSAKeyPairResult.LoadedKeyInformation("S0",
                                                                                                  "R",
                                                                                                  "S",
                                                                                                  rsaServiceProvider.KeySize,
                                                                                                  Exportability: "S"));
        }

        /// <summary>
        /// This command is used to read out the encryptor's certificate, which has been signed by the trusted Certificate Authority and is sent to the host. 
        /// This command only needs to be called once if no new Certificate Authority has taken over.
        /// The output of this command will specify in the PKCS #7 message the resulting Primary or Secondary certificate.
        /// </summary>
        public async Task<ExportCertificateResult> ExportCertificate(ExportCertificateRequest request,
                                                                     CancellationToken cancellation)
        {
            if (KeyManagementStatus.CertificateState == KeyManagementStatusClass.CertificateStateEnum.NotReady ||
                KeyManagementStatus.CertificateState == KeyManagementStatusClass.CertificateStateEnum.Unknown)
            {
                return new ExportCertificateResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                                   $"Invalid certification state. {KeyManagementStatus.CertificateState}",
                                                   GetCertificateCompletion.PayloadData.ErrorCodeEnum.InvalidCertificateState);
            }

            await Task.Delay(200, cancellation);

            List<byte> certificate = new()
            {
                0x30, 0x82, 0x03, 0x6C, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x07, 0x02, 0xA0,
                0x82, 0x03, 0x5D, 0x30, 0x82, 0x03, 0x59, 0x02, 0x01, 0x01, 0x31, 0x00, 0x30, 0x0F, 0x06, 0x09,
                0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x07, 0x01, 0xA0, 0x02, 0x04, 0x00, 0xA0, 0x82, 0x03,
                0x3D, 0x30, 0x82, 0x03, 0x39, 0x30, 0x82, 0x02, 0x21, 0xA0, 0x03, 0x02, 0x01, 0x02, 0x02, 0x05,
                0x34, 0x00, 0x00, 0x00, 0x07, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01,
                0x01, 0x0B, 0x05, 0x00, 0x30, 0x41, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55, 0x04, 0x06, 0x13,
                0x02, 0x55, 0x53, 0x31, 0x15, 0x30, 0x13, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13, 0x0C, 0x54, 0x52,
                0x33, 0x34, 0x20, 0x53, 0x61, 0x6D, 0x70, 0x6C, 0x65, 0x73, 0x31, 0x1B, 0x30, 0x19, 0x06, 0x03,
                0x55, 0x04, 0x03, 0x13, 0x12, 0x54, 0x52, 0x33, 0x34, 0x20, 0x53, 0x61, 0x6D, 0x70, 0x6C, 0x65,
                0x20, 0x43, 0x41, 0x20, 0x4B, 0x52, 0x44, 0x30, 0x1E, 0x17, 0x0D, 0x31, 0x30, 0x31, 0x31, 0x30,
                0x32, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x5A, 0x17, 0x0D, 0x32, 0x30, 0x31, 0x30, 0x32, 0x39,
                0x32, 0x33, 0x35, 0x39, 0x35, 0x39, 0x5A, 0x30, 0x40, 0x31, 0x0B, 0x30, 0x09, 0x06, 0x03, 0x55,
                0x04, 0x06, 0x13, 0x02, 0x55, 0x53, 0x31, 0x15, 0x30, 0x13, 0x06, 0x03, 0x55, 0x04, 0x0A, 0x13,
                0x0C, 0x54, 0x52, 0x33, 0x34, 0x20, 0x53, 0x61, 0x6D, 0x70, 0x6C, 0x65, 0x73, 0x31, 0x1A, 0x30,
                0x18, 0x06, 0x03, 0x55, 0x04, 0x03, 0x13, 0x11, 0x54, 0x52, 0x33, 0x34, 0x20, 0x53, 0x61, 0x6D,
                0x70, 0x6C, 0x65, 0x20, 0x4B, 0x52, 0x44, 0x20, 0x31, 0x30, 0x82, 0x01, 0x22, 0x30, 0x0D, 0x06,
                0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00, 0x03, 0x82, 0x01, 0x0F,
                0x00, 0x30, 0x82, 0x01, 0x0A, 0x02, 0x82, 0x01, 0x01, 0x00, 0xD4, 0x5C, 0x30, 0xCB, 0x6F, 0xBB,
                0x1D, 0x39, 0x4C, 0xE5, 0xA8, 0x7B, 0x49, 0xDB, 0x6D, 0xCF, 0x14, 0x34, 0xB0, 0xFA, 0x4E, 0x0A,
                0xA3, 0x71, 0xF8, 0x50, 0xEE, 0x8B, 0xAE, 0x7F, 0x2D, 0xC3, 0xC5, 0x48, 0xD5, 0x1C, 0xBD, 0xA3,
                0xDD, 0x01, 0xF0, 0xD6, 0x55, 0x3B, 0xFB, 0x79, 0x85, 0x1E, 0x73, 0x15, 0x43, 0x98, 0x4B, 0x22,
                0xE3, 0x62, 0xB4, 0xFC, 0x1D, 0xD3, 0xD6, 0xDE, 0x82, 0x37, 0x7D, 0x20, 0x13, 0x2C, 0xC6, 0x39,
                0x65, 0xDD, 0x0A, 0xD2, 0xDD, 0x68, 0x9E, 0x98, 0x52, 0x91, 0x61, 0x35, 0x40, 0xF3, 0x0E, 0x75,
                0xA5, 0x58, 0xF9, 0x15, 0xB2, 0xE9, 0xE4, 0x0D, 0xD4, 0x21, 0xCA, 0xC6, 0xBD, 0xB7, 0x45, 0x90,
                0xF4, 0x42, 0x8A, 0xB4, 0x68, 0x4E, 0xCB, 0x42, 0x94, 0xD3, 0xBA, 0xD2, 0x12, 0xF6, 0x66, 0x22,
                0x00, 0xEE, 0xF7, 0xDD, 0xC3, 0x01, 0x31, 0x6F, 0xBA, 0x67, 0x6B, 0x71, 0x20, 0xFB, 0x91, 0x89,
                0x3C, 0x2B, 0xA3, 0x11, 0xA8, 0x4F, 0x73, 0xAF, 0x21, 0x63, 0xB5, 0x60, 0x44, 0x05, 0xFD, 0x76,
                0x0B, 0xB1, 0x52, 0x68, 0x9C, 0xF5, 0x20, 0x4F, 0x20, 0xCB, 0xBD, 0x97, 0x62, 0x3B, 0x5D, 0xB9,
                0x6C, 0xCF, 0x6B, 0xA3, 0x82, 0x6A, 0xC3, 0x87, 0x90, 0xD3, 0xC2, 0xC6, 0x6C, 0xD7, 0xEB, 0xFD,
                0x5C, 0x9F, 0x1E, 0x70, 0xCB, 0xC7, 0x7F, 0x55, 0x8F, 0x95, 0x50, 0x1A, 0x9A, 0x9C, 0xB4, 0xAB,
                0x3D, 0xFD, 0xA2, 0x65, 0xD0, 0x10, 0xA4, 0x9A, 0xB7, 0x02, 0xA0, 0x01, 0x5D, 0xF0, 0xF6, 0xE0,
                0x8D, 0x0C, 0xE3, 0x63, 0x30, 0x64, 0x1C, 0x4D, 0xC7, 0x5E, 0xA8, 0xFE, 0x7D, 0xD5, 0xEA, 0x6B,
                0x37, 0xBD, 0x64, 0x32, 0x85, 0x77, 0xF8, 0x55, 0x0D, 0x3F, 0x01, 0x5A, 0xA5, 0x6F, 0x1A, 0xB5,
                0xF2, 0x5E, 0x55, 0xF5, 0x93, 0x40, 0xAF, 0x53, 0xF9, 0x55, 0x02, 0x03, 0x01, 0x00, 0x01, 0xA3,
                0x39, 0x30, 0x37, 0x30, 0x09, 0x06, 0x03, 0x55, 0x1D, 0x13, 0x04, 0x02, 0x30, 0x00, 0x30, 0x1D,
                0x06, 0x03, 0x55, 0x1D, 0x0E, 0x04, 0x16, 0x04, 0x14, 0x0D, 0x72, 0x05, 0x3C, 0xA9, 0x82, 0xE2,
                0xC1, 0x89, 0xCE, 0x47, 0x20, 0x50, 0xD3, 0x4D, 0x04, 0x5A, 0x9A, 0x59, 0xD3, 0x30, 0x0B, 0x06,
                0x03, 0x55, 0x1D, 0x0F, 0x04, 0x04, 0x03, 0x02, 0x04, 0x30, 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86,
                0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x0B, 0x05, 0x00, 0x03, 0x82, 0x01, 0x01, 0x00, 0x0D, 0x9E,
                0xD3, 0x9C, 0x97, 0xD2, 0xE1, 0x7B, 0xF0, 0x71, 0x34, 0xDB, 0x40, 0xBA, 0x1A, 0x4A, 0xCE, 0xD7,
                0x2A, 0xD6, 0x8F, 0xD5, 0x19, 0xDE, 0x3E, 0x22, 0xF9, 0xB8, 0xCB, 0x6A, 0x51, 0x80, 0x5B, 0x5F,
                0xCD, 0x43, 0x8F, 0x1C, 0x73, 0x09, 0x7E, 0x69, 0x99, 0xF0, 0x5C, 0xC0, 0x6F, 0xBC, 0x7B, 0xF2,
                0x3F, 0xCB, 0x12, 0x41, 0x12, 0x8E, 0x0A, 0x79, 0xD7, 0x93, 0x51, 0x60, 0x06, 0x85, 0x18, 0xD1,
                0x8A, 0x65, 0x30, 0xFB, 0x48, 0x63, 0x37, 0xC9, 0x7F, 0x0C, 0xAD, 0x71, 0x8C, 0xA1, 0xDC, 0x24,
                0x81, 0xF2, 0x1C, 0x1F, 0x7D, 0xE0, 0x3E, 0xC5, 0x6B, 0x12, 0xCE, 0xA8, 0x2B, 0xC8, 0x1E, 0xBD,
                0xF4, 0x94, 0x42, 0x75, 0x6F, 0xF3, 0xDA, 0x99, 0x2D, 0x28, 0xC1, 0x44, 0x57, 0x47, 0xAB, 0x10,
                0x21, 0xF1, 0xC1, 0x4F, 0xFE, 0x43, 0xD0, 0x85, 0x28, 0xE6, 0x68, 0xE0, 0x40, 0x6D, 0xFF, 0x50,
                0x0D, 0x55, 0x5D, 0x82, 0x3B, 0x9F, 0x0B, 0x51, 0xC4, 0xBB, 0xDB, 0x47, 0xC6, 0xF1, 0x7B, 0x30,
                0x27, 0x47, 0x9B, 0x5C, 0x8B, 0xE4, 0x48, 0x42, 0x76, 0xED, 0x0B, 0x71, 0xCD, 0xAD, 0xC1, 0xC2,
                0x49, 0x46, 0xB6, 0xD1, 0x86, 0x46, 0x8C, 0x85, 0x74, 0xE3, 0xB8, 0xD1, 0xEA, 0x15, 0x1F, 0xD8,
                0x94, 0x22, 0x1B, 0xDB, 0xF4, 0xC2, 0xE7, 0x3C, 0x94, 0x05, 0xD7, 0x95, 0xE7, 0xB7, 0xFD, 0xE2,
                0x19, 0x9A, 0xE3, 0x31, 0x76, 0xD3, 0xAE, 0x72, 0xAD, 0xA8, 0x0D, 0x95, 0x10, 0x20, 0x4F, 0x0C,
                0x87, 0x05, 0x77, 0xB7, 0xF7, 0x52, 0xDC, 0x47, 0x9B, 0x29, 0xD5, 0x01, 0x21, 0x39, 0x1C, 0xCF,
                0xCA, 0x81, 0x78, 0xC8, 0x6B, 0x1A, 0xAD, 0x76, 0x9B, 0x58, 0x4E, 0x68, 0x17, 0xE1, 0x62, 0xB0,
                0x5A, 0x31, 0x19, 0x30, 0xF8, 0xA4, 0xF1, 0xDD, 0xD7, 0x52, 0x74, 0x20, 0xD7, 0xB1, 0x31, 0x00
            };

            return new ExportCertificateResult(MessagePayload.CompletionCodeEnum.Success,
                                               certificate);
        }

        /// <summary>
        /// This command is used to replace the existing primary or secondary Certificate Authority certificate already loaded into the KeyManagement.
        /// This operation must be done by an Initial Certificate Authority or by a Sub-Certificate Authority.
        /// These operations will replace either the primary or secondary Certificate Authority public verification key inside of the KeyManagement.
        /// After this command is complete, the application should send the LoadCertificate and GetCertificate commands to ensure that the new HOST and the encryptor have all the information required to perform the remote key loading process.
        /// </summary>
        public async Task<ReplaceCertificateResult> ReplaceCertificate(ReplaceCertificateRequest request,
                                                                       CancellationToken cancellation)
        {
            if (KeyManagementStatus.CertificateState == KeyManagementStatusClass.CertificateStateEnum.NotReady ||
                KeyManagementStatus.CertificateState == KeyManagementStatusClass.CertificateStateEnum.Unknown)
            {
                return new ReplaceCertificateResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                                    $"Invalid certification state. {KeyManagementStatus.CertificateState}",
                                                    ReplaceCertificateCompletion.PayloadData.ErrorCodeEnum.InvalidCertificateState);
            }

            await Task.Delay(200, cancellation);

            List<byte> digest = new()
            {
                0xA2, 0x7A, 0xCC, 0x48, 0xDF, 0x26, 0x6D, 0x1B, 0xCB, 0x0B, 0x56, 0x76, 0x05, 0x9B, 0xDB, 0x9B,
                0x7B, 0x38, 0xCA, 0xA4, 0xBA, 0x39, 0x9B, 0xCB, 0x4F, 0x58, 0x4A, 0x99, 0x85, 0x99, 0x69, 0x7D
            };
            return new ReplaceCertificateResult(MessagePayload.CompletionCodeEnum.Success,
                                                digest);
        }

        /// <summary>
        /// This command is used to start communication with the host, including transferring the host's Key Transport Key, 
        /// replacing the Host certificate, and requesting initialization remotely. 
        /// This output value is returned to the host and is used in the ImportKey and LoadCertificate to verify that the encryptor is talking to the proper host.
        /// The ImportKey command end the key exchange process.
        /// </summary>
        public async Task<StartKeyExchangeResult> StartKeyExchange(CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            return new StartKeyExchangeResult(MessagePayload.CompletionCodeEnum.Success, GenerateRandomNumber());
        }


        /// <summary>
        /// This command is used to load a host certificate to make remote key loading possible. 
        /// This command can be used to load a host certificate when there is not already one present in the encryptor as well as replace the existing host certificate with a new host certificate.
        /// The type of certificate (Primary or Secondary) to be loaded will be embedded within the actual certificate structure.
        /// </summary>
        public async Task<ImportCertificateResult> ImportCertificate(ImportCertificateRequest request,
                                                                     CancellationToken cancellation)
        {
            if (request.Certificate is null || request.Certificate.Count == 0)
            {
                return new ImportCertificateResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                                   $"No certificate specified.");
            }

            bool validvalidOption = false;
            foreach (var option in KeyManagementCapabilities.LoadCertificationOptions)
            {
                if (request.Signer == ImportCertificateRequest.SignerEnum.CA &&
                    option.Signer == KeyManagementCapabilitiesClass.LoadCertificateSignerEnum.CA ||
                    request.Signer == ImportCertificateRequest.SignerEnum.HL &&
                    option.Signer == KeyManagementCapabilitiesClass.LoadCertificateSignerEnum.HL ||
                    request.Signer == ImportCertificateRequest.SignerEnum.Host &&
                    option.Signer == KeyManagementCapabilitiesClass.LoadCertificateSignerEnum.CertHost)
                {
                    if (request.LoadOption == ImportCertificateRequest.LoadOptionEnum.NewHost && option.Option.HasFlag(KeyManagementCapabilitiesClass.LoadCertificateOptionEnum.NewHost) ||
                        request.LoadOption == ImportCertificateRequest.LoadOptionEnum.ReplaceHost && option.Option.HasFlag(KeyManagementCapabilitiesClass.LoadCertificateOptionEnum.ReplaceHost))
                    {
                        validvalidOption = true;
                        break;
                    }
                }
            }

            if (!validvalidOption)
            {
                return new ImportCertificateResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                                   $"Specified signer or option is not supported. {request.Signer}, or {request.LoadOption}");
            }

            await Task.Delay(200, cancellation);

            List<byte> digest = new()
            {
                0xFD, 0x77, 0x17, 0xC0, 0x3D, 0xAB, 0x76, 0x5C, 0x54, 0x7E, 0xF3, 0x53, 0x41, 0x00, 0xCD, 0x04,
                0x04, 0xE9, 0xB0, 0xBF, 0x71, 0x05, 0xE9, 0xAE, 0x50, 0xC0, 0x81, 0x75, 0xA1, 0x8B, 0x92, 0x62
            };
            return new ImportCertificateResult(MessagePayload.CompletionCodeEnum.Success,
                                               ImportCertificateResult.RSAKeyCheckModeEnum.SHA256,
                                               digest);
        }

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
            RSAKeyCheckMode: KeyManagementCapabilitiesClass.RSAKeyCheckModeEnum.SHA1 | KeyManagementCapabilitiesClass.RSAKeyCheckModeEnum.SHA256,
            SignatureScheme: KeyManagementCapabilitiesClass.SignatureSchemeEnum.ExportEPPID | KeyManagementCapabilitiesClass.SignatureSchemeEnum.RandomNumber | KeyManagementCapabilitiesClass.SignatureSchemeEnum.EnhancedRKL,
            EMVImportSchemes: KeyManagementCapabilitiesClass.EMVImportSchemeEnum.NotSupported,
            KeyBlockImportFormats: KeyManagementCapabilitiesClass.KeyBlockImportFormatEmum.KEYBLOCKA | KeyManagementCapabilitiesClass.KeyBlockImportFormatEmum.KEYBLOCKB | KeyManagementCapabilitiesClass.KeyBlockImportFormatEmum.KEYBLOCKC,
            KeyImportThroughParts: true,
            DESKeyLength: KeyManagementCapabilitiesClass.DESKeyLengthEmum.Double,
            CertificateTypes: KeyManagementCapabilitiesClass.CertificateTypeEnum.HostKey | KeyManagementCapabilitiesClass.CertificateTypeEnum.EncKey | KeyManagementCapabilitiesClass.CertificateTypeEnum.VerificationKey,
            LoadCertificationOptions: new()
            {
                new KeyManagementCapabilitiesClass.SingerCapabilities(KeyManagementCapabilitiesClass.LoadCertificateSignerEnum.CA, KeyManagementCapabilitiesClass.LoadCertificateOptionEnum.NewHost, false)
            },
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

        #region Crypto interface
        /// <summary>
        /// This command is used to generate a random number. 
        /// </summary>
        public async Task<GenerateRandomNumberResult> GenerateRandomNumber(CancellationToken cancellation)
        {
            await Task.Delay(200, cancellation);

            return new GenerateRandomNumberResult(MessagePayload.CompletionCodeEnum.Success, GenerateRandomNumber());
        }

        /// <summary>
        /// The input data is either encrypted or decrypted using the specified or selected encryption mode.
        /// The input datais padded to the necessary length mandated by the encryption algorithm using the padding parameter. 
        /// This inputdata is padded to necessary length mandated by the signature algorithm using padding parameter.
        /// Applications canuse an alternative padding method by pre-formatting the data passed and combining this with the standard padding method.
        /// The start value (or Initialization Vector) can be provided as input data to this command, or it can beimported via TR-31 prior to requesting this command and referenced by name.
        /// The start value and start value keyare both optional parameters.
        /// </summary>
        public async Task<CryptoDataResult> Crypto(CryptoCommandEvents events,
                                                   CryptoDataRequest request,
                                                   CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            if (request.Mode != CryptoDataRequest.CryptoModeEnum.Encrypt)
            {
                return new CryptoDataResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                            $"Smaple SP only supports encryption.",
                                            CryptoDataCompletion.PayloadData.ErrorCodeEnum.ModeOfUseNotSupported);
            }

            Dictionary<string, LoadedKeyInfo> keysLoaded = GetKeys();
            if (!keysLoaded.ContainsKey(request.KeyName))
            {
                return new CryptoDataResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                            $"Key not found {request.KeyName}",
                                            CryptoDataCompletion.PayloadData.ErrorCodeEnum.KeyNotFound);
            }

            try
            {
                TripleDES tDESEncrypt = new TripleDESCryptoServiceProvider
                {
                    Mode = CipherMode.ECB,
                    Key = keysLoaded[request.KeyName].KeyData.ToArray()
                };
                ICryptoTransform transForm = tDESEncrypt.CreateEncryptor();
                MemoryStream memStream = new();
                CryptoStream cryptoStream = new(memStream, transForm, CryptoStreamMode.Write);
                cryptoStream.Write(request.Data.ToArray(), 0, request.Data.Count);
                cryptoStream.FlushFinalBlock();

                return new CryptoDataResult(MessagePayload.CompletionCodeEnum.Success,
                                            memStream.ToArray().ToList());
            }
            catch (CryptographicException ex)
            {
                return new CryptoDataResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                            $"Excryption failed. {ex.Message}",
                                            CryptoDataCompletion.PayloadData.ErrorCodeEnum.AccessDenied);
            }
        }

        /// <summary>
        /// This command can be used for asymmetric signature generation.
        /// This input data is padded to necessary length mandated by the signature algorithm using padding parameter.
        /// Applications can use an alternative padding method by pre-formatting the data passed and combining this withthe standard padding method. 
        /// </summary>
        public async Task<GenerateAuthenticationDataResult> GenerateSignature(CryptoCommandEvents events,
                                                                              GenerateSignatureRequest request,
                                                                              CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            RSACryptoServiceProvider rsaServiceProvider = null;

            try
            {
                rsaServiceProvider = new(new CspParameters()
                {
                    Flags = CspProviderFlags.UseExistingKey,
                    KeyContainerName = request.KeyName
                });
            }
            catch (Exception)
            { }

            if (rsaServiceProvider is null)
            {
                return new GenerateAuthenticationDataResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                                            $"Requested key exist. {request.KeyName}",
                                                            GenerateAuthenticationCompletion.PayloadData.ErrorCodeEnum.KeyNotFound);
            }

            return new GenerateAuthenticationDataResult(MessagePayload.CompletionCodeEnum.Success,
                                                        rsaServiceProvider.SignHash(request.Data.ToArray(), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1).ToList());
        }

        /// This command can be used for Message Authentication Code generation (i.e. macing).
        /// The input data ispadded to the necessary length mandated by the encryption algorithm using the padding parameter.
        public async Task<GenerateAuthenticationDataResult> GenerateMAC(CryptoCommandEvents events,
                                                                        GenerateMACRequest request,
                                                                        CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            return new GenerateAuthenticationDataResult(MessagePayload.CompletionCodeEnum.Success, GenerateRandomNumber());
        }

        /// <summary>
        /// This command can be used for signature verification.
        /// This input data is padded to necessarylength mandated by the signature algorithm using padding parameter.
        /// Applications can use an alternative paddingmethod by pre-formatting the data passed and combining this with the standard padding method.
        /// The start value (orInitialization Vector) can be provided as input data to this command, or it can be imported via TR-31 prior to requesting this command and referenced by name. 
        /// The start value and start value key are both optional parameters.
        /// </summary>
        public async Task<VerifyAuthenticationDataResult> VerifySignature(CryptoCommandEvents events,
                                                                          VerifySignatureRequest request,
                                                                          CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            RSACryptoServiceProvider rsaServiceProvider = null;

            try
            {
                rsaServiceProvider = new(new CspParameters()
                {
                    Flags = CspProviderFlags.UseExistingKey,
                    KeyContainerName = request.KeyName
                });
            }
            catch (Exception)
            { }

            if (rsaServiceProvider is null)
            {
                return new VerifyAuthenticationDataResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                                          $"Requested key exist. {request.KeyName}",
                                                          VerifyAuthenticationCompletion.PayloadData.ErrorCodeEnum.KeyNotFound);
            }

            bool verified = rsaServiceProvider.VerifyData(request.Data.ToArray(), HashAlgorithmName.SHA256, request.VerificationData.ToArray());

            return verified ? new VerifyAuthenticationDataResult(MessagePayload.CompletionCodeEnum.Success) :
                              new VerifyAuthenticationDataResult(MessagePayload.CompletionCodeEnum.CommandErrorCode,
                                                                 $"Supplied signature data failed to verify",
                                                                 VerifyAuthenticationCompletion.PayloadData.ErrorCodeEnum.SignatureInvalid);
        }

        /// This command can be used for MAC verification.
        /// The input data is padded to the necessary length mandated by the encryption algorithm using the padding parameter.
        public async Task<VerifyAuthenticationDataResult> VerifyMAC(CryptoCommandEvents events,
                                                                    VerifyMACRequest request,
                                                                    CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            return new VerifyAuthenticationDataResult(MessagePayload.CompletionCodeEnum.Success);
        }

        /// <summary>
        /// This command is used to compute a hash code on a stream of data using the specified hash algorithm. 
        /// This command can be used to verify EMV static and dynamic data.
        /// </summary>
        public async Task<GenerateDigestResult> GenerateDigest(GenerateDigestRequest request,
                                                               CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);

            if (request.Hash == HashAlgorithmEnum.SHA256)
            {
                return new GenerateDigestResult(MessagePayload.CompletionCodeEnum.InvalidData,
                                                ErrorDescription: $"SHA1 is not supported.");
            }
            return new GenerateDigestResult(MessagePayload.CompletionCodeEnum.Success,
                                            new SHA256CryptoServiceProvider().ComputeHash(request.DataToHash.ToArray()).ToList());
        }

        /// <summary>
        /// This command is used to retrieve the data that needs to be signed and hence provided to the Authenticate command in order to perform an authenticated action on the device.
        /// If this command returns data to be signed then the Authenticate command must be used to call the command referenced by the payload.
        /// Any attempt to call the referenced command without using the Authenticate command, if authentication is required, 
        /// shall result in AuthRequired. 
        /// </summary>
        public async Task<StartAuthenticateResult> StartAuthenticate(StartAuthenticateRequest request,
                                                                     CancellationToken cancellation)
        {
            await Task.Delay(100, cancellation);
            return new StartAuthenticateResult(MessagePayload.CompletionCodeEnum.Success, GenerateRandomNumber(), AuthenticationData.SigningMethodEnum.CertHost);
        }

        /// <summary>
        /// RunAync
        /// Handle unsolic events
        /// Here is an example of handling MediaRemovedEvent after card is ejected successfully.
        /// </summary>
        /// <returns></returns>
        public async Task RunAsync()
        {
            for (; ; )
            {
                await initializedSignal?.WaitAsync();
                await cryptoServiceProvider.InitializedEvent();
            }
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
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Capabilities,
                        CommonCapabilitiesClass.CommonInterfaceClass.CommandEnum.Status
                    }
                ),
                KeyManagementInterface: new CommonCapabilitiesClass.KeyManagementInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.DeleteKey,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.ExportRSAEPPSignedItem,
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
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.EventEnum.CertificateChangeEvent,
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.EventEnum.InitializedEvent,
                    },
                    AuthenticationRequired: new()
                    {
                        CommonCapabilitiesClass.KeyManagementInterfaceClass.CommandEnum.Initialization,
                    }
                ),
                CryptoInterface: new CommonCapabilitiesClass.CryptoInterfaceClass
                (
                    Commands: new()
                    {
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.CryptoData,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.Digest,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.GenerateAuthentication,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.GenerateRandom,
                        CommonCapabilitiesClass.CryptoInterfaceClass.CommandEnum.VerifyAuthentication,
                    },
                    Events: new()
                    {
                        CommonCapabilitiesClass.CryptoInterfaceClass.EventEnum.IllegalKeyAccessEvent,
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
            var bytes = new byte[Constants.RandomNumberLength];
            new Random().NextBytes(bytes);

            return bytes.ToList();
        }

        private class LoadedKeyInfo
        {
            public enum AlgorithmKeyEnum
            {
                TDES
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
            string data;

            try
            {
                data = JsonSerializer.Serialize(obj);
                if (string.IsNullOrEmpty(data))
                    return false;
            }
            catch (Exception ex)
            {
                Logger.Warning(nameof(EncryptorSample), $"Exception caught on serializing persistent data. {ex.Message}");
                return false;
            }

            // The data is serialized and stored it on the file system
            try
            {
                File.WriteAllText(Constants.PERSIT, data);
            }
            catch (Exception ex)
            {
                Logger.Warning(nameof(EncryptorSample), $"Exception caught on writing data. {Constants.PERSIT}, {ex.Message}");
                return false;
            }

            return true;
        }

        private Dictionary<string, LoadedKeyInfo> GetKeys()
        {
            // Load serialized data from the file system
            string data;
            try
            {
                data = File.ReadAllText(Constants.PERSIT);
            }
            catch (Exception ex)
            {
                Logger.Warning(nameof(EncryptorSample), $"Exception caught on reading persistent data. {Constants.PERSIT}, {ex.Message}");
                return new Dictionary<string, LoadedKeyInfo>();
            }

            Dictionary<string, LoadedKeyInfo> value;
            // Unserialize read data
            try
            {
                value = JsonSerializer.Deserialize<Dictionary<string, LoadedKeyInfo>>(data);
            }
            catch (Exception ex)
            {
                Logger.Warning(nameof(EncryptorSample), $"Exception caught on unserializing persistent data. {ex.Message}");
                return null;
            }

            return value;
        }

        public XFS4IoTServer.IServiceProvider SetServiceProvider 
        { 
            get { return cryptoServiceProvider;  } 
            set 
            {
                value.IsA<CryptoServiceProvider>($"Unexpected type is set to the SetServiceProvider property.");
                cryptoServiceProvider = value as CryptoServiceProvider;
                if (serviceInitialized)
                    return;

                List<string> preLoadedKeys = new() { Constants.EPPVendorKeyName, Constants.EPPVendorSigKeyName };
                foreach (var keyName in preLoadedKeys)
                {
                    RSACryptoServiceProvider rsaServiceProvider = new(new CspParameters()
                    {
                        KeyContainerName = keyName
                    });

                    if (cryptoServiceProvider.GetKeyDetail(keyName) is null)
                    {
                        cryptoServiceProvider.AddKey(keyName,
                                                     cryptoServiceProvider.FindKeySlot(keyName),
                                                     "S0",
                                                     "R",
                                                     keyName switch
                                                     {
                                                        Constants.EPPVendorKeyName =>"V",
                                                        _ => "T"
                                                     },
                                                     rsaServiceProvider.KeySize,
                                                     KeyDetail.KeyStatusEnum.Loaded,
                                                     true,
                                                     string.Empty,
                                                     "00",
                                                     "S");
                    }
                }

                Dictionary<string, LoadedKeyInfo> keys = GetKeys();
                keys.Clear();
                StoreKeys(keys);

                List<byte> keyData = new() { 0xa1, 0xbb, 0x92, 0x1f, 0xbc, 0x72, 0x88, 0x05, 0xf2, 0x18, 0x5f, 0x2a, 0x56, 0x10, 0x1d, 0x29 };
                keys.Add(Constants.MasterKeyName, new(Constants.MasterKeyName, LoadedKeyInfo.AlgorithmKeyEnum.TDES, keyData));
                StoreKeys(keys);

                if (cryptoServiceProvider.GetKeyDetail(Constants.MasterKeyName) is null)
                {
                    cryptoServiceProvider.AddKey(Constants.MasterKeyName,
                                                 cryptoServiceProvider.FindKeySlot(Constants.MasterKeyName),
                                                 "K0",
                                                 "T",
                                                 "B",
                                                 keyData.Count,
                                                 KeyDetail.KeyStatusEnum.Loaded,
                                                 true,
                                                 string.Empty,
                                                 "00",
                                                 "S");
                }

                serviceInitialized = true;
            } 
        }

        private ILogger Logger { get; }

        private readonly SemaphoreSlim initializedSignal = new(0, 1);
        private CryptoServiceProvider cryptoServiceProvider = null;
        private bool serviceInitialized = false;

        private static class Constants
        {
            public const int RandomNumberLength = 8;
            public const string EPPUID = "KAL18593";
            public const string EPPVendorKeyName = "EPPVendorVerify";
            public const string EPPVendorSigKeyName = "EPPVendorSign";
            public const string MasterKeyName = "MASTERKEY";
            public const string PERSIT = "PersistKeys";
        }
    }
}
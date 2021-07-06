/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System.Threading;

using XFS4IoTFramework.CardReader;

namespace KAL.XFS4IoTSP.CardReader.Sample
{
    public interface ICardReaderDeviceSync : IDeviceSync
    {
        DeviceTypeEnum DeviceType   { get; }

        MediaStatusEnum MediaStatus { get; }

        AcceptCardResult AcceptCardSync(IAcceptCardEvents events, AcceptCardRequest acceptCardInfo, CancellationToken cancellation);

        ReadCardResult ReadCardSync(IReadRawDataEvents events, ReadCardRequest dataToRead, CancellationToken cancellation);

        WriteCardResult WriteCardSync(IWriteRawDataEvents events, WriteCardRequest dataToWrite, CancellationToken cancellation);

        EjectCardResult EjectCardSync(EjectCardRequest ejectCardInfo, CancellationToken cancellation);

        CaptureCardResult CaptureCardSync(IRetainCardEvents events, CancellationToken cancellation);

        ChipIOResult ChipIOSync(ChipIORequest dataToSend, CancellationToken cancellation);

        ResetDeviceResult ResetDeviceSync(IResetEvents events, ResetDeviceRequest cardAction, CancellationToken cancellation);

        ResetCountResult ResetBinCountSync(CancellationToken cancellation);

        SetCIM86KeyResult SetCIM86KeySync(SetCIM86KeyRequest keyInfo, CancellationToken cancellation);

        ChipPowerResult ChipPowerSync(IChipPowerEvents events, ChipPowerRequest action, CancellationToken cancellation);

        ParkCardResult ParkCardSync(ParkCardRequest parkCardInfo, CancellationToken cancellation);

        EMVContactlessConfigureResult EMVContactlessConfigureSync(EMVContactlessConfigureRequest terminalConfig, CancellationToken cancellation);

        EMVContactlessPerformTransactionResult EMVContactlessPerformTransactionSync(IEMVClessPerformTransactionEvents events, EMVContactlessPerformTransactionRequest transactionData, CancellationToken cancellation);

        EMVContactlessIssuerUpdateResult EMVContactlessIssuerUpdateSync(IEMVClessIssuerUpdateEvents events, EMVContactlessIssuerUpdateRequest transactionData, CancellationToken cancellation);

        QueryIFMIdentifierResult QueryIFMIdentifier();

        QueryEMVApplicationResult EMVContactlessQueryApplications();
    }
}
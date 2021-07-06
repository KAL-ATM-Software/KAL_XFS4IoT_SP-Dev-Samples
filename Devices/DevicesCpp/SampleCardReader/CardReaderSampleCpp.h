#pragma once

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Threading;
using namespace System::Threading::Tasks;
using namespace System::Text;
using namespace System::Linq;
using namespace XFS4IoT;
using namespace XFS4IoTFramework::CardReader;
using namespace XFS4IoTFramework::Common;
using namespace XFS4IoT::Common;
using namespace XFS4IoT::Common::Commands;
using namespace XFS4IoT::Common::Completions;
using namespace XFS4IoT::CardReader;
using namespace XFS4IoT::CardReader::Events;
using namespace XFS4IoT::CardReader::Commands;
using namespace XFS4IoT::CardReader::Completions;
using namespace XFS4IoT::Completions;
using namespace XFS4IoTServer;

namespace KAL::XFS4IoTSP::CardReader::SampleCpp
{
    public ref class CardReaderSample : ICardReaderDevice, ICommonDevice
    {
    public: 
        CardReaderSample(ILogger^ Logger);
        virtual Task<AcceptCardResult^>^ AcceptCardAsync(IAcceptCardEvents^ events,  AcceptCardRequest^ acceptCardInfo, CancellationToken cancellation);

        virtual Task<ReadCardResult^>^ ReadCardAsync(IReadRawDataEvents^ events, ReadCardRequest^ dataToRead, CancellationToken cancellation);

        virtual Task<WriteCardResult^>^ WriteCardAsync(IWriteRawDataEvents^ events, WriteCardRequest^ dataToWrite, CancellationToken cancellation);

        virtual Task<EjectCardResult^>^ EjectCardAsync(EjectCardRequest^ ejectCardInfo, CancellationToken cancellation);

        virtual Task<ChipIOResult^>^ ChipIOAsync(ChipIORequest^ dataToSend, CancellationToken cancellation);

        virtual Task<ResetDeviceResult^>^ ResetDeviceAsync(IResetEvents^ events, ResetDeviceRequest^ cardAction, CancellationToken cancellation);

        virtual Task<ChipPowerResult^>^ ChipPowerAsync(IChipPowerEvents^ events, ChipPowerRequest^ action, CancellationToken cancellation);

        virtual Task<ParkCardResult^>^ ParkCardAsync(ParkCardRequest^ parkCardInfo, CancellationToken cancellation);

        virtual Task<EMVContactlessConfigureResult^>^ EMVContactlessConfigureAsync(EMVContactlessConfigureRequest^ terminalConfig, CancellationToken cancellation);

        virtual Task<EMVContactlessPerformTransactionResult^>^ EMVContactlessPerformTransactionAsync(IEMVClessPerformTransactionEvents^ events, EMVContactlessPerformTransactionRequest^ transactionData, CancellationToken cancellation);

        virtual Task<EMVContactlessIssuerUpdateResult^>^ EMVContactlessIssuerUpdateAsync(IEMVClessIssuerUpdateEvents^ events, EMVContactlessIssuerUpdateRequest^ transactionData, CancellationToken cancellation);

        virtual Task<CaptureCardResult^>^ CaptureCardAsync(IRetainCardEvents^ events, CancellationToken cancellation);

        virtual Task<ResetCountResult^>^ ResetBinCountAsync(CancellationToken cancellation);

        virtual Task<SetCIM86KeyResult^>^ SetCIM86KeyAsync(SetCIM86KeyRequest^ keyInfo, CancellationToken cancellation);

        virtual Task^ RunAsync();

        virtual QueryIFMIdentifierResult^ QueryIFMIdentifier();

        virtual QueryEMVApplicationResult^ EMVContactlessQueryApplications();

        virtual StatusCompletion::PayloadData^ Status();

        virtual CapabilitiesCompletion::PayloadData^ Capabilities();

        virtual Task<PowerSaveControlCompletion::PayloadData^>^ PowerSaveControl(PowerSaveControlCommand::PayloadData^ payload) { throw gcnew System::NotImplementedException(); }
        virtual Task<SynchronizeCommandCompletion::PayloadData^>^ SynchronizeCommand(SynchronizeCommandCommand::PayloadData^ payload) { throw gcnew System::NotImplementedException(); }
        virtual Task<SetTransactionStateCompletion::PayloadData^>^ SetTransactionState(SetTransactionStateCommand::PayloadData^ payload) { throw gcnew System::NotImplementedException(); }
        virtual GetTransactionStateCompletion::PayloadData^ GetTransactionState() { throw gcnew System::NotImplementedException(); }
        virtual Task<GetCommandRandomNumberResult^>^ GetCommandRandomNumber() { throw gcnew System::NotImplementedException(); }

        DeviceTypeEnum _DeviceType = DeviceTypeEnum::Motor;
        property DeviceTypeEnum DeviceType 
        {
            public: virtual DeviceTypeEnum get() { return _DeviceType; };
            private: void set(DeviceTypeEnum value) { _DeviceType = value; };
        }
        
        MediaStatusEnum _MediaStatus = MediaStatusEnum::Unknown;
        property MediaStatusEnum MediaStatus
        {
            public: virtual MediaStatusEnum get() { return _MediaStatus; };
            private: void set(MediaStatusEnum value) { _MediaStatus = value; };
        }

        XFS4IoTServer::IServiceProvider^ _SetServiceProvider = nullptr;
        property XFS4IoTServer::IServiceProvider^ SetServiceProvider
        {
            public: virtual XFS4IoTServer::IServiceProvider^ get() { return _SetServiceProvider; };
            public: virtual void set(XFS4IoTServer::IServiceProvider^ value) { _SetServiceProvider = value; };
        }

    private:
        void CardTakenThread();
        void FireMediaRemovedEvent(Task^);
        void RunAsyncHelper(Task^);

        // Internal variables
        int CapturedCount = 0;
        int CpMaxCaptureCount = 100;

        StatusClass::RetainBinEnum RetainBinStatus = StatusClass::RetainBinEnum::Ok;

        ILogger^ _Logger = nullptr;
        property ILogger^ Logger
        {
            virtual ILogger^ get() sealed { return _Logger; };
            void set(ILogger^ value) { _Logger = value; };
        }
        initonly SemaphoreSlim^ cardTakenSignal = gcnew SemaphoreSlim(0, 1);
    };
}
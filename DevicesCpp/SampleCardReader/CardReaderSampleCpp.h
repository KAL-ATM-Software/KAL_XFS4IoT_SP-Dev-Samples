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

namespace KAL::XFS4IoTSP::CardReader::Sample
{
    public ref class CardReaderSample : ICardReaderDeviceSync, ICommonDeviceSync
    {
    public: 
        CardReaderSample(ILogger^ Logger);
        virtual AcceptCardResult^ AcceptCardSync(IAcceptCardEvents^ events,  AcceptCardRequest^ acceptCardInfo, CancellationToken cancellation);

        virtual ReadCardResult^ ReadCardSync(IReadRawDataEvents^ events, ReadCardRequest^ dataToRead, CancellationToken cancellation);

        virtual WriteCardResult^ WriteCardSync(IWriteRawDataEvents^ events, WriteCardRequest^ dataToWrite, CancellationToken cancellation);

        virtual EjectCardResult^ EjectCardSync(EjectCardRequest^ ejectCardInfo, CancellationToken cancellation);

        virtual ChipIOResult^ ChipIOSync(ChipIORequest^ dataToSend, CancellationToken cancellation);

        virtual ResetDeviceResult^ ResetDeviceSync(IResetEvents^ events, ResetDeviceRequest^ cardAction, CancellationToken cancellation);

        virtual ChipPowerResult^ ChipPowerSync(IChipPowerEvents^ events, ChipPowerRequest^ action, CancellationToken cancellation);

        virtual ParkCardResult^ ParkCardSync(ParkCardRequest^ parkCardInfo, CancellationToken cancellation);

        virtual EMVContactlessConfigureResult^ EMVContactlessConfigureSync(EMVContactlessConfigureRequest^ terminalConfig, CancellationToken cancellation);

        virtual EMVContactlessPerformTransactionResult^ EMVContactlessPerformTransactionSync(IEMVClessPerformTransactionEvents^ events, EMVContactlessPerformTransactionRequest^ transactionData, CancellationToken cancellation);

        virtual EMVContactlessIssuerUpdateResult^ EMVContactlessIssuerUpdateSync(IEMVClessIssuerUpdateEvents^ events, EMVContactlessIssuerUpdateRequest^ transactionData, CancellationToken cancellation);

        virtual CaptureCardResult^ CaptureCardSync(IRetainCardEvents^ events, CancellationToken cancellation);

        virtual ResetCountResult^ ResetBinCountSync(CancellationToken cancellation);

        virtual SetCIM86KeyResult^ SetCIM86KeySync(SetCIM86KeyRequest^ keyInfo, CancellationToken cancellation);

        virtual void Run();

        virtual QueryIFMIdentifierResult^ QueryIFMIdentifier();

        virtual QueryEMVApplicationResult^ EMVContactlessQueryApplications();

        virtual StatusCompletion::PayloadData^ Status();

        virtual CapabilitiesCompletion::PayloadData^ Capabilities();

        virtual PowerSaveControlCompletion::PayloadData^ PowerSaveControl(PowerSaveControlCommand::PayloadData^ payload) { throw gcnew System::NotImplementedException(); }
        virtual SynchronizeCommandCompletion::PayloadData^ SynchronizeCommand(SynchronizeCommandCommand::PayloadData^ payload) { throw gcnew System::NotImplementedException(); }
        virtual SetTransactionStateCompletion::PayloadData^ SetTransactionState(SetTransactionStateCommand::PayloadData^ payload) { throw gcnew System::NotImplementedException(); }
        virtual GetTransactionStateCompletion::PayloadData^ GetTransactionState() { throw gcnew System::NotImplementedException(); }
        virtual GetCommandRandomNumberResult^ GetCommandRandomNumber() { throw gcnew System::NotImplementedException(); }

        DeviceTypeEnum _DeviceType = DeviceTypeEnum::Motor;
        property DeviceTypeEnum DeviceType 
        {
            public: virtual DeviceTypeEnum get() { return _DeviceType; };
            public: void set(DeviceTypeEnum value) { _DeviceType = value; };
        }
        
        MediaStatusEnum _MediaStatus = MediaStatusEnum::Unknown;
        property MediaStatusEnum MediaStatus
        {
            public: virtual MediaStatusEnum get() { return _MediaStatus; };
            public: void set(MediaStatusEnum value) { _MediaStatus = value; };
        }
        XFS4IoTServer::IServiceProvider^ _SetServiceProvider = nullptr;

        property XFS4IoTServer::IServiceProvider^ SetServiceProvider
        {
            public: virtual XFS4IoTServer::IServiceProvider^ get() { return _SetServiceProvider; };
            public: virtual void set(XFS4IoTServer::IServiceProvider^ value) { _SetServiceProvider = value; };
        }

    private:
        void CardTakenThread();

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
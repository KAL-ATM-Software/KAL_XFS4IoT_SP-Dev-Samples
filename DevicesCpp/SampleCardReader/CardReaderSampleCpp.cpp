/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
#include "pch.h"
#include "CardReaderSampleCpp.h"

namespace KAL::XFS4IoTSP::CardReader::Sample
{
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Logger"></param>
    CardReaderSample::CardReaderSample(ILogger^ Logger)
    {
        Contracts::Assert(Logger != nullptr, "Unexpected reference for the Logger in the CardReaderSample constructor.");
        this->Logger = Logger;
        MediaStatus = MediaStatusEnum::NotPresent;
    }

    //
    // CARDREADER interface
    //

    /// <summary>
    /// For motor driven card readers, the card unit checks whether a card has been inserted. 
    /// All specified tracks are read immediately if the device can read with the low level accept command and store read data in the device specific class and set data on the ReadCardData method call.
    /// If reading the chip is requested, the chip will be contacted and reset and the ATR (AnswerTo Reset) data will be read. 
    /// When this command completes the chip will be in contacted position. This command can also be used for an explicit cold reset of a previously contacted chip.
    /// This command should only be used for user cards and should not be used for permanently connected chips.
    /// If no card has been inserted, and for all other categories of card readers, the card unit waits for the period of time specified in the call for a card to be either inserted or pulled through.
    /// The InsertCardEvent will be generated when there is no card in the cardreader and the device is ready to accept a card.
    /// </summary>
    AcceptCardResult^ CardReaderSample::AcceptCardSync(IAcceptCardEvents^ events, AcceptCardRequest^ acceptCardInfo, CancellationToken cancellation)
    {
        if (acceptCardInfo->DataToRead != ReadCardRequest::CardDataTypesEnum::NoDataRead ||
            MediaStatus != MediaStatusEnum::Present)
        {
            events->InsertCardEvent()->Wait();
            Task::Delay(2000, cancellation)->Wait();
            events->MediaInsertedEvent()->Wait();
        }

        MediaStatus = MediaStatusEnum::Present;

        return gcnew AcceptCardResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<AcceptCardResult::ErrorCodeEnum>());
    }

    /// <summary>
    /// Read alltracks specified.
    /// All specified tracks are read immediately or 
    /// A security check via a security module(i.e. MM, CIM86) can be requested. If the security check fails however this should not stop valid data beingreturned.
    /// The response securityFail will be returned if the command specifies only security data to be read andthe security check could not be executed, in all other cases ok will be returned with the data field of theoutput parameter set to the relevant value including *hardwareError*.
    /// For non-motorized Card Readers which read track data on card exit, the invalidData error code is returned whena call to is made to read both track data and chip data.
    /// If the card unit is a latched dip unit then the device will latch the card when the chip card will be read, 
    /// The card will remain latched until a call to EjectCard is made.
    /// For contactless chip card readers a collision of two or more card signals may happen. 
    /// In this case, if the deviceis not able to pick the strongest signal, errorCardCollision will be returned.
    /// </summary>
    ReadCardResult^ CardReaderSample::ReadCardSync(IReadRawDataEvents^ events, ReadCardRequest^ dataToRead, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();

        MessagePayload::CompletionCodeEnum completionCode = MessagePayload::CompletionCodeEnum::InvalidData;

        Dictionary<ReadCardRequest::CardDataTypesEnum, ReadCardResult::CardData^>^ readData = gcnew Dictionary<ReadCardRequest::CardDataTypesEnum, ReadCardResult::CardData^>();
        List<ReadCardResult::CardData^>^ chipATR = gcnew List<ReadCardResult::CardData^>();

        if ((dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Track1) == ReadCardRequest::CardDataTypesEnum::Track1 ||            
            (dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Track2) == ReadCardRequest::CardDataTypesEnum::Track2 ||
            (dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Track3) == ReadCardRequest::CardDataTypesEnum::Track3 ||
            (dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Chip) == ReadCardRequest::CardDataTypesEnum::Chip)
        {
            if ((dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Track1) == ReadCardRequest::CardDataTypesEnum::Track1)
            {
                readData->Add(ReadCardRequest::CardDataTypesEnum::Track1,
                              gcnew ReadCardResult::CardData(ReadCardResult::CardData::DataStatusEnum::Ok,
                              gcnew List<Byte>(Encoding::UTF8->GetBytes("B1234567890123456^SMITH/JOHN.MR^020945852301200589800568000000"))));
            }
            if ((dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Track2) == ReadCardRequest::CardDataTypesEnum::Track2)
            {
                readData->Add(ReadCardRequest::CardDataTypesEnum::Track2,
                              gcnew ReadCardResult::CardData(ReadCardResult::CardData::DataStatusEnum::Ok,
                              gcnew List<Byte>(Encoding::UTF8->GetBytes("1234567890123456=0209458523012005898"))));
            }
            if ((dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Track3) == ReadCardRequest::CardDataTypesEnum::Track3)
            {
                readData->Add(ReadCardRequest::CardDataTypesEnum::Track3,
                              gcnew ReadCardResult::CardData(ReadCardResult::CardData::DataStatusEnum::Ok,
                              gcnew List<Byte>(Encoding::UTF8->GetBytes("011234567890123456==000667788903609640040000006200013010000020000098120209105123==00568000999999"))));
            }
            if ((dataToRead->DataToRead & ReadCardRequest::CardDataTypesEnum::Chip) == ReadCardRequest::CardDataTypesEnum::Chip)
            {
                List<Byte>^ BytesData = gcnew List<Byte>();
                BytesData->Add(0x3b);
                BytesData->Add(0x2a);
                BytesData->Add(0x00);
                BytesData->Add(0x80);
                BytesData->Add(0x65);
                BytesData->Add(0xa2);
                BytesData->Add(0x1);
                BytesData->Add(0x2);
                BytesData->Add(0x1);
                BytesData->Add(0x31);
                BytesData->Add(0x72);
                BytesData->Add(0xd6);
                BytesData->Add(0x43);

                chipATR->Add(gcnew ReadCardResult::CardData(ReadCardResult::CardData::DataStatusEnum::Ok, BytesData));
            }
            completionCode = MessagePayload::CompletionCodeEnum::Success;
        }

        return gcnew ReadCardResult(completionCode, readData, chipATR);
    }

    /// <summary>
    /// The device is ready to accept a card.
    /// The application must pass the magnetic stripe data in ASCII without any sentinels. 
    /// If the data passed in is too long. The invalidError error code will be returned.
    /// This procedure is followed by data verification.
    /// If power fails during a write the outcome of the operation will be vendor specific, there is no guarantee that thewrite will have succeeded.
    /// </summary>
    WriteCardResult^ CardReaderSample::WriteCardSync(IWriteRawDataEvents^ events,
                                                      WriteCardRequest^ dataToWrite,
                                                      CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();

        return gcnew WriteCardResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<WriteRawDataCompletion::PayloadData::ErrorCodeEnum>());
    }

    /// <summary>
    /// This command is only applicable to motor driven card readers and latched dip card readers.
    /// For motorized card readers the default operation is that the card is driven to the exit slot from where the usercan remove it.
    /// The card remains in position for withdrawal until either it is taken or another command is issuedthat moves the card.
    /// For latched dip readers, this command causes the card to be unlatched (if not already unlatched), enablingremoval.
    /// After successful completion of this command, a CardReader.MediaRemovedEvent is generated to inform the application when the card is taken.
    /// </summary>
    EjectCardResult^ CardReaderSample::EjectCardSync(EjectCardRequest^ ejectCardInfo,
                                                      CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();

        MediaStatus = MediaStatusEnum::Entering;

        Thread^ CardTakenEventThread = gcnew Thread(gcnew ThreadStart(this, &CardReaderSample::CardTakenThread));
        CardTakenEventThread->Start();

        return gcnew EjectCardResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<EjectCardCompletion::PayloadData::ErrorCodeEnum>());
    }

    /// <summary>
    /// Thread for simulate card taken event to be fired
    /// </summary>
    void CardReaderSample::CardTakenThread()
    {
        Thread::Sleep(5000);
        cardTakenSignal->Release();
    }

    /// <summary>
    /// This command is used to communicate with the chip.
    /// Transparent data is sent from the application to the chip andthe response of the chip is returned transparently to the application.
    /// The identification information e.g. ATR of the chip must be obtained before issuing this command. 
    /// The identification information for a user card or the Memory Card Identification (when available) must initially be obtained using CardReader.ReadRawData.
    /// The identification information for subsequentresets of a user card can be obtained using either CardReader.ReadRawDat or CardReader.ChipPower. 
    /// The ATR for permanent connected chips is always obtained through CardReader.ChipPower.
    /// For contactless chip card readers, applications need to specify which chip to contact with, as part of chipData, if more than one chip has been detected and multiple identification data has been returned by the CardReader.ReadRawData command.
    /// For contactless chip card readers a collision of two or more card signals may happen. 
    /// In this case, if the deviceis not able to pick the strongest signal, the cardCollision error code will be returned.
    /// </summary>
    ChipIOResult^ CardReaderSample::ChipIOSync(ChipIORequest^ dataToSend, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();

        List<Byte>^ chipData = gcnew List<Byte>;
        chipData->Add(0x90);
        chipData->Add(0x00);
        return gcnew ChipIOResult(MessagePayload::CompletionCodeEnum::Success, chipData);
    }

    /// <summary>
    /// This command is used by the application to perform a hardware reset which will attempt to return the card readerdevice to a known good state.
    /// This command does not over-ride a lock obtained by another application or service handle.
    /// If the device is a user ID card unit, the device will attempt to either retain, eject or will perform no action onany user cards found in the device as specified in the input parameter. 
    /// It may not always be possible to retain oreject the items as specified because of hardware problems. 
    /// If a user card is found inside the device the CardReader.MediaInsertedEvent will inform the application where card wasactually moved to.
    /// If no action is specified the user card will not be moved even if this means that the devicecannot be recovered.
    /// If the device is a permanent chip card unit, this command will power-off the chip.For devices with parking station capability there will be one MediaInsertedEvent for each card found.
    /// </summary>
    ResetDeviceResult^ CardReaderSample::ResetDeviceSync(IResetEvents^ events, ResetDeviceRequest^ cardAction, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();

        MediaStatus = MediaStatusEnum::NotPresent;

        return gcnew ResetDeviceResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<ResetCompletion::PayloadData::ErrorCodeEnum>());
    }

    /// <summary>
    /// This command handles the power actions that can be done on the chip.For user chips, this command is only used after the chip has been contacted for the first time using the[CardReader.ReadRawData](#cardreader.readrawdata) command. For contactless user chips, this command may be used todeactivate the contactless card communication.For permanently connected chip cards, this command is the only way to control the chip power.
    /// </summary>
    ChipPowerResult^ CardReaderSample::ChipPowerSync(IChipPowerEvents^ events, ChipPowerRequest^ action, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();
        return gcnew ChipPowerResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<ChipPowerCompletion::PayloadData::ErrorCodeEnum>());
    }

    /// <summary>
    /// This command is used to move a card that is present in the reader to a parking station.
    /// A parking station isdefined as an area in the ID card unit, which can be used to temporarily store the card while the device performs operations on another card. 
    /// This command is also used to move a card from the parking station to the read/write,chip I/O or transport position. 
    /// When a card is moved from the parking station to the read/write, chip I/O ortransport position parkOut, the read/write, chip I/O or transport position must not be occupied with anothercard, otherwise the error cardPresent will be returned.
    /// After moving a card to a parking station, another card can be inserted and read by calling, e.g.,CardReader.ReadRawData.
    /// Cards in parking stations will not be affected by any CardReader commands until they are removed from the parkingstation using this command, except for the CardReader.Reset command, which will move thecards in the parking stations as specified in its input as part of the reset action if possible.
    /// </summary>
    ParkCardResult^ CardReaderSample::ParkCardSync(ParkCardRequest^ parkCardInfo, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();
        return gcnew ParkCardResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<ParkCardCompletion::PayloadData::ErrorCodeEnum>());
    }

    /// <summary>
    /// This command is used to configure an intelligent contactless card reader before performing a contactlesstransaction.
    /// This command sets terminal related data elements, the list of terminal acceptable applications with associated application specific data and any encryption key data required for offline data authentication.
    /// This command should be used prior to CardReader.EMVClessPerformTransaction command. 
    /// It may be calledonce on application start up or when any of the configuration parameters require to be changed. 
    /// The configurationset by this command is persistent.This command should be called with a complete list of acceptable payment system applications as any previous configurations will be replaced.
    /// </summary>
    EMVContactlessConfigureResult^ CardReaderSample::EMVContactlessConfigureSync(EMVContactlessConfigureRequest^ terminalConfig, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();
        return gcnew EMVContactlessConfigureResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<EMVClessConfigureCompletion::PayloadData::ErrorCodeEnum>());
    }

    /// <summary>
    /// This command is used to enable an intelligent contactless card reader.
    /// The transaction will start as soon as thecard tap is detected.
    /// Based on the configuration of the contactless chip card and the reader device, this command could return dataformatted either as magnetic stripe information or as a set of BER-TLV encoded EMV tags.
    /// This command supports magnetic stripe emulation cards and EMV-like contactless cards but cannot be used on storagecontactless cards. 
    /// The latter must be managed using the CardReader.ReadRawData and CardReader.ChipIO commands.
    /// For specific payment system's card profiles an intelligent card reader could return a set of EMV tags along withmagnetic stripe formatted data. 
    /// In this case, two contactless card data structures will be returned, onecontaining the magnetic stripe like data and one containing BER-TLV encoded tags.
    /// If no card has been tapped, the contactless chip card reader waits for the period of time specified in the commandcall for a card to be tapped.
    /// For intelligent contactless card readers, any in-built audio/visual feedback such as Beep/LEDs, need to becontrolled directly by the reader. 
    /// These indications should be implemented based on the EMVCo and payment system'sspecifications.
    /// </summary>
    EMVContactlessPerformTransactionResult^ CardReaderSample::EMVContactlessPerformTransactionSync(IEMVClessPerformTransactionEvents^ events, EMVContactlessPerformTransactionRequest^ transactionData, CancellationToken cancellation)
    {
        events->EMVClessReadStatusEvent(gcnew EMVClessReadStatusEvent::PayloadData(100, EMVClessReadStatusEvent::PayloadData::StatusEnum::ReadyToRead, 0, EMVClessReadStatusEvent::PayloadData::ValueQualifierEnum::Amount, nullptr, nullptr, nullptr))->Wait();

        Task::Delay(1000, cancellation)->Wait();

        List<Byte>^ BytesData = gcnew List<Byte>(); 
        BytesData->Add(0x9c);
        BytesData->Add(0x1);
        BytesData->Add(0x0);
        BytesData->Add(0x9f);
        BytesData->Add(0x26);
        BytesData->Add(0x08);
        BytesData->Add(0x47);
        BytesData->Add(0x9c);
        BytesData->Add(0x4f);
        BytesData->Add(0x7e);
        BytesData->Add(0xc8);
        BytesData->Add(0x52);
        BytesData->Add(0xd1);
        BytesData->Add(0x6);
        BytesData->Add(0x9f);
        BytesData->Add(0x34);
        BytesData->Add(0x03);
        BytesData->Add(0x1e);
        BytesData->Add(0x00);
        BytesData->Add(0x00);

        EMVContactlessTransactionDataOutput^ txnOutput = gcnew EMVContactlessTransactionDataOutput(EMVContactlessTransactionDataOutput::TransactionOutcomeEnum::Approve,
                                                                                                   EMVContactlessTransactionDataOutput::CardholderActionEnum::None,
                                                                                                   BytesData,
                                                                                                   gcnew EMVContactlessTransactionDataOutput::EMVContactlessOutcome(EMVContactlessTransactionDataOutput::EMVContactlessOutcome::CvmEnum::OnlinePIN,
                                                                                                                                                                    EMVContactlessTransactionDataOutput::EMVContactlessOutcome::AlternateInterfaceEnum::Contact,
                                                                                                                                                                    false,
                                                                                                                                                                    gcnew EMVContactlessTransactionDataOutput::EMVContactlessOutcome::EMVContactlessUI(3,
                                                                                                                                                                                                                                                       EMVContactlessTransactionDataOutput::EMVContactlessOutcome::EMVContactlessUI::StatusEnum::CardReadOk,
                                                                                                                                                                                                                                                       0,
                                                                                                                                                                                                                                                       EMVContactlessTransactionDataOutput::EMVContactlessOutcome::EMVContactlessUI::ValueQualifierEnum::NotApplicable,
                                                                                                                                                                                                                                                       "0",
                                                                                                                                                                                                                                                       "EUR",
                                                                                                                                                                                                                                                       "EN"),
                                                                                                                                                                    nullptr,
                                                                                                                                                                    0,
                                                                                                                                                                    0,
                                                                                                                                                                    gcnew List<Byte>()));
        Dictionary<EMVContactlessPerformTransactionResult::DataSourceTypeEnum, EMVContactlessTransactionDataOutput^>^ Result = gcnew Dictionary<EMVContactlessPerformTransactionResult::DataSourceTypeEnum, EMVContactlessTransactionDataOutput^>();
        Result->Add(EMVContactlessPerformTransactionResult::DataSourceTypeEnum::Chip, txnOutput);

        return gcnew EMVContactlessPerformTransactionResult(MessagePayload::CompletionCodeEnum::Success, Result);
    }

    /// <summary>
    /// This command performs the post authorization processing on payment systems contactless cards.
    /// Before an online authorized transaction is considered complete, further chip processing may be requested by theissuer. 
    /// This is only required when the authorization response includes issuer update data either issuer scriptsor issuer authentication data.
    /// The command enables the contactless card reader and waits for the customer to re-tap their card.
    /// The contactless chip card reader waits for the period of time specified in the command all for a card to be tapped.
    /// </summary>
    EMVContactlessIssuerUpdateResult^ CardReaderSample::EMVContactlessIssuerUpdateSync(IEMVClessIssuerUpdateEvents^ events, EMVContactlessIssuerUpdateRequest^ transactionData, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();

        List<Byte>^ BytesData = gcnew List<Byte>();
        BytesData->Add(0x9c);
        BytesData->Add(0x1);
        BytesData->Add(0x0);
        BytesData->Add(0x9f);
        BytesData->Add(0x26);
        BytesData->Add(0x08);
        BytesData->Add(0x47);
        BytesData->Add(0x9c);
        BytesData->Add(0x4f);
        BytesData->Add(0x7e);
        BytesData->Add(0xc8);
        BytesData->Add(0x52);
        BytesData->Add(0xd1);
        BytesData->Add(0x6);
        BytesData->Add(0x9f);
        BytesData->Add(0x34);
        BytesData->Add(0x03);
        BytesData->Add(0x1e);
        BytesData->Add(0x00);
        BytesData->Add(0x00);

        EMVContactlessTransactionDataOutput^ txnOutput = gcnew EMVContactlessTransactionDataOutput(EMVContactlessTransactionDataOutput::TransactionOutcomeEnum::Approve,
                                                                                                   EMVContactlessTransactionDataOutput::CardholderActionEnum::None,
                                                                                                   BytesData,
                                                                                                   gcnew EMVContactlessTransactionDataOutput::EMVContactlessOutcome(EMVContactlessTransactionDataOutput::EMVContactlessOutcome::CvmEnum::OnlinePIN,
                                                                                                                                                                    EMVContactlessTransactionDataOutput::EMVContactlessOutcome::AlternateInterfaceEnum::Contact,
                                                                                                                                                                    false,
                                                                                                                                                                    gcnew EMVContactlessTransactionDataOutput::EMVContactlessOutcome::EMVContactlessUI(3,
                                                                                                                                                                                                                                                       EMVContactlessTransactionDataOutput::EMVContactlessOutcome::EMVContactlessUI::StatusEnum::CardReadOk,
                                                                                                                                                                                                                                                       0,
                                                                                                                                                                                                                                                       EMVContactlessTransactionDataOutput::EMVContactlessOutcome::EMVContactlessUI::ValueQualifierEnum::NotApplicable,
                                                                                                                                                                                                                                                       "0",
                                                                                                                                                                                                                                                       "EUR",
                                                                                                                                                                                                                                                       "EN"),
                                                                                                                                                                    nullptr,
                                                                                                                                                                    0,
                                                                                                                                                                    0,
                                                                                                                                                                    gcnew List<Byte>()));

        return gcnew EMVContactlessIssuerUpdateResult(MessagePayload::CompletionCodeEnum::Success, txnOutput);
    }

    /// <summary>
    /// The card is removed from its present position (card inserted into device, card entering, unknown position) and stored in the retain bin;
    /// applicable to motor-driven card readers only.
    /// The ID card unit sends a CardReader.RetainBinThresholdEvent if the storage capacity of the retainbin is reached.
    /// If the storage capacity has already been reached, and the command cannot be executed, an error isreturned and the card remains in its present position.
    /// </summary>
    CaptureCardResult^ CardReaderSample::CaptureCardSync(IRetainCardEvents^ events, CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();

        events->MediaRetainedEvent()->Wait();

        CapturedCount++;

        CardReaderServiceProvider^ cardReaderServiceProvider =  dynamic_cast<CardReaderServiceProvider^>(SetServiceProvider);
        Contracts::Assert(cardReaderServiceProvider != nullptr, "Unexpected reference for the CardReaderServiceProvider.");

        if (CapturedCount >= CpMaxCaptureCount)
        {
            // Send the threshold event only once when we reached the threshold
            if (RetainBinStatus != StatusClass::RetainBinEnum::High)
            {
                cardReaderServiceProvider->RetainBinThresholdEvent(gcnew RetainBinThresholdEvent::PayloadData(RetainBinThresholdEvent::PayloadData::StateEnum::Full))->Wait();
            }

            RetainBinStatus = StatusClass::RetainBinEnum::Full;
        }
        else if (CapturedCount >= (int)(((3 * CpMaxCaptureCount) / 4) + 0.5))
        {
            // Send the threshold event only once when we reached the threshold
            if (RetainBinStatus != StatusClass::RetainBinEnum::High)
            {
                // unsolic threadhold
                cardReaderServiceProvider->RetainBinThresholdEvent(gcnew RetainBinThresholdEvent::PayloadData(RetainBinThresholdEvent::PayloadData::StateEnum::High))->Wait();
            }

            RetainBinStatus = StatusClass::RetainBinEnum::High;
        }
        else
        {
            RetainBinStatus = StatusClass::RetainBinEnum::Ok;
        }

        return gcnew CaptureCardResult(MessagePayload::CompletionCodeEnum::Success,  CapturedCount++, RetainCardCompletion::PayloadData::PositionEnum::Present);
    }

    /// <summary>
    /// This function resets the present value for number of cards retained to zero.
    /// The function is possible formotor-driven card readers only.
    /// The number of cards retained is controlled by the service.
    /// </summary>
    ResetCountResult^ CardReaderSample::ResetBinCountSync(CancellationToken cancellation)
    {
        // The device doesn't need to talk to the device and return captured count immediately works as a sync
        CapturedCount = 0;
        return gcnew ResetCountResult(MessagePayload::CompletionCodeEnum::Success, nullptr);
    }

    /// <summary>
    /// This command is used for setting the DES key that is necessary for operating a CIM86 module.
    /// The command must beexecuted before the first read command is issued to the card reader.
    /// </summary>
    SetCIM86KeyResult^ CardReaderSample::SetCIM86KeySync(SetCIM86KeyRequest^ keyInfo,
                                                    CancellationToken cancellation)
    {
        Task::Delay(1000, cancellation)->Wait();
        return gcnew SetCIM86KeyResult(MessagePayload::CompletionCodeEnum::Success, nullptr, Nullable<SetKeyCompletion::PayloadData::ErrorCodeEnum>());
    }

    /// <summary>
    /// RunAync
    /// Handle unsolic events
    /// Here is an example of handling MediaRemovedEvent after card is ejected successfully.
    /// </summary>
    /// <returns></returns>
    void CardReaderSample::Run()
    {
        Contracts::Assert(cardTakenSignal != nullptr, "");
        for (;;)
        {
            cardTakenSignal->WaitAsync()->Wait();
            MediaStatus = MediaStatusEnum::NotPresent;
            CardReaderServiceProvider^ cardReaderServiceProvider = dynamic_cast<CardReaderServiceProvider^>(SetServiceProvider);
            Contracts::Assert(cardReaderServiceProvider != nullptr, "Unexpected reference for the CardReaderServiceProvider in FireMediaRemovedEvent.");
            cardReaderServiceProvider->MediaRemovedEvent()->Wait();
        }
    }

    /// <summary>
    /// This command is used to retrieve the complete list of registration authority Interface Module (IFM) identifiers.
    /// The primary registration authority is EMVCo but other organizations are also supported for historical or localcountry requirements.
    /// New registration authorities may be added in the future so applications should be able to handle the return of new(as yet undefined) IFM identifiers.
    /// </summary>
    QueryIFMIdentifierResult^ CardReaderSample::QueryIFMIdentifier()
    {
        List<Byte>^ IFMIdentifiersBytes = gcnew List<Byte>();
        IFMIdentifiersBytes->Add(0x1);
        IFMIdentifiersBytes->Add(0x2);
        IFMIdentifiersBytes->Add(0x3);
        IFMIdentifiersBytes->Add(0x4);

        List<IFMIdentifierInfo^>^ IFMIdentifiers = gcnew List<IFMIdentifierInfo^>();
        IFMIdentifiers->Add(gcnew IFMIdentifierInfo(XFS4IoT::CardReader::Completions::QueryIFMIdentifierCompletion::PayloadData::IfmAuthorityEnum::Emv, IFMIdentifiersBytes));

        return gcnew QueryIFMIdentifierResult(MessagePayload::CompletionCodeEnum::Success, IFMIdentifiers);
    }

    /// <summary>
    /// This command is used to retrieve the supported payment system applications available within an intelligentcontactless card unit. 
    /// The payment system application can either be identified by an AID or by the AID incombination with a Kernel Identifier. 
    /// The Kernel Identifier has been introduced by the EMVCo specifications; seeReference [3].
    /// </summary>
    QueryEMVApplicationResult^ CardReaderSample::EMVContactlessQueryApplications()
    {
        List<EMVApplication^>^ AIDList = gcnew List<EMVApplication^>();
        AIDList->Add(gcnew EMVApplication(gcnew List<Byte>(Encoding::UTF8->GetBytes("A0000000031010")), nullptr));
        AIDList->Add(gcnew EMVApplication(gcnew List<Byte>(Encoding::UTF8->GetBytes("A0000000041010")), nullptr));
        
        return gcnew QueryEMVApplicationResult(MessagePayload::CompletionCodeEnum::Success, AIDList);
    }

    /// COMMON interface

    StatusCompletion::PayloadData^ CardReaderSample::Status()
    {
        List<StatusPropertiesClass::GuideLightsClass^>^ guideLights = gcnew List<StatusPropertiesClass::GuideLightsClass^>();
        guideLights->Add(gcnew StatusPropertiesClass::GuideLightsClass(StatusPropertiesClass::GuideLightsClass::FlashRateEnum::Off,
                                                                       StatusPropertiesClass::GuideLightsClass::ColorEnum::Green,
                                                                       StatusPropertiesClass::GuideLightsClass::DirectionEnum::Off));

        StatusPropertiesClass^ common = 
            gcnew StatusPropertiesClass(StatusPropertiesClass::DeviceEnum::Online,
                                        gcnew List<String^>(),
                                        guideLights,
                                        PositionStatusEnum::Inposition,
                                        0,
                                        StatusPropertiesClass::AntiFraudModuleEnum::Ok);

        StatusClass::MediaEnum CurrentMediaStatus;
        switch (MediaStatus)
        {
        case MediaStatusEnum::Entering:
            CurrentMediaStatus = StatusClass::MediaEnum::Entering;
        case MediaStatusEnum::Jammed:
            CurrentMediaStatus = StatusClass::MediaEnum::Jammed;
        case MediaStatusEnum::Latched:
            CurrentMediaStatus = StatusClass::MediaEnum::Latched;
        case MediaStatusEnum::NotPresent:
            CurrentMediaStatus = StatusClass::MediaEnum::NotPresent;
        case MediaStatusEnum::NotSupported:
            CurrentMediaStatus = StatusClass::MediaEnum::NotSupported;
        case MediaStatusEnum::Present:
            CurrentMediaStatus = StatusClass::MediaEnum::Present;
        case MediaStatusEnum::Unknown:
            CurrentMediaStatus = StatusClass::MediaEnum::Unknown;
        }

        StatusClass^ cardReader = gcnew StatusClass(
            CurrentMediaStatus,
            StatusClass::RetainBinEnum::Ok,
            StatusClass::SecurityEnum::NotSupported,
            CapturedCount,
            StatusClass::ChipPowerEnum::PoweredOff,
            StatusClass::ChipModuleEnum::Ok,
            StatusClass::MagWriteModuleEnum::Ok,
            StatusClass::FrontImageModuleEnum::Ok,
            StatusClass::BackImageModuleEnum::Ok,
            gcnew List<StatusClass::ParkingStationMediaEnum>());

        return gcnew StatusCompletion::PayloadData(MessagePayload::CompletionCodeEnum::Success,
                                                   nullptr,
                                                   common,
                                                   cardReader,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr,
                                                   nullptr);
    }


    CapabilitiesCompletion::PayloadData^ CardReaderSample::Capabilities()
    {
        List<String^>^ VendorModeCommands = gcnew List<String^>;
        VendorModeCommands->Add("CardReader.ReadRawData");
        VendorModeCommands->Add("CardReader.EjectCard");

        List<CapabilityPropertiesClass::GuideLightsClass^>^ guideLights = gcnew List<CapabilityPropertiesClass::GuideLightsClass^>();
        guideLights->Add(gcnew CapabilityPropertiesClass::GuideLightsClass(gcnew CapabilityPropertiesClass::GuideLightsClass::FlashRateClass(true, true, true, true),
                                                                           gcnew CapabilityPropertiesClass::GuideLightsClass::ColorClass(true, true, true, true, true, true, true),
                                                                           gcnew CapabilityPropertiesClass::GuideLightsClass::DirectionClass(false, false)));

        List<FirmwareClass^>^ firmware = gcnew List<FirmwareClass^>();
        firmware->Add(gcnew FirmwareClass("XFS4 SP",
                                          "1.0",
                                          "1.0"));

        List<SoftwareClass^>^ software = gcnew List<SoftwareClass^>();
        software->Add(gcnew SoftwareClass("XFS4 SP",
                                          "1.0"));

        List<DeviceInformationClass^>^ deviceInfo = gcnew List<DeviceInformationClass^>();
        deviceInfo->Add(gcnew DeviceInformationClass("Simulator",
                                                     "123456-78900001",
                                                     "1.0",
                                                     "KAL simualtor",
                                                     firmware,
                                                     software));

        CapabilityPropertiesClass^ common = gcnew CapabilityPropertiesClass("1.0",
                                                                            deviceInfo,
                                                                            gcnew VendorModeInfoClass(true,
                                                                                                      VendorModeCommands),
                                                                            gcnew List<String^>(),
                                                                            guideLights,
                                                                            false,
                                                                            false,
                                                                            gcnew List<String^>(),
                                                                            false,
                                                                            false,
                                                                            false);

        CapabilitiesClass::TypeEnum CardReaderType;
        switch (DeviceType)
        {
        case DeviceTypeEnum::Motor:
            CapabilitiesClass::TypeEnum::Motor;
        case DeviceTypeEnum::Dip:
            CapabilitiesClass::TypeEnum::Dip;
        case DeviceTypeEnum::LatchedDip:
            CapabilitiesClass::TypeEnum::LatchedDip;
        case DeviceTypeEnum::Swipe:
            CapabilitiesClass::TypeEnum::Swipe;
        case DeviceTypeEnum::Contactless:
            CapabilitiesClass::TypeEnum::Contactless;
        case DeviceTypeEnum::IntelligentContactless:
            CapabilitiesClass::TypeEnum::IntelligentContactless;
        case DeviceTypeEnum::Permanent:
            CapabilitiesClass::TypeEnum::Permanent;
        }

        CapabilitiesClass^ cardReader = gcnew CapabilitiesClass(CardReaderType,
                                                                gcnew CapabilitiesClass::ReadTracksClass(true, true, true, false, false, false, false, false, false, false),
                                                                gcnew CapabilitiesClass::WriteTracksClass(true, true, true, false, false, false),
                                                                gcnew CapabilitiesClass::ChipProtocolsClass(true, true, false, false, false, false, false),
                                                                CpMaxCaptureCount,
                                                                CapabilitiesClass::SecurityTypeEnum::NotSupported,
                                                                CapabilitiesClass::PowerOnOptionEnum::NoAction,
                                                                CapabilitiesClass::PowerOffOptionEnum::NoAction,
                                                                false, false,
                                                                gcnew CapabilitiesClass::WriteModeClass(false, true, false, true),
                                                                gcnew CapabilitiesClass::ChipPowerClass(false, true, true, true),
                                                                gcnew CapabilitiesClass::MemoryChipProtocolsClass(false, false),
                                                                gcnew CapabilitiesClass::EjectPositionClass(true, false),
                                                                0);

        List<String^>^ CommonCommands = gcnew List<String^>;
        CommonCommands->Add("Common.Status");
        CommonCommands->Add("Common.Capabilities");

        InterfaceClass^ CommonInterface = gcnew InterfaceClass(InterfaceClass::NameEnum::Common,
                                                               CommonCommands,
                                                               gcnew List<String^>(),
                                                               1000,
                                                               gcnew List<String^>());

        List<String^>^ CardReaderCommands = gcnew List<String^>;
        CardReaderCommands->Add("CardReader.ReadRawData");
        CardReaderCommands->Add("CardReader.EjectCard");
        CardReaderCommands->Add("CardReader.Reset");
        CardReaderCommands->Add("CardReader.WriteRawData");
        CardReaderCommands->Add("CardReader.ChipIO");
        CardReaderCommands->Add("CardReader.ChipPower");
        CardReaderCommands->Add("CardReader.EMVClessConfigure");
        CardReaderCommands->Add("CardReader.EMVClessIssuerUpdate");
        CardReaderCommands->Add("CardReader.EMVClessPerformTransaction");
        CardReaderCommands->Add("CardReader.EMVClessQueryApplications");
        CardReaderCommands->Add("CardReader.ParkCard");
        CardReaderCommands->Add("CardReader.QueryIFMIdentifier");
        CardReaderCommands->Add("CardReader.ResetCount");
        CardReaderCommands->Add("CardReader.RetainCard");
        CardReaderCommands->Add("CardReader.SetKey");

        List<String^>^ CardReaderEvents = gcnew List<String^>();
        CardReaderEvents->Add("CardReader.MediaDetectedEvent");
        CardReaderEvents->Add("CardReader.MediaInsertedEvent");
        CardReaderEvents->Add("CardReader.MediaRemovedEvent");
        CardReaderEvents->Add("CardReader.MediaRetainedEvent");
        CardReaderEvents->Add("CardReader.InvalidMediaEvent");
        CardReaderEvents->Add("CardReader.EMVClessReadStatusEvent");

        InterfaceClass^ CardReaderInterface = gcnew InterfaceClass(InterfaceClass::NameEnum::CardReader,
                                                                   CardReaderCommands,
                                                                   CardReaderEvents,
                                                                   1000,
                                                                   gcnew List<String^>());

        List<InterfaceClass^>^ interfaces = gcnew List<InterfaceClass^>();
        interfaces->Add(CommonInterface);
        interfaces->Add(CardReaderInterface);

        return gcnew CapabilitiesCompletion::PayloadData(MessagePayload::CompletionCodeEnum::Success,
                                                         nullptr,
                                                         interfaces,
                                                         common,
                                                         cardReader,
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr,  
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr, 
                                                         nullptr);
    }
}
/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

#pragma once

using namespace System;

namespace KAL { namespace XFS4IoTSP { namespace CashDispenser{ namespace Sample
{
    public ref class ILogger abstract
    {
    public: 
        virtual void Log(String^ Message) = 0;

    };

    public ref class Firmware
    {
    public:
        static Firmware^ GetFirmware(ILogger^ logger)
        {
            if (!TheFirmware)
                TheFirmware = gcnew Firmware(logger);
            return TheFirmware;
        }
        static Firmware^ GetFirmware()
        {
            if (!TheFirmware) throw gcnew Exception("GetFirmware call when there's no firmware. Try calling GetFirmware with a logger first");
            return TheFirmware;
        }
        void Log(String^ Message)
        {
            Logger->Log(Message);
        }

        String^ GetCommandNonce(); 
        void ClearCommandNonce(); 

        bool VerifyAndDispense(String^ Token, String^ Currency, int Value);

        String^ GetPresentStatusToken(String^ nonce);

    private:
        Firmware(ILogger^ logger)
        {
            Logger = logger;
        }

        static Firmware^ TheFirmware;

        ILogger^ Logger; 
    };
}}}}
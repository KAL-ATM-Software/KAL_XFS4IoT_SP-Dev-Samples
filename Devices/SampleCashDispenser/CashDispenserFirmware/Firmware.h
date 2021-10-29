/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

#pragma once

using namespace System;

namespace KAL { namespace XFS4IoTSP { namespace CashDispenser{ namespace Sample
{
    public ref class Firmware
    {
    public:

        System::String^ GetCommandNonce(); 
        void ClearCommandNonce(); 

        bool VerifyAndDispense(System::String^ Token, System::String^ Currency, int Value);
    };
}}}}
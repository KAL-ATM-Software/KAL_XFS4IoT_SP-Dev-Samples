/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

/***********************************************************************************************\
 * This file is a simulation of what needs to happen to enforce end to end security 
 * for a cash dispenser class, using common code from the XFS4IoT sp-dev framework. 
 * 
 * Note that THIS IS NOT HOW THIS SHOULD BE IMPLEMENTED. 
 * 
 * In this sample the code is running directly in the sample service process on the PC. 
 * In a real system this hardware _must_ be running inside the safe, probably in the dispenser 
 * firmware. There would probably be a USB interface between the SP-Dev framework code and 
 * this code. Everything in this library should be inside the safe. 
\***********************************************************************************************/
#include "pch.h"
#include "Firmware.h"
#include "extensionpoints.h"
#include <iostream>
#include <sstream>
#include <vcclr.h>
#include <codecvt>

using namespace std;

// In a real implementation this value would need to be persistent. 
// The actual nonce must not repeat, even after a reboot, so this value 
// would need to be tracked and incremented across reboots and power cycles. 
// An alternative would be to use a hardware generated random number. Don't use 
// a pseudo random number generator unless the seed value is always 
// different across reboots, maybe with a real-time clock. 
static unsigned int NonceSeed = 1;

// The actual current nonce value doesn't actually need to be persistent, as long 
// as it doesn't repeat. So this value can be cleared by a reboot. 
string CurrentNonce = "";



bool KAL::XFS4IoTSP::CashDispenser::Sample::Firmware::VerifyAndDispense(System::String^ Token, System::String^ Currency, int Value )
{
    // Convert the .net UTF16 string into a native UTF8 string. 
    pin_ptr<const wchar_t> pinnedToken = PtrToStringChars(Token);
    pin_ptr<const wchar_t> pinnedCurrency = PtrToStringChars(Currency);

    wstring_convert<codecvt_utf8<wchar_t>> utf8Converter;
    string utf8Token;
    string utf8Currency;
    try 
    {
        utf8Token = utf8Converter.to_bytes(pinnedToken);
        utf8Currency = utf8Converter.to_bytes(pinnedCurrency);

    }
    catch (range_error const &)
    {
        cout << "Error: Conversion to UTF8 failed after " << dec << utf8Token.size() << " characters:\n";
        for (auto c : utf8Token)
            cout << hex << showbase << c << '\n';
    }

    // Check that the token is valid. 
    // Include null in token (buffer) size.
    auto tokenValid = ValidateToken(utf8Token.c_str(), utf8Token.size() + 1);
    if (!tokenValid)
        return false; 

    tokenValid = ParseDispenseToken(utf8Token.c_str(), utf8Token.size() + 1);
    if (!tokenValid)
        return false;

    auto TokenValues = GetDispenseKeyValues();
    cout << "Got dispense token values: Currency:" << string(TokenValues->Currency, 3) << " value:" << TokenValues->Value << " cents:" << TokenValues->Fraction << "\n";

    if (string(TokenValues->Currency, 3) != utf8Currency)
        return false;

    if (TokenValues->Value != Value)
        return false;

    // Simulate the actual dispense 
    cout << "dispensing: " << TokenValues->Value << "." << TokenValues->Fraction << string(TokenValues->Currency, 3) << "\n";
    Sleep(1000);
    cout << "dispensed\n";


    return true; 
}

System::String^ KAL::XFS4IoTSP::CashDispenser::Sample::Firmware::GetCommandNonce()
{
    if (CurrentNonce == "")
    {
        char const* out; 
        NewNonce(&out);
    }

    return gcnew System::String( CurrentNonce.c_str() );
}

void KAL::XFS4IoTSP::CashDispenser::Sample::Firmware::ClearCommandNonce()
{
    ClearNonce(); 
}

extern "C" void FatalError(char const* const Message)
{
    cerr << Message;
    exit(-1);  
};

extern "C" void Log(char const* const Message)
{
    cout << Message << "\n";
};

extern "C" void NewNonce(char const** outNonce)
{
    NonceSeed++; // This should update a persistent value. 

    stringstream ss;
    ss << uppercase << hex << NonceSeed;
    CurrentNonce = ss.str(); 
    *outNonce = CurrentNonce.c_str(); // CurrentNonce string must remain valid. 
}

extern "C" void ClearNonce()
{
    CurrentNonce = "";
}

extern "C" bool CompareNonce(char const* const CommandNonce, size_t NonceLength)
{
    // Normally this would be done in C in a more efficient way, but std::string is fine
    // for a sample. 
    return string(CommandNonce, NonceLength) == CurrentNonce;
}

/// <summary>
/// Check that the binary HMAC value matches the calculated value
/// </summary>
/// <remarks>
/// This is the core check on the token, to validate that it was created by a system that knows
/// the shared HMAC key. 
/// This routine must use the XFSAuthenticateDevice key to calculate the HMAC over the given string,
/// and compare that to the given value. 
/// Note that the comparison should be 'constant time' - if length of time taken to compare 
/// the values varies then this could be used by an attacker to find the correct value. An attacker 
/// can gradually vary the nonce to find the slowest comparison, which will match the correct nonce. 
/// </remarks>
/// <param name="Token">Token string - not null terminated</param>
/// <param name="TokenLength">Number of characters to be used from the Token string</param>
/// <param name="TokenHMAC">A 32 byte binary buffer</param>
/// <returns>true if the HMAC matches the correct value for this token</returns>
extern "C" bool CheckHMAC(char const* const Token, unsigned int TokenLength, unsigned char const* const TokenHMAC)
{
    char HMACString[(32*2)+1] = "";
    for (int i = 0; i < 32; i++)
        sprintf_s(&HMACString[i * 2], 3, "%2X", TokenHMAC[i]);

    // The important bit. 
    // A not-completely correct HMAC Check 🙂
    return string(HMACString, 64) == "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F2";
}

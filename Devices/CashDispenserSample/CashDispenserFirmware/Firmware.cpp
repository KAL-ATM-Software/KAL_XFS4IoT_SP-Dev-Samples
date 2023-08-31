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

    // Check that the token is valid and authorises the requested dispense. 
    // Include null in token (buffer) size.
    auto Authorised = AuthoriseDispenseAgainstToken(utf8Token.c_str(), utf8Token.size() + 1, Value, 0, utf8Currency.c_str());
    if (!Authorised)
        return false; 

    auto TokenValues = GetDispenseKeyValues();
    cout << "Got dispense token values: Currency:" << string(TokenValues->Currency, 3) << " value:" << TokenValues->Value << " cents:" << TokenValues->Fraction << "\n";

    // Simulate the actual dispense 
    cout << "dispensing: " << TokenValues->Value << "." << TokenValues->Fraction << string(TokenValues->Currency, 3) << "\n";
    Sleep(1000);
    cout << "dispensed\n";

    // At this point the "dispense" has completed successfully, so we must confirm that to E2E security. 
    // If the dispense failed we just skip this, or even confirm a partial amount if only part of the 
    // cash was dispensed. 
    ConfirmDispenseAgainstToken(utf8Token.c_str(), utf8Token.size() + 1, Value, 0, utf8Currency.c_str());

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
    InvalidateToken(); // Also delete any existing token. 
}

String^ KAL::XFS4IoTSP::CashDispenser::Sample::Firmware::GetPresentStatusToken(String^ nonce)
{
    // Convert the .net UTF16 string into a native UTF8 string. 
    pin_ptr<const wchar_t> pinnednonce = PtrToStringChars(nonce);
    
    wstring_convert<codecvt_utf8<wchar_t>> utf8Converter;
    string utf8nonce;
    try
    {
        utf8nonce = utf8Converter.to_bytes(pinnednonce);

    }
    catch (range_error const&)
    {
        cout << "Error: Conversion to UTF8 failed after " << dec << utf8nonce.size() << " characters:\n";
        for (auto c : utf8nonce)
            cout << hex << showbase << c << '\n';
    }

    char const* responceToken = NULL;
    auto result = ::GetPresentStatusToken(utf8nonce.c_str(), &responceToken);

    if (!result)
        return nullptr;
    else
        return gcnew System::String( responceToken );
}


extern "C" void FatalError(char const* const Message)
{
    Log( Message );
    exit(-1);  
};

extern "C" void Log(char const* const Message)
{
    KAL::XFS4IoTSP::CashDispenser::Sample::Firmware::GetFirmware()->Log( gcnew String((std::string("FIRMARE: ") + Message).c_str()));
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
extern "C" bool CheckHMAC(char const* const Token, size_t TokenLength, unsigned char const* const TokenHMAC)
{
    char HMACString[(32*2)+1] = "";
    for (int i = 0; i < 32; i++)
        sprintf_s(&HMACString[i * 2], 3, "%2X", TokenHMAC[i]);

    // The important bit. 
    // A not-completely correct HMAC Check 🙂
    return string(HMACString, 64) == "CB735612FD6141213C2827FB5A6A4F4846D7A7347B15434916FEA6AC16F3D2F2";
}

const int HMAC_SIZE = 32; 
static char LastDispenseID[HMAC_SIZE] = { 0 }; // This value should be persistent across power-cycles
bool GetLastDispenseIDSet()
{
    unsigned int sum = 0;
    for (unsigned int i = 0; i < HMAC_SIZE; i++)
    {
        sum += LastDispenseID[i];
    }
    return sum != 0;
}

extern "C" bool GetLastDispenseID( bool* KnownValue, char ThisDispenseID[HMAC_SIZE])
{
    *KnownValue = GetLastDispenseIDSet(); 
    memcpy_s(
        ThisDispenseID, HMAC_SIZE,
        LastDispenseID, HMAC_SIZE
    );
    return true; 
}

extern "C" bool SetLastDispenseID(char ThisDispenseID[HMAC_SIZE])
{
    memcpy_s(
        LastDispenseID, HMAC_SIZE,
        ThisDispenseID, HMAC_SIZE
    );
    return true;

}

extern "C" bool GetLastDispenseAmount(unsigned int* UnitValue, unsigned int* SubUnitValue, char Currency[3])
{
    *UnitValue = 123; 
    *SubUnitValue = 678;
    Currency[0] = 'A';
    Currency[1] = 'B';
    Currency[2] = 'C';
    return true;
}
extern "C" bool GetLastDispensePresented(bool* Presented)
{
    *Presented = true;
    return true;
}
extern "C" bool GetLastPresentedAmount(unsigned int* UnitValue, unsigned int* SubUnitValue, char Currency[3])
{
    *UnitValue = 654;
    *SubUnitValue = 432;
    Currency[0] = 'X';
    Currency[1] = 'Y';
    Currency[2] = 'Z';
    return true;
}
extern "C" bool GetLastDispenseRetracted(bool* Retracted)
{
    *Retracted = true;
    return true;
}
extern "C" bool GetLastRetractedAmount(bool* ValueKnown, unsigned int* UnitValue, unsigned int* SubUnitValue, char Currency[3])
{
    if (GetLastDispenseIDSet() == false)
    {
        *ValueKnown = false;
    }
    else
    {
        *ValueKnown = true;
        *UnitValue = 321;
        *SubUnitValue = 432;
        Currency[0] = 'X';
        Currency[1] = 'Y';
        Currency[2] = 'Z';
    }
    return true;
}

extern "C" bool NewHMAC(char const* const Token, size_t  TokenLength, unsigned char* const TokenHMAC)
{
    static const uint8_t FakeHMAC[] = { 0xBC, 0x37, 0x65, 0x21, 0xDF, 0x16, 0x14, 0x12,
                                        0xC3, 0x82, 0x72, 0xBF, 0xA5, 0xA6, 0xF4, 0x84, 
                                        0x46, 0xD7, 0xA7, 0x34, 0x7B, 0x15, 0x43, 0x49, 
                                        0x16, 0xFE, 0xA6, 0xAC, 0x16, 0xF3, 0xD2, 0xF2 };
    memcpy_s(TokenHMAC, sizeof(FakeHMAC), FakeHMAC, sizeof(FakeHMAC));
    return true;
}



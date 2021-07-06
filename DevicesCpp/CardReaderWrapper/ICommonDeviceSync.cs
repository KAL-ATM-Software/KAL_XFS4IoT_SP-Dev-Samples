/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using XFS4IoT.Common.Commands;
using XFS4IoT.Common.Completions;

using XFS4IoTFramework.Common;

namespace KAL.XFS4IoTSP.CardReader.Sample
{
    public interface ICommonDeviceSync
    {
        StatusCompletion.PayloadData Status();

        CapabilitiesCompletion.PayloadData Capabilities();

        PowerSaveControlCompletion.PayloadData PowerSaveControl(PowerSaveControlCommand.PayloadData payload);

        SynchronizeCommandCompletion.PayloadData SynchronizeCommand(SynchronizeCommandCommand.PayloadData payload);

        SetTransactionStateCompletion.PayloadData SetTransactionState(SetTransactionStateCommand.PayloadData payload);

        GetTransactionStateCompletion.PayloadData GetTransactionState();

        GetCommandRandomNumberResult GetCommandRandomNumber();
    }
}
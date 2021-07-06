/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using XFS4IoTServer;

namespace KAL.XFS4IoTSP.CardReader.Sample
{
    public interface IDeviceSync
    {
        IServiceProvider SetServiceProvider { get; set; }

        void Run();
    }
}
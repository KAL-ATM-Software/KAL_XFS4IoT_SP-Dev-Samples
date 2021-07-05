/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2021
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Threading;

namespace TestClient
{
    internal class RequestId
    {
        internal static int NewID() => Interlocked.Increment(ref id);

        private static int id = 1;
    }
}
﻿/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAL.XFS4IoTSP.PinPad.Sample
{
    public partial class PinPadUI : Form
    {
        public readonly Channel<string> KeyPressChannel = Channel.CreateUnbounded<string>();

        public PinPadUI()
        {
            InitializeComponent();
        }

        private async void KeyBtn_Click(object sender, EventArgs e)
        {
            await KeyPressChannel.Writer.WriteAsync((sender as Button).Name.Replace("KEYBtn", ""));
        }
    }
}

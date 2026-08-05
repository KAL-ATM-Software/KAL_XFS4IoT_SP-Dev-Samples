/***********************************************************************************************\
 * (C) KAL ATM Software GmbH, 2022
 * KAL ATM Software GmbH licenses this file to you under the MIT license.
 * See the LICENSE file in the project root for more information.
\***********************************************************************************************/
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using XFS4IoT.Check.Completions;


namespace XFS4IoT.TestTool;

public partial class CheckScannerTxnStatus : Form
{
    public CheckScannerTxnStatus()
    {
        InitializeComponent();
    }

    public void PrepareDisplay(GetTransactionStatusCompletion.PayloadData GetTransactionStatusPayload)
    {
        GetTransactionStatusPayload.IsNotNull($"Invalid parameter for the {nameof(PrepareDisplay)}");

        CurrentIndex = 0;

        Payload = GetTransactionStatusPayload;

        mediaInTxnStatus.Text = Payload.MediaInTransaction.ToString();
        mediaOnStacker.Text = Payload.MediaOnStacker;
        lastMediaAddedToStacker.Text = Payload.LastMediaAddedToStacker;
        lastMediaInTotal.Text = Payload.LastMediaInTotal;
        totalItems.Text = Payload.TotalItems;
        totalItemsRefused.Text = Payload.TotalItemsRefused;
        totalBunchesRefused.Text = Payload.TotalBunchesRefused;

        if (Payload.MediaInfo is not null)
        {
            buttonBack.Enabled = false;
            buttonNext.Enabled = Payload.MediaInfo.Count > 1 ? true : false;
            DisplayImageInfo(CurrentIndex);
        }
        else
        {
            buttonBack.Enabled = false;
            buttonNext.Enabled = false;
        }
    }

    private void buttonBack_Click(object sender, EventArgs e)
    {
        CurrentIndex--;
        if (CurrentIndex < 0)
        {
            CurrentIndex = 0;
        }

        buttonBack.Enabled = CurrentIndex != 0;
        buttonNext.Enabled = true;

        DisplayImageInfo(CurrentIndex);
    }

    private void buttonNext_Click(object sender, EventArgs e)
    {
        CurrentIndex++;
        buttonNext.Enabled = CurrentIndex != Payload.MediaInfo?.Count - 1;
        buttonBack.Enabled = true;

        DisplayImageInfo(CurrentIndex);
    }

    private void DisplayImageInfo(int index)
    {
        mediaID.Text = (index + 1).ToString();

        if (index >= 0 && index < Payload.MediaInfo?.Count)
        {
            codelineData.Text = Payload.MediaInfo[index].CodelineData;
            magneticReadIndicator.Text = Payload.MediaInfo[index].MagneticReadIndicator?.ToString();
            mediaValidity.Text = Payload.MediaInfo[index].MediaValidity?.ToString();
            customerAccess.Text = Payload.MediaInfo[index].CustomerAccess?.ToString();
            mediaLocation.Text = Payload.MediaInfo[index].MediaLocation;
            codelineOrientation.Text = Payload.MediaInfo[index].InsertOrientation?.Codeline?.ToString();
            codelineOrientation.Text = Payload.MediaInfo[index].InsertOrientation?.Media?.ToString();

            if (Payload.MediaInfo[index].Image?.Count > 0)
            {
                imageSource.Text = Payload.MediaInfo[index].Image[0].ImageSource?.ToString();
                imageFormat.Text = Payload.MediaInfo[index].Image[0].ImageType?.ToString();
                colorFormat.Text = Payload.MediaInfo[index].Image[0].ImageColorFormat?.ToString();
                scanColor.Text = Payload.MediaInfo[index].Image[0].ImageScanColor?.ToString();
                byte[] image = Payload.MediaInfo[index].Image[0].Image?.ToArray();
                if (image?.Length > 0)
                {
                    using MemoryStream stream = new();
                    stream.Write(Payload.MediaInfo[index].Image[0].Image?.ToArray(), 0, Payload.MediaInfo[index].Image[0].Image.ToArray().Length);
                    stream.Seek(0, SeekOrigin.Begin);
                    Bitmap bmp = new(stream);
                    picCheck.Image = bmp;
                }
            }
        }
    }

    private int CurrentIndex = 0;
    private GetTransactionStatusCompletion.PayloadData Payload = null;
}

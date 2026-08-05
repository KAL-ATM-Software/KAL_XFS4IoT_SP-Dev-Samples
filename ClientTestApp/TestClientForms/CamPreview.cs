using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XFS4IoT.TestTool;

public partial class CamPreview : Form
{
    public CamPreview()
    {
        InitializeComponent();
    }

    public void UpdateImage(Bitmap bmp)
    {
        picBox.Invoke(() => picBox.Image = bmp);
    }


}

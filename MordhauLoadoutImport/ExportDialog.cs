using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MordhauLoadoutImport
{
    public partial class ExportDialog : Form
    {
        public string ProfileName
        {
            get { return profileNameLabel.Text; }
            set { profileNameLabel.Text = value; }
        }

        public string EncodedProfile
        {
            get { return encodedProfile.Text; }
            set { encodedProfile.Text = value; }
        }
        public ExportDialog()
        {
            InitializeComponent();
        }

        private void copyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(EncodedProfile);
            FlashClipboardMessage();
        }

        void FlashClipboardMessage()
        {
            clipboardFlashLabel.Visible = true;
            clipboardFlasTimer.Stop();
            clipboardFlasTimer.Start();
        }

        private void clipboardFlasTimer_Tick(object sender, EventArgs e)
        {
            clipboardFlashLabel.Visible = false;
            clipboardFlasTimer.Stop();
        }
    }
}

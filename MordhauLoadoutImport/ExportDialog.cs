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
        private bool exportAsPlainText = false;
        public bool ExportAsPlainText
        {
            get
            {
                return exportAsPlainText;
            }
            set
            {
                exportAsPlainText = value;
                if (exportAsPlainText)
                {
                    profileTextBox.Text = PlainTextProfile;
                }
                else
                {
                    profileTextBox.Text = EncodedProfile;
                }
            }
        }

        public string ProfileName
        {
            get { return profileNameLabel.Text; }
            set { profileNameLabel.Text = value; }
        }

        public string PlainTextProfile
        {
            get;
            set;
        }

        public string EncodedProfile
        {
            get;
            set;
        }

        public ExportDialog()
        {
            InitializeComponent();
        }

        private void copyToClipboard_Click(object sender, EventArgs e)
        {
            if (exportAsPlainText)
            {
                Clipboard.SetText(PlainTextProfile);
            }
            else
            {
                Clipboard.SetText(EncodedProfile);
            }
            
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

        private void exportAsPlainTextCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ExportAsPlainText = exportAsPlainTextCheckBox.Checked;
        }
    }
}

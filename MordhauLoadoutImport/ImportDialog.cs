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
    public partial class ImportDialog : Form
    {
        string decodedLoadout = "";
        public ImportDialog()
        {
            InitializeComponent();
        }

        private void encodedProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            string decodedProfile;

            if (TryDecodeProfile(encodedProfileTextBox.Text.Trim(), out decodedProfile))
            {
                validLoadoutLabel.Visible = true;
                invalidLoadoutLabel.Visible = false;
                loadoutImportPanel.Visible = true;
                decodedLoadout = decodedProfile;
            }
            else
            {
                invalidLoadoutLabel.Visible = true;
                validLoadoutLabel.Visible = false;
                loadoutImportPanel.Visible = false;
                decodedLoadout = "";
            }
        }

        bool TryDecodeProfile(string encodedProfile, out string decodedProfile)
        {
            try
            {
                var base64EncodedBytes = Convert.FromBase64String(encodedProfile);
                decodedProfile = Encoding.UTF8.GetString(base64EncodedBytes);

                var loadoutName = LoadoutParser.GetLoadoutNameFromProfileString(decodedProfile);

                loadoutNameTextBox.Text = LoadoutParser.GetNextAvailableName(loadoutName);

                return true;
            }
            catch
            {
                decodedProfile = "";
                return false;
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            if(decodedLoadout == "")
            {
                return;
            }

            var loadoutName = loadoutNameTextBox.Text.Trim();
            if (LoadoutParser.LoadoutNameExist(loadoutName))
            {
                MessageBox.Show($"You already have loadout called {loadoutName}. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LoadoutParser.AppendLoadoutToFile(loadoutName, decodedLoadout);
                MessageBox.Show("Loadout imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}

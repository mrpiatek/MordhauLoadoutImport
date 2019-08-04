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

        string DecodedLoadout
        {
            get { return decodedLoadout; }
            set {
                decodedLoadout = value;

                if (decodedLoadout != "")
                {
                    var loadoutName = LoadoutParser.GetLoadoutNameFromProfileString(decodedLoadout);
                    loadoutNameTextBox.Text = LoadoutParser.GetNextAvailableName(loadoutName);
                }
                else
                {
                    loadoutNameTextBox.Text = "";
                }
            }
        }

        private bool IsProfileValid
        {
            set
            {
                if (value)
                {
                    validLoadoutLabel.Visible = true;
                    invalidLoadoutLabel.Visible = false;
                    loadoutImportPanel.Visible = true;
                }
                else
                {
                    invalidLoadoutLabel.Visible = true;
                    validLoadoutLabel.Visible = false;
                    loadoutImportPanel.Visible = false;
                }
            }
        }

        public ImportDialog()
        {
            InitializeComponent();

            //TODO refactor
            if (Clipboard.ContainsText())
            {
                var clipboardText = Clipboard.GetText();
                var isValidProfile = clipboardText.StartsWith("CharacterProfiles=");
                try
                {
                    ProfileEncoder.Decode(clipboardText);
                    isValidProfile = true;
                }
                catch
                {
                }
                if (isValidProfile)
                {
                    encodedProfileTextBox.Text = clipboardText;
                }
            }
        }

        private void encodedProfileTextBox_TextChanged(object sender, EventArgs e)
        {
            //TODO refactor
            string userInput = encodedProfileTextBox.Text.Trim();

            string decodedProfile;

            if (userInput.StartsWith("CharacterProfiles="))
            {
                DecodedLoadout = userInput;
                IsProfileValid = true;
            }
            else if (TryDecodeProfile(userInput, out decodedProfile))
            {
                DecodedLoadout = decodedProfile;
                IsProfileValid = true;
            }
            else
            {
                DecodedLoadout = "";
                IsProfileValid = false;
            }
        }

        bool TryDecodeProfile(string encodedProfile, out string decodedProfile)
        {
            try
            {
                decodedProfile = ProfileEncoder.Decode(encodedProfile);
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
            if (decodedLoadout == "")
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

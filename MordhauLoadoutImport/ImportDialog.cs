using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MordhauLoadoutImport.LoadoutParser;

namespace MordhauLoadoutImport
{
    public partial class ImportDialog : Form
    {
        string decodedLoadout = "";

        string DecodedLoadout
        {
            get { return decodedLoadout; }
            set
            {
                decodedLoadout = value;

                if (decodedLoadout != "")
                {
                    var loadoutName = GetLoadoutNameFromProfileString(decodedLoadout);
                    loadoutNameTextBox.Text = GetNextAvailableName(loadoutName);
                }
                else
                {
                    loadoutNameTextBox.Text = "";
                }
            }
        }

        private bool isProfileValid;
        private bool IsProfileValid
        {
            get
            {
                return isProfileValid;
            }
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

                isProfileValid = value;
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


            if (IsProfileValid)
            {
                ParsedProfile parsedProfile = ParseProfile(DecodedLoadout);
                StringBuilder sb = new StringBuilder();
                foreach (int wearable in Enum.GetValues(typeof(Wearable)))
                {
                    string wearableName = GetWearableName((Wearable)wearable, parsedProfile.Wearables[wearable]);
                    if (wearableName != null)
                    {
                        sb.AppendLine(wearableName);
                    }
                }

                wearablesLabel.Text = sb.ToString();
            }
        }

        string GetWearableName(Wearable wearable, int wearableId)
        {
            string wearableName = null;
            switch (wearable)
            {
                case Wearable.Head: wearableName = Helmets.ResourceManager.GetObject($"_{wearableId}").ToString(); break;
                case Wearable.Torso: wearableName = TorsoWearables.ResourceManager.GetObject($"_{wearableId}").ToString(); break;
                case Wearable.Legs: wearableName = LegsWearables.ResourceManager.GetObject($"_{wearableId}").ToString(); break;
                default: return null;
            }

            if (wearableName == null)
            {
                wearableName = "?";
            }

            return wearableName;
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
            if (LoadoutNameExist(loadoutName))
            {
                MessageBox.Show($"You already have loadout called {loadoutName}. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AppendLoadoutToFile(loadoutName, decodedLoadout);
                MessageBox.Show("Loadout imported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void wearablesLabel_Click(object sender, EventArgs e)
        {

        }
    }
}

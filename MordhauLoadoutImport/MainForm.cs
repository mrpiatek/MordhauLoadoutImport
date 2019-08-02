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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadProfiles();
        }

        void LoadProfiles()
        {
            LoadLoadoutsFromFile();

            loadoutListBox.Items.Clear();
            foreach (Loadout loadout in Loadouts)
            {
                loadoutListBox.Items.Add(loadout.Name);
            }

            numberOfLoadoutsLabel.Text = $"Found {Loadouts.Count} loadout(s)";
        }

        private bool IsValidLoadoutSelected()
        {
            var idx = loadoutListBox.SelectedIndex;
            return idx > 0 && idx < Loadouts.Count;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            ExportSelectedLoadout();
        }

        private void ExportSelectedLoadout()
        {
            if (IsValidLoadoutSelected())
            {
                var selectedLoadout = Loadouts[loadoutListBox.SelectedIndex];
                ExportLoadout(selectedLoadout);
            }
        }

        private void ExportLoadout(Loadout loadout)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(loadout.Profile);
            var encodedProfile = Convert.ToBase64String(plainTextBytes);
            ExportDialog exportDialog = new ExportDialog();
            exportDialog.ProfileName = loadout.Name;
            exportDialog.EncodedProfile = encodedProfile;
            exportDialog.ShowDialog();
        }

        private void loadoutListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            exportButton.Enabled = IsValidLoadoutSelected();
        }

        private void loadoutListBox_DoubleClick(object sender, EventArgs e)
        {
            ExportSelectedLoadout();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImportDialog importDialog = new ImportDialog();
            importDialog.ShowDialog();
            LoadProfiles();
        }
    }
}

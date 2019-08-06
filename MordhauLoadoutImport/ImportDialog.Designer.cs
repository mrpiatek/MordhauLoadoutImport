namespace MordhauLoadoutImport
{
    partial class ImportDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.encodedProfileTextBox = new System.Windows.Forms.TextBox();
            this.importButton = new System.Windows.Forms.Button();
            this.loadoutNameTextBox = new System.Windows.Forms.TextBox();
            this.validLoadoutLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadoutImportPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.wearablesLabel = new System.Windows.Forms.Label();
            this.invalidLoadoutLabel = new System.Windows.Forms.Label();
            this.loadoutImportPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // encodedProfileTextBox
            // 
            this.encodedProfileTextBox.Location = new System.Drawing.Point(12, 25);
            this.encodedProfileTextBox.Multiline = true;
            this.encodedProfileTextBox.Name = "encodedProfileTextBox";
            this.encodedProfileTextBox.Size = new System.Drawing.Size(491, 194);
            this.encodedProfileTextBox.TabIndex = 0;
            this.encodedProfileTextBox.TextChanged += new System.EventHandler(this.encodedProfileTextBox_TextChanged);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(410, 149);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 1;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // loadoutNameTextBox
            // 
            this.loadoutNameTextBox.Location = new System.Drawing.Point(0, 151);
            this.loadoutNameTextBox.Name = "loadoutNameTextBox";
            this.loadoutNameTextBox.Size = new System.Drawing.Size(404, 20);
            this.loadoutNameTextBox.TabIndex = 2;
            // 
            // validLoadoutLabel
            // 
            this.validLoadoutLabel.AutoSize = true;
            this.validLoadoutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.validLoadoutLabel.ForeColor = System.Drawing.Color.Green;
            this.validLoadoutLabel.Location = new System.Drawing.Point(422, 222);
            this.validLoadoutLabel.Name = "validLoadoutLabel";
            this.validLoadoutLabel.Size = new System.Drawing.Size(81, 13);
            this.validLoadoutLabel.TabIndex = 3;
            this.validLoadoutLabel.Text = "Valid loadout";
            this.validLoadoutLabel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose name for the loadout:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Paste loadout code here:";
            // 
            // loadoutImportPanel
            // 
            this.loadoutImportPanel.Controls.Add(this.label1);
            this.loadoutImportPanel.Controls.Add(this.label4);
            this.loadoutImportPanel.Controls.Add(this.wearablesLabel);
            this.loadoutImportPanel.Controls.Add(this.loadoutNameTextBox);
            this.loadoutImportPanel.Controls.Add(this.importButton);
            this.loadoutImportPanel.Controls.Add(this.label2);
            this.loadoutImportPanel.Location = new System.Drawing.Point(12, 246);
            this.loadoutImportPanel.Name = "loadoutImportPanel";
            this.loadoutImportPanel.Size = new System.Drawing.Size(491, 174);
            this.loadoutImportPanel.TabIndex = 6;
            this.loadoutImportPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Wearables";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 52);
            this.label4.TabIndex = 6;
            this.label4.Text = "Weapons\r\nl\r\nl\r\nl";
            // 
            // wearablesLabel
            // 
            this.wearablesLabel.AutoSize = true;
            this.wearablesLabel.Location = new System.Drawing.Point(3, 19);
            this.wearablesLabel.Name = "wearablesLabel";
            this.wearablesLabel.Size = new System.Drawing.Size(9, 117);
            this.wearablesLabel.TabIndex = 5;
            this.wearablesLabel.Text = "l\r\nl\r\nl\r\nl\r\nl\r\nl\r\nl\r\nl\r\nl";
            // 
            // invalidLoadoutLabel
            // 
            this.invalidLoadoutLabel.AutoSize = true;
            this.invalidLoadoutLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invalidLoadoutLabel.ForeColor = System.Drawing.Color.Red;
            this.invalidLoadoutLabel.Location = new System.Drawing.Point(409, 222);
            this.invalidLoadoutLabel.Name = "invalidLoadoutLabel";
            this.invalidLoadoutLabel.Size = new System.Drawing.Size(91, 13);
            this.invalidLoadoutLabel.TabIndex = 7;
            this.invalidLoadoutLabel.Text = "Invalid loadout";
            this.invalidLoadoutLabel.Visible = false;
            // 
            // ImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 432);
            this.Controls.Add(this.invalidLoadoutLabel);
            this.Controls.Add(this.loadoutImportPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.validLoadoutLabel);
            this.Controls.Add(this.encodedProfileTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ImportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Import Loadout";
            this.loadoutImportPanel.ResumeLayout(false);
            this.loadoutImportPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox encodedProfileTextBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.TextBox loadoutNameTextBox;
        private System.Windows.Forms.Label validLoadoutLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel loadoutImportPanel;
        private System.Windows.Forms.Label invalidLoadoutLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label wearablesLabel;
        private System.Windows.Forms.Label label1;
    }
}
namespace MordhauLoadoutImport
{
    partial class MainForm
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
            this.loadoutListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.numberOfLoadoutsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadoutListBox
            // 
            this.loadoutListBox.FormattingEnabled = true;
            this.loadoutListBox.Location = new System.Drawing.Point(12, 25);
            this.loadoutListBox.Name = "loadoutListBox";
            this.loadoutListBox.Size = new System.Drawing.Size(338, 212);
            this.loadoutListBox.TabIndex = 0;
            this.loadoutListBox.SelectedIndexChanged += new System.EventHandler(this.loadoutListBox_SelectedIndexChanged);
            this.loadoutListBox.DoubleClick += new System.EventHandler(this.loadoutListBox_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Import";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exportButton
            // 
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(194, 243);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(75, 23);
            this.exportButton.TabIndex = 2;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // numberOfLoadoutsLabel
            // 
            this.numberOfLoadoutsLabel.AutoSize = true;
            this.numberOfLoadoutsLabel.Location = new System.Drawing.Point(12, 9);
            this.numberOfLoadoutsLabel.Name = "numberOfLoadoutsLabel";
            this.numberOfLoadoutsLabel.Size = new System.Drawing.Size(95, 13);
            this.numberOfLoadoutsLabel.TabIndex = 3;
            this.numberOfLoadoutsLabel.Text = "Found 0 loadout(s)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 283);
            this.Controls.Add(this.numberOfLoadoutsLabel);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.loadoutListBox);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Mordhau Loadout Share";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox loadoutListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label numberOfLoadoutsLabel;
    }
}


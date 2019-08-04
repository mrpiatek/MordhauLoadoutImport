namespace MordhauLoadoutImport
{
    partial class ExportDialog
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
            this.components = new System.ComponentModel.Container();
            this.profileTextBox = new System.Windows.Forms.TextBox();
            this.profileNameLabel = new System.Windows.Forms.Label();
            this.copyToClipboard = new System.Windows.Forms.Button();
            this.clipboardFlashLabel = new System.Windows.Forms.Label();
            this.clipboardFlasTimer = new System.Windows.Forms.Timer(this.components);
            this.exportAsPlainTextCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // profileTextBox
            // 
            this.profileTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileTextBox.Location = new System.Drawing.Point(15, 55);
            this.profileTextBox.Multiline = true;
            this.profileTextBox.Name = "profileTextBox";
            this.profileTextBox.ReadOnly = true;
            this.profileTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.profileTextBox.Size = new System.Drawing.Size(698, 285);
            this.profileTextBox.TabIndex = 0;
            // 
            // profileNameLabel
            // 
            this.profileNameLabel.AutoSize = true;
            this.profileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.profileNameLabel.Location = new System.Drawing.Point(12, 9);
            this.profileNameLabel.Name = "profileNameLabel";
            this.profileNameLabel.Size = new System.Drawing.Size(56, 20);
            this.profileNameLabel.TabIndex = 1;
            this.profileNameLabel.Text = "Shrek";
            // 
            // copyToClipboard
            // 
            this.copyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.copyToClipboard.Location = new System.Drawing.Point(594, 361);
            this.copyToClipboard.Name = "copyToClipboard";
            this.copyToClipboard.Size = new System.Drawing.Size(123, 23);
            this.copyToClipboard.TabIndex = 2;
            this.copyToClipboard.Text = "Copy to Clipboard";
            this.copyToClipboard.UseVisualStyleBackColor = true;
            this.copyToClipboard.Click += new System.EventHandler(this.copyToClipboard_Click);
            // 
            // clipboardFlashLabel
            // 
            this.clipboardFlashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clipboardFlashLabel.AutoSize = true;
            this.clipboardFlashLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clipboardFlashLabel.ForeColor = System.Drawing.Color.Green;
            this.clipboardFlashLabel.Location = new System.Drawing.Point(467, 366);
            this.clipboardFlashLabel.Name = "clipboardFlashLabel";
            this.clipboardFlashLabel.Size = new System.Drawing.Size(121, 13);
            this.clipboardFlashLabel.TabIndex = 3;
            this.clipboardFlashLabel.Text = "Copied to clipboard!";
            this.clipboardFlashLabel.Visible = false;
            // 
            // clipboardFlasTimer
            // 
            this.clipboardFlasTimer.Interval = 2000;
            this.clipboardFlasTimer.Tick += new System.EventHandler(this.clipboardFlasTimer_Tick);
            // 
            // exportAsPlainTextCheckBox
            // 
            this.exportAsPlainTextCheckBox.AutoSize = true;
            this.exportAsPlainTextCheckBox.Location = new System.Drawing.Point(16, 32);
            this.exportAsPlainTextCheckBox.Name = "exportAsPlainTextCheckBox";
            this.exportAsPlainTextCheckBox.Size = new System.Drawing.Size(115, 17);
            this.exportAsPlainTextCheckBox.TabIndex = 4;
            this.exportAsPlainTextCheckBox.Text = "Export as plain text";
            this.exportAsPlainTextCheckBox.UseVisualStyleBackColor = true;
            this.exportAsPlainTextCheckBox.CheckedChanged += new System.EventHandler(this.exportAsPlainTextCheckBox_CheckedChanged);
            // 
            // ExportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 396);
            this.Controls.Add(this.exportAsPlainTextCheckBox);
            this.Controls.Add(this.clipboardFlashLabel);
            this.Controls.Add(this.copyToClipboard);
            this.Controls.Add(this.profileNameLabel);
            this.Controls.Add(this.profileTextBox);
            this.MaximizeBox = false;
            this.Name = "ExportDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Export Loadout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox profileTextBox;
        private System.Windows.Forms.Label profileNameLabel;
        private System.Windows.Forms.Button copyToClipboard;
        private System.Windows.Forms.Label clipboardFlashLabel;
        private System.Windows.Forms.Timer clipboardFlasTimer;
        private System.Windows.Forms.CheckBox exportAsPlainTextCheckBox;
    }
}
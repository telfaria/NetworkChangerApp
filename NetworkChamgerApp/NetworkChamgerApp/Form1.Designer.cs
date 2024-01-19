namespace NetworkChamgerApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboNetworAdapters = new ComboBox();
            txtNetworkAdapterSettings = new TextBox();
            cboProfiles = new ComboBox();
            SuspendLayout();
            // 
            // cboNetworAdapters
            // 
            cboNetworAdapters.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNetworAdapters.FormattingEnabled = true;
            cboNetworAdapters.Location = new Point(12, 29);
            cboNetworAdapters.Name = "cboNetworAdapters";
            cboNetworAdapters.Size = new Size(220, 23);
            cboNetworAdapters.TabIndex = 0;
            cboNetworAdapters.SelectedIndexChanged += cboNetworAdapters_SelectedIndexChanged;
            // 
            // txtNetworkAdapterSettings
            // 
            txtNetworkAdapterSettings.Location = new Point(12, 58);
            txtNetworkAdapterSettings.Multiline = true;
            txtNetworkAdapterSettings.Name = "txtNetworkAdapterSettings";
            txtNetworkAdapterSettings.ReadOnly = true;
            txtNetworkAdapterSettings.ScrollBars = ScrollBars.Both;
            txtNetworkAdapterSettings.Size = new Size(220, 158);
            txtNetworkAdapterSettings.TabIndex = 1;
            // 
            // cboProfiles
            // 
            cboProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProfiles.FormattingEnabled = true;
            cboProfiles.Location = new Point(283, 29);
            cboProfiles.Name = "cboProfiles";
            cboProfiles.Size = new Size(220, 23);
            cboProfiles.TabIndex = 0;
            cboProfiles.SelectedIndexChanged += cboNetworAdapters_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 310);
            Controls.Add(txtNetworkAdapterSettings);
            Controls.Add(cboProfiles);
            Controls.Add(cboNetworAdapters);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboNetworAdapters;
        private TextBox txtNetworkAdapterSettings;
        private ComboBox cboProfiles;
    }
}
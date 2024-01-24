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
            txtProfilesDetail = new TextBox();
            txtCommandResult = new TextBox();
            btnApply = new Button();
            SuspendLayout();
            // 
            // cboNetworAdapters
            // 
            cboNetworAdapters.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNetworAdapters.FormattingEnabled = true;
            cboNetworAdapters.Location = new Point(19, 48);
            cboNetworAdapters.Margin = new Padding(5, 5, 5, 5);
            cboNetworAdapters.Name = "cboNetworAdapters";
            cboNetworAdapters.Size = new Size(343, 33);
            cboNetworAdapters.TabIndex = 0;
            cboNetworAdapters.SelectedIndexChanged += cboNetworAdapters_SelectedIndexChanged;
            // 
            // txtNetworkAdapterSettings
            // 
            txtNetworkAdapterSettings.Location = new Point(19, 97);
            txtNetworkAdapterSettings.Margin = new Padding(5, 5, 5, 5);
            txtNetworkAdapterSettings.Multiline = true;
            txtNetworkAdapterSettings.Name = "txtNetworkAdapterSettings";
            txtNetworkAdapterSettings.ReadOnly = true;
            txtNetworkAdapterSettings.ScrollBars = ScrollBars.Both;
            txtNetworkAdapterSettings.Size = new Size(343, 261);
            txtNetworkAdapterSettings.TabIndex = 1;
            // 
            // cboProfiles
            // 
            cboProfiles.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProfiles.FormattingEnabled = true;
            cboProfiles.Location = new Point(445, 48);
            cboProfiles.Margin = new Padding(5, 5, 5, 5);
            cboProfiles.Name = "cboProfiles";
            cboProfiles.Size = new Size(343, 33);
            cboProfiles.TabIndex = 0;
            cboProfiles.SelectedIndexChanged += cboProfiles_SelectedIndexChanged;
            // 
            // txtProfilesDetail
            // 
            txtProfilesDetail.Location = new Point(445, 97);
            txtProfilesDetail.Margin = new Padding(5, 5, 5, 5);
            txtProfilesDetail.Multiline = true;
            txtProfilesDetail.Name = "txtProfilesDetail";
            txtProfilesDetail.ReadOnly = true;
            txtProfilesDetail.ScrollBars = ScrollBars.Both;
            txtProfilesDetail.Size = new Size(343, 261);
            txtProfilesDetail.TabIndex = 2;
            // 
            // txtCommandResult
            // 
            txtCommandResult.Location = new Point(19, 366);
            txtCommandResult.Multiline = true;
            txtCommandResult.Name = "txtCommandResult";
            txtCommandResult.ReadOnly = true;
            txtCommandResult.ScrollBars = ScrollBars.Both;
            txtCommandResult.Size = new Size(769, 166);
            txtCommandResult.TabIndex = 3;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(370, 48);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(75, 33);
            btnApply.TabIndex = 4;
            btnApply.Text = "<-";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(829, 544);
            Controls.Add(btnApply);
            Controls.Add(txtCommandResult);
            Controls.Add(txtProfilesDetail);
            Controls.Add(txtNetworkAdapterSettings);
            Controls.Add(cboProfiles);
            Controls.Add(cboNetworAdapters);
            DoubleBuffered = true;
            Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(5, 5, 5, 5);
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
        private TextBox txtProfilesDetail;
        private TextBox txtCommandResult;
        private Button btnApply;
    }
}
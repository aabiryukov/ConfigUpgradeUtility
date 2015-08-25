namespace UpgradeUtilityTestApp
{
	partial class Main
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
			this.InstalledVersionEdit = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.NewVersionEdit = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.InstalledFileEdit = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.NewFileEdit = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.UpgradeFileEdit = new System.Windows.Forms.TextBox();
			this.GoButton = new System.Windows.Forms.Button();
			this.LogEdit = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.OpenInstalledFileButton = new System.Windows.Forms.Button();
			this.OpenNewFileButton = new System.Windows.Forms.Button();
			this.OpenUpgradeFileButton = new System.Windows.Forms.Button();
			this.VersionInfoLabel = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.WorkFolderEdit = new System.Windows.Forms.TextBox();
			this.OpenWorkFolderButton = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.ShowHelpButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// InstalledVersionEdit
			// 
			this.InstalledVersionEdit.Location = new System.Drawing.Point(15, 36);
			this.InstalledVersionEdit.Name = "InstalledVersionEdit";
			this.InstalledVersionEdit.Size = new System.Drawing.Size(81, 20);
			this.InstalledVersionEdit.TabIndex = 1;
			this.InstalledVersionEdit.Text = "1.0.0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(84, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Installed Version";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "New Version";
			// 
			// NewVersionEdit
			// 
			this.NewVersionEdit.Location = new System.Drawing.Point(15, 89);
			this.NewVersionEdit.Name = "NewVersionEdit";
			this.NewVersionEdit.Size = new System.Drawing.Size(81, 20);
			this.NewVersionEdit.TabIndex = 6;
			this.NewVersionEdit.Text = "1.0.1";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(99, 20);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(87, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Installed XML file";
			// 
			// InstalledFileEdit
			// 
			this.InstalledFileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InstalledFileEdit.Location = new System.Drawing.Point(102, 36);
			this.InstalledFileEdit.Name = "InstalledFileEdit";
			this.InstalledFileEdit.Size = new System.Drawing.Size(466, 20);
			this.InstalledFileEdit.TabIndex = 3;
			this.InstalledFileEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(99, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "New XML file";
			// 
			// NewFileEdit
			// 
			this.NewFileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.NewFileEdit.Location = new System.Drawing.Point(102, 89);
			this.NewFileEdit.Name = "NewFileEdit";
			this.NewFileEdit.Size = new System.Drawing.Size(466, 20);
			this.NewFileEdit.TabIndex = 8;
			this.NewFileEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 117);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Upgrade file";
			// 
			// UpgradeFileEdit
			// 
			this.UpgradeFileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.UpgradeFileEdit.Location = new System.Drawing.Point(15, 133);
			this.UpgradeFileEdit.Name = "UpgradeFileEdit";
			this.UpgradeFileEdit.Size = new System.Drawing.Size(553, 20);
			this.UpgradeFileEdit.TabIndex = 11;
			this.UpgradeFileEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
			// 
			// GoButton
			// 
			this.GoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GoButton.Location = new System.Drawing.Point(523, 211);
			this.GoButton.Name = "GoButton";
			this.GoButton.Size = new System.Drawing.Size(75, 23);
			this.GoButton.TabIndex = 13;
			this.GoButton.Text = "&Go";
			this.GoButton.UseVisualStyleBackColor = true;
			this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
			// 
			// LogEdit
			// 
			this.LogEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.LogEdit.Location = new System.Drawing.Point(12, 240);
			this.LogEdit.Multiline = true;
			this.LogEdit.Name = "LogEdit";
			this.LogEdit.ReadOnly = true;
			this.LogEdit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.LogEdit.Size = new System.Drawing.Size(586, 165);
			this.LogEdit.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 224);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(25, 13);
			this.label6.TabIndex = 14;
			this.label6.Text = "Log";
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Filter = "XML files|*.config;*.xml;*.upgrade|All files|*.*";
			this.openFileDialog1.ShowReadOnly = true;
			// 
			// OpenInstalledFileButton
			// 
			this.OpenInstalledFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OpenInstalledFileButton.Location = new System.Drawing.Point(574, 33);
			this.OpenInstalledFileButton.Name = "OpenInstalledFileButton";
			this.OpenInstalledFileButton.Size = new System.Drawing.Size(24, 23);
			this.OpenInstalledFileButton.TabIndex = 4;
			this.OpenInstalledFileButton.Text = "...";
			this.OpenInstalledFileButton.UseVisualStyleBackColor = true;
			this.OpenInstalledFileButton.Click += new System.EventHandler(this.OpenInstalledFileButton_Click);
			// 
			// OpenNewFileButton
			// 
			this.OpenNewFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OpenNewFileButton.Location = new System.Drawing.Point(574, 89);
			this.OpenNewFileButton.Name = "OpenNewFileButton";
			this.OpenNewFileButton.Size = new System.Drawing.Size(24, 23);
			this.OpenNewFileButton.TabIndex = 9;
			this.OpenNewFileButton.Text = "...";
			this.OpenNewFileButton.UseVisualStyleBackColor = true;
			this.OpenNewFileButton.Click += new System.EventHandler(this.OpenNewFileButton_Click);
			// 
			// OpenUpgradeFileButton
			// 
			this.OpenUpgradeFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OpenUpgradeFileButton.Location = new System.Drawing.Point(574, 133);
			this.OpenUpgradeFileButton.Name = "OpenUpgradeFileButton";
			this.OpenUpgradeFileButton.Size = new System.Drawing.Size(24, 23);
			this.OpenUpgradeFileButton.TabIndex = 12;
			this.OpenUpgradeFileButton.Text = "...";
			this.OpenUpgradeFileButton.UseVisualStyleBackColor = true;
			this.OpenUpgradeFileButton.Click += new System.EventHandler(this.OpenUpgradeFileButton_Click);
			// 
			// VersionInfoLabel
			// 
			this.VersionInfoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.VersionInfoLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.VersionInfoLabel.Location = new System.Drawing.Point(355, 9);
			this.VersionInfoLabel.Name = "VersionInfoLabel";
			this.VersionInfoLabel.Size = new System.Drawing.Size(185, 15);
			this.VersionInfoLabel.TabIndex = 16;
			this.VersionInfoLabel.Text = "Version";
			this.VersionInfoLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 160);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Work folder:";
			// 
			// WorkFolderEdit
			// 
			this.WorkFolderEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WorkFolderEdit.Location = new System.Drawing.Point(15, 176);
			this.WorkFolderEdit.Name = "WorkFolderEdit";
			this.WorkFolderEdit.Size = new System.Drawing.Size(553, 20);
			this.WorkFolderEdit.TabIndex = 18;
			this.WorkFolderEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox_KeyDown);
			// 
			// OpenWorkFolderButton
			// 
			this.OpenWorkFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.OpenWorkFolderButton.Location = new System.Drawing.Point(574, 173);
			this.OpenWorkFolderButton.Name = "OpenWorkFolderButton";
			this.OpenWorkFolderButton.Size = new System.Drawing.Size(24, 23);
			this.OpenWorkFolderButton.TabIndex = 19;
			this.OpenWorkFolderButton.Text = "...";
			this.OpenWorkFolderButton.UseVisualStyleBackColor = true;
			this.OpenWorkFolderButton.Click += new System.EventHandler(this.OpenWorkFolderButton_Click);
			// 
			// ShowHelpButton
			// 
			this.ShowHelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ShowHelpButton.Location = new System.Drawing.Point(546, 4);
			this.ShowHelpButton.Name = "ShowHelpButton";
			this.ShowHelpButton.Size = new System.Drawing.Size(58, 23);
			this.ShowHelpButton.TabIndex = 20;
			this.ShowHelpButton.TabStop = false;
			this.ShowHelpButton.Text = "Help";
			this.ShowHelpButton.UseVisualStyleBackColor = true;
			this.ShowHelpButton.Click += new System.EventHandler(this.HelpButton_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 417);
			this.Controls.Add(this.ShowHelpButton);
			this.Controls.Add(this.OpenWorkFolderButton);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.WorkFolderEdit);
			this.Controls.Add(this.VersionInfoLabel);
			this.Controls.Add(this.OpenUpgradeFileButton);
			this.Controls.Add(this.OpenNewFileButton);
			this.Controls.Add(this.OpenInstalledFileButton);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.LogEdit);
			this.Controls.Add(this.GoButton);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.UpgradeFileEdit);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.NewFileEdit);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.InstalledFileEdit);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NewVersionEdit);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.InstalledVersionEdit);
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "Main";
			this.Text = "Test Upgrade Utility";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox InstalledVersionEdit;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox NewVersionEdit;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox InstalledFileEdit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox NewFileEdit;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox UpgradeFileEdit;
		private System.Windows.Forms.Button GoButton;
		private System.Windows.Forms.TextBox LogEdit;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button OpenInstalledFileButton;
		private System.Windows.Forms.Button OpenNewFileButton;
		private System.Windows.Forms.Button OpenUpgradeFileButton;
		private System.Windows.Forms.Label VersionInfoLabel;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox WorkFolderEdit;
		private System.Windows.Forms.Button OpenWorkFolderButton;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button ShowHelpButton;
	}
}


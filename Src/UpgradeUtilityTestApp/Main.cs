using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Sitronics.Installer.StsUpgradeUtility;

namespace UpgradeUtilityTestApp
{
	public partial class Main : Form
	{
		public Main()
		{
			InitializeComponent();

			VersionInfoLabel.Text = "Upgrade Engine v" +UpgradeUtilityInformation.Version;

            if (RegistrySettings.IsFirstRun())
            {
                var exampleDir = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "Example");

                InstalledFileEdit.Text = Path.Combine(exampleDir, "MyApplication.config.INSTALLED");
                NewFileEdit.Text = Path.Combine(exampleDir, "MyApplication.config.NEW");
                UpgradeFileEdit.Text = Path.Combine(exampleDir, "MyApplication.config.upgrade");
                WorkFolderEdit.Text = Path.Combine(Path.GetTempPath(), "UpgradeUtilityTest");

                NewVersionEdit.Text = "1.0";
                InstalledVersionEdit.Text = "1.1";
            }
            else
            {
                InstalledFileEdit.Text = RegistrySettings.ReadValue("InstalledFilePath");
                NewFileEdit.Text = RegistrySettings.ReadValue("NewFilePath");
                UpgradeFileEdit.Text = RegistrySettings.ReadValue("UpgradeFilePath");
                WorkFolderEdit.Text = RegistrySettings.ReadValue("WorkFolder");

                NewVersionEdit.Text = RegistrySettings.ReadValue("NewVersion");
                InstalledVersionEdit.Text = RegistrySettings.ReadValue("InstalledVersion");
            }


		    Logger.VerboseMode = true;
            Logger.OnLogMessage += OnLogMessage;
        }

        private void OnLogMessage(LogMessageType msgType, string message)
        {
            LogWriteLine(
                String.Format(CultureInfo.InvariantCulture, "{0,7}: {1}",
                              msgType,
                              message
                    )
                );
        }

		private bool DoOpenFileDialog(Control textBox)
		{
			if (!string.IsNullOrEmpty(textBox.Text))
			{
				openFileDialog1.InitialDirectory = Path.GetDirectoryName(textBox.Text);
			}

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				textBox.Text = openFileDialog1.FileName;
				return true;
			}

			return false;
		}

		private void OpenInstalledFileButton_Click(object sender, EventArgs e)
		{
			if(DoOpenFileDialog(InstalledFileEdit))
			{
				UpgradeFileEdit.Text = InstalledFileEdit.Text + ".upgrade";
			}
		}

		private void OpenWorkFolderButton_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(WorkFolderEdit.Text))
			{
				folderBrowserDialog1.SelectedPath = WorkFolderEdit.Text;
			}

			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				WorkFolderEdit.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void OpenNewFileButton_Click(object sender, EventArgs e)
		{
			DoOpenFileDialog(NewFileEdit);
		}

		private void OpenUpgradeFileButton_Click(object sender, EventArgs e)
		{
			DoOpenFileDialog(UpgradeFileEdit);
		}

		private bool CheckTextBox(Control textBox, string fieldName)
		{
			if (string.IsNullOrEmpty(textBox.Text))
			{
				MessageBox.Show(fieldName + " cannot be empty");
				ActiveControl = WorkFolderEdit;
				return false;
			}

			return true;
		}

		private void LogWriteLine(string message)
		{
			LogEdit.AppendText(message);
			LogEdit.AppendText("\r\n");
		}

		private void GoButton_Click(object sender, EventArgs e)
		{
			LogEdit.Clear();


			LogWriteLine("Validating parameters");
			if (!CheckTextBox(InstalledVersionEdit, "Installed Version"))
				return;

			if (!CheckTextBox(InstalledFileEdit, "Installed File"))
				return;


			if (!CheckTextBox(NewVersionEdit, "New Version"))
				return;

			if (!CheckTextBox(NewFileEdit, "New File"))
				return;


			if (!CheckTextBox(UpgradeFileEdit, "Upgrade File"))
				return;

			if (!CheckTextBox(WorkFolderEdit, "Work Folder"))
				return;

			{
				RegistrySettings.SaveValue("InstalledFilePath", InstalledFileEdit.Text);
				RegistrySettings.SaveValue("NewFilePath", NewFileEdit.Text);
				RegistrySettings.SaveValue("UpgradeFilePath", UpgradeFileEdit.Text);
				RegistrySettings.SaveValue("WorkFolder", WorkFolderEdit.Text);

				RegistrySettings.SaveValue("NewVersion", NewVersionEdit.Text);
				RegistrySettings.SaveValue("InstalledVersion", InstalledVersionEdit.Text);
			}

			if(!Directory.Exists(WorkFolderEdit.Text))
			{
				LogWriteLine("Creating work folder");
				Directory.CreateDirectory(WorkFolderEdit.Text);
			}

			var targetFile = Path.Combine(WorkFolderEdit.Text, Path.GetFileName(InstalledFileEdit.Text) + ".UPGRADED");

			LogWriteLine("Copying installed file to target");
			File.Copy(InstalledFileEdit.Text, targetFile, true);
			File.SetAttributes(targetFile, FileAttributes.Normal);

			var fileList = new List<TargetFileInfo>
				               	{
				               		new TargetFileInfo(
				               			targetFile,
				               			UpgradeFileEdit.Text
				               			)
				               	};

			var parameters = new RunParameters(
				"TestProduct",
				new InstallerVersion(NewVersionEdit.Text),
				new InstallerVersion(InstalledVersionEdit.Text),
				fileList);

			{
				LogWriteLine("Processing Backup Stage...");
				var stageBackup = new StageBackup(parameters);
				var retCode = stageBackup.Run();
				if(retCode != 0)
				{
					LogWriteLine("Backup Stage FAILED: " + retCode);
					return;
				}
			}

			LogWriteLine("Copying new file to target");
			File.Copy(NewFileEdit.Text, targetFile, true);
			File.SetAttributes(targetFile, FileAttributes.Normal);

			{
				LogWriteLine("Processing Upgrade Stage...");
				var stageUpgrade = new StageUpgrade(parameters, null);
				var retCode = stageUpgrade.Run();
				if (retCode != 0)
				{
					LogWriteLine("Upgrade Stage FAILED: " + retCode);
					return;
				}
			}

			LogWriteLine("Successfully completed.");
			LogWriteLine("");
			LogWriteLine("See target file: " + targetFile);
		}

		private void HelpButton_Click(object sender, EventArgs e)
		{
			Process.Start("https://wiki.bss.nvision-group.com/display/def/Upgrade+Utility");
		}

		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			var textBox = sender as TextBox;
			if (textBox == null || string.IsNullOrEmpty(textBox.Text))
				return;

			if (e.Shift && e.KeyCode == Keys.Enter)
			{
				var directory = textBox.Text.Contains(".") ? Path.GetDirectoryName(textBox.Text) : textBox.Text;
				if (directory != null)
					Process.Start(directory);
			}
		}
	}
}

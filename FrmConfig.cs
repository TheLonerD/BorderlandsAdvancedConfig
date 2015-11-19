using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using BorderlandsAdvancedConfig.INIParser;
using BorderlandsAdvancedConfig.SettingsManagers;

namespace BorderlandsAdvancedConfig
{
	public partial class FrmConfig : Form
	{
		public delegate void SetProgressDeleg(int percent, string text);
		public delegate void HideDeleg();

		private FrmLoad frmLoad = new FrmLoad();
		private Thread loadingThread;

		private PathSettings pathSettings = new PathSettings();

		private EngineSettingsManager EngineManager;
		private InputSettingsManager InputManager;
		private GameSettingsManager GameManager;

		private const string codeRepository = "https://github.com/TheLonerD/BorderlandsAdvancedConfig";

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		private void SetProgress(int percent, string text)
		{
			try
			{
				frmLoad.Invoke(new SetProgressDeleg(frmLoad.setProgress), new object[] { percent, text });
			}
			catch { }
		}

		private void HideLoading()
		{
			try
			{
				frmLoad.Invoke(new HideDeleg(frmLoad.Hide));
				this.BringToFront();
			}
			catch { }
		}

		private void ShowLoadingForm()
		{
			frmLoad.ShowDialog();
		}

		public FrmConfig()
		{
			InitializeComponent();

			loadingThread = new Thread(new ThreadStart(ShowLoadingForm));
			loadingThread.Start();

			if (!InitializeSettingsDirectory())
			{
				Environment.Exit(10);
			}

			BackupFiles(false);

			if (!ParseConfigFiles())
			{
				Environment.Exit(30);
			}

			this.Text = String.Format("Borderlands Advanced Settings Version {0} by isNull(MDK)", AssemblyVersion);

			log("> Reading settings...");
			ReadSettings();

			log("Checking for updates...");
			UpdateBackgroundWorker.RunWorkerAsync();
			log("> Ready");
		}

		public void log(string logTxt)
		{
			txtLog.AppendText(logTxt + Environment.NewLine);

			txtLog.SelectionStart = txtLog.Text.Length;
			txtLog.ScrollToCaret();
		}

		private void BackupFiles(bool forceBackup)
		{
			string backupDir = Path.Combine(pathSettings.SettingsDir, "Backup");

			if (!Directory.Exists(backupDir))
			{
				Directory.CreateDirectory(backupDir);
			}

			DirectoryInfo sourceDir = new DirectoryInfo(pathSettings.SettingsDir);
			DirectoryInfo destDir = new DirectoryInfo(backupDir);

			foreach (FileInfo fi in sourceDir.GetFiles("*.ini"))
			{
				if (fi.IsReadOnly)
				{
					fi.IsReadOnly = false;
				}

				if (!File.Exists(Path.Combine(destDir.FullName, fi.Name)) || forceBackup)
				{
					fi.CopyTo(Path.Combine(destDir.FullName, fi.Name), true);
				}
			}
		}

		private void RestoreFiles()
		{
			string backupDir = Path.Combine(pathSettings.SettingsDir, "Backup");

			if (!Directory.Exists(backupDir))
			{
				MessageBox.Show("Oh oh, backup directory not found. Cannot restore.", "Backup files not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			DirectoryInfo destDir = new DirectoryInfo(pathSettings.SettingsDir);
			DirectoryInfo sourceDir = new DirectoryInfo(backupDir);

			string destPath;

			foreach (FileInfo fi in sourceDir.GetFiles("*.ini"))
			{
				destPath = Path.Combine(destDir.FullName, fi.Name);
				if (File.Exists(destPath))
				{
					FileInfo fInfo = new FileInfo(destPath);
					fInfo.IsReadOnly = false;
					fInfo = null;
					File.Delete(destPath);
				}

				fi.CopyTo(destPath, true);
			}

			log("> Backup Restored.");
			MessageBox.Show("Backup Restored. Exiting.", "Original files restored", MessageBoxButtons.OK, MessageBoxIcon.Information);
			Environment.Exit(0);
		}

		private bool ParseConfigFiles()
		{
			try
			{
				SetProgress(0, "Loading Engine Settings...");
				EngineManager = new EngineSettingsManager(new INIFileParser(pathSettings.EngineIniPath));

				SetProgress(25, "Loading Input Settings...");
				InputManager = new InputSettingsManager(new INIFileParser(pathSettings.InputIniPath));

				SetProgress(50, "Loading Game Settings. This will take a while. Please wait...");
				GameManager = new GameSettingsManager(new INIFileParser(pathSettings.GameIniPath));

				SetProgress(100, "Done.");
				HideLoading();
			}
			catch
			{
				return false;
			}
			return true;
		}

		private bool InitializeSettingsDirectory()
		{
			if (string.IsNullOrEmpty(pathSettings.SettingsDir))
			{
				DialogResult result = MessageBox.Show(LocalizedStrings.ConfigNotFound, "Config files not found", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

				if (result == DialogResult.Yes)
				{
					DialogResult browseResult = SettingsDirBrowser.ShowDialog();

					if (browseResult == DialogResult.OK)
					{
						if (pathSettings.SetSettingsDir(SettingsDirBrowser.SelectedPath))
						{
							return true;
						}
						else
						{
							MessageBox.Show("Config files not found at the selected path.", "Bad directory", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}
			}
			else
			{
				return true;
			}

			return false;
		}

		private void ReadSettings()
		{
			LoadEngineSection();
			LoadInputSection();
			LoadGameSection();
		}

		private void SaveSettings()
		{
			SaveEngineSection();
			SaveInputSection();
			SaveGameSection();

			log("> Saved. Have fun playing!");
			MessageBox.Show("Settings Saved. Have fun!", "Save settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void LoadInputSection()
		{
			chkF9Hud.Checked = InputManager.SetF9ShowHud;

			try
			{
				chkFOVAdjust.Checked = InputManager.FovKeysEnabled();
				if (chkFOVAdjust.Checked)
				{
					txtF10Fov.Text = InputManager.GetF10Fov().Value.ToString();
					txtF11Fov.Text = InputManager.GetF11Fov().Value.ToString();
				}
				chkFOVAdjust_CheckedChanged(this, null);
			}
			catch
			{
				chkFOVAdjust.Enabled = false;
				txtF10Fov.Enabled = false;
				txtF11Fov.Enabled = false;
			}

			chkF12Fps.Checked = InputManager.SetF12ShowFPS;

			chkDisableMouseSmooth.Checked = !InputManager.EnableMouseSmoothing;
			chkConsole.Checked = InputManager.Console;

			chkZoomToggle.Checked = InputManager.ZoomToggle;
			chkCrouchToggle.Checked = InputManager.CrouchToggle;
			chkScrollWheel.Checked = InputManager.ScrollWheel;
		}

		private void SaveInputSection()
		{
			InputManager.SetF9ShowHud = chkF9Hud.Checked;

			if (chkFOVAdjust.Enabled)
			{
				if (chkFOVAdjust.Checked && !string.IsNullOrEmpty(txtF10Fov.Text) && !string.IsNullOrEmpty(txtF11Fov.Text))
				{
					InputManager.SetKeyFov("F10", int.Parse(txtF10Fov.Text));
					InputManager.SetKeyFov("F11", int.Parse(txtF11Fov.Text));
				}
				else if (!chkFOVAdjust.Checked)
				{
					InputManager.RemoveBinding("F10");
					InputManager.RemoveBinding("F11");
				}
			}

			InputManager.SetF12ShowFPS = chkF12Fps.Checked;

			InputManager.EnableMouseSmoothing = !chkDisableMouseSmooth.Checked;
			InputManager.Console = chkConsole.Checked;

			InputManager.ZoomToggle = chkZoomToggle.Checked;
			InputManager.CrouchToggle = chkCrouchToggle.Checked;
			InputManager.ScrollWheel = chkScrollWheel.Checked;


			InputManager.Save();
		}

		private void LoadGameSection()
		{
			trkPlayerInfoMaxDist.Value = GameManager.PlayerInfoMaxDist;
		}

		private void SaveGameSection()
		{
			GameManager.PlayerInfoMaxDist = trkPlayerInfoMaxDist.Value;

			GameManager.Save();
		}

		private void LoadEngineSection()
		{
			chkAmbient.Checked = EngineManager.Ambient;
			chkHBloom.Checked = EngineManager.HighQualityBloom;
			chkVsync.Checked = EngineManager.Vsync;
			chkPhysX.Checked = EngineManager.AllowPhysX;
			chkSmoothFrameRate.Checked = EngineManager.SmoothFrameRate;
			try
			{
				chkDisableStartup.Checked = EngineManager.StartupMovies;
			}
			catch
			{
				chkDisableStartup.Enabled = false;
			}
			chkOutlines.Checked = EngineManager.DisableOutlineShader;

			trkMaxAnsio.Value = 0;
			if (EngineManager.MaxAnisotropy != 0)
			{
				trkMaxAnsio.Value = (int)Math.Log(EngineManager.MaxAnisotropy, 2);
			}
			trkMaxAniso_Scroll(this, null);

			trkMaxAA.Value = 0;
			if (EngineManager.MaxMultisamples != 0)
			{
				trkMaxAA.Value = (int)Math.Log(EngineManager.MaxMultisamples, 2);
			}
			trkMaxAA_Scroll(this, null);

			txtWidth.Text = EngineManager.ResX.ToString();
			txtHeight.Text = EngineManager.ResY.ToString();
			txtScreenPercentage.Text = EngineManager.ScreenPercentage.ToString();

			chkDisablevchat.Checked = !EngineManager.HasVoiceEnabled;
		}

		private void SaveEngineSection()
		{
			EngineManager.Ambient = chkAmbient.Checked;
			EngineManager.HighQualityBloom = chkHBloom.Checked;
			EngineManager.Vsync = chkVsync.Checked;
			EngineManager.AllowPhysX = chkPhysX.Checked;
			EngineManager.SmoothFrameRate = chkSmoothFrameRate.Checked;
			if (chkDisableStartup.Enabled)
			{
				EngineManager.StartupMovies = !chkDisableStartup.Checked;
			}
			EngineManager.DisableOutlineShader = chkOutlines.Checked;

			if (trkMaxAnsio.Value != 0)
			{
				EngineManager.MaxAnisotropy = (short)Math.Pow(2, trkMaxAnsio.Value);
			}
			else
			{
				EngineManager.MaxAnisotropy = 0;
			}

			if (trkMaxAA.Value != 0)
			{
				EngineManager.MaxMultisamples = (short)Math.Pow(2, trkMaxAA.Value);
			}
			else
			{
				EngineManager.MaxMultisamples = 0;
			}

			EngineManager.ResX = int.Parse(txtWidth.Text);
			EngineManager.ResY = int.Parse(txtHeight.Text);
			EngineManager.ScreenPercentage = int.Parse(txtScreenPercentage.Text);

			EngineManager.HasVoiceEnabled = !chkDisablevchat.Checked;

			EngineManager.Save();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

		private void trkMaxAniso_Scroll(object sender, EventArgs e)
		{
			double Ansiovalue = 0;

			if (trkMaxAnsio.Value != 0)
				Ansiovalue = Math.Pow(2, trkMaxAnsio.Value);

			lblMaxAnsio.Text = string.Format("Max Aniso Filtering: {0}x", Ansiovalue);
		}

		private void trkMaxAA_Scroll(object sender, EventArgs e)
		{
			double AAValue = 0;

			if (trkMaxAA.Value != 0)
				AAValue = Math.Pow(2, trkMaxAA.Value);

			lblMaxAA.Text = string.Format("Max Anti Aliasing: {0}x", AAValue);
		}

		private void chkFOVAdjust_CheckedChanged(object sender, EventArgs e)
		{
			if (chkFOVAdjust.Checked)
			{
				txtF10Fov.Text = "90";
				txtF11Fov.Text = "110";
			}

			txtF10Fov.Enabled = chkFOVAdjust.Checked;
			txtF11Fov.Enabled = chkFOVAdjust.Checked;
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			RestoreFiles();
		}

		private void lnkOfficialThread_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(codeRepository);
		}

		private void btnAbout_Click(object sender, EventArgs e)
		{
			AboutBox ab = new AboutBox();
			ab.Show();
		}

		private void chkVsync_CheckedChanged(object sender, EventArgs e)
		{
			if (!chkVsync.Checked)
			{
				chkSmoothFrameRate.Enabled = true;
				chkSmoothFrameRate.Checked = true;
			}
			else
			{
				chkSmoothFrameRate.Enabled = false;
				chkSmoothFrameRate.Checked = true;
			}
		}

		private void UpdateBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			VersionCheck versionCheck = new VersionCheck(codeRepository);
		}
	}
}

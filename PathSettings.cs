///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using System;
using System.IO;

namespace BorderlandsAdvancedConfig
{
	public class PathSettings
	{
		private const string EngineIni = "WillowEngine.ini";
		private const string InputIni = "WillowInput.ini";
		private const string GameIni = "WillowGame.ini";

		private const string GameConfigSubDir = "My Games\\Borderlands\\WillowGame\\Config";
		private string DefaultSettingsDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), GameConfigSubDir);

		public string EngineIniPath
		{
			get
			{
				return SettingsDir + Path.DirectorySeparatorChar + EngineIni;
			}
		}

		public string InputIniPath
		{
			get
			{
				return SettingsDir + Path.DirectorySeparatorChar + InputIni;
			}
		}

		public string GameIniPath
		{
			get
			{
				return SettingsDir + Path.DirectorySeparatorChar + GameIni;
			}
		}

		private string _settingsDir;
		public string SettingsDir
		{
			get
			{
				if (String.IsNullOrEmpty(_settingsDir))
				{
					if (Directory.Exists(DefaultSettingsDir))
					{
						_settingsDir = DefaultSettingsDir;
					}

					return _settingsDir;
				}
				else
				{
					return _settingsDir;
				}
			}
		}

		public bool SetSettingsDir(string SettingsDirectory)
		{
			try
			{
				string EngineCheck = SettingsDirectory + Path.DirectorySeparatorChar + EngineIni;
				string InputCheck = SettingsDirectory + Path.DirectorySeparatorChar + InputIni;
				string GameCheck = SettingsDirectory + Path.DirectorySeparatorChar + GameIni;

				if (File.Exists(EngineCheck) && File.Exists(InputCheck) && File.Exists(GameCheck))
				{
					_settingsDir = SettingsDirectory;
					return true;
				}
				else
				{
					_settingsDir = string.Empty;
					return false;
				}
			}
			catch
			{
				_settingsDir = string.Empty;
				return false;
			}
		}
	}
}

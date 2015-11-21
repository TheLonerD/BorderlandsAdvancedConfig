///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using BorderlandsAdvancedConfig.INIParser;

namespace BorderlandsAdvancedConfig.SettingsManagers
{
    public class EngineSettingsManager
    {
        private const string OutLineShaderString = "WillowEngineMaterials.WillowScenePostProcess";

        private INIFileParser EngineParser;

        public EngineSettingsManager(INIFileParser engineParser)
        {
            this.EngineParser = engineParser;
        }

        internal bool Ambient
        {
            get
            {
                return bool.Parse(EngineParser.GetSetting("SystemSettings", "AmbientOcclusion", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "AmbientOcclusion", 0, value.ToString());
            }
        }

        internal bool HighQualityBloom
        {
            get
            {
                return bool.Parse(EngineParser.GetSetting("SystemSettings", "UseHighQualityBloom", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "UseHighQualityBloom", 0, value.ToString());
            }
        }

        internal bool Vsync
        {
            get
            {
                return bool.Parse(EngineParser.GetSetting("SystemSettings", "UseVsync", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "UseVsync", 0, value.ToString());
            }
        }

        internal bool AllowPhysX
        {
            get
            {
                return bool.Parse(EngineParser.GetSetting("SystemSettings", "AllowD3D10", 0).value) && !bool.Parse(EngineParser.GetSetting("Engine.Engine", "bDisablePhysXHardwareSupport", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "AllowD3D10", 0, value.ToString());
                EngineParser.SetSetting("Engine.Engine", "bDisablePhysXHardwareSupport", 0, (!value).ToString());
            }
        }

        internal bool SmoothFrameRate
        {
            get
            {
                return bool.Parse(EngineParser.GetSetting("Engine.GameEngine", "bSmoothFrameRate", 0).value);
            }
            set
            {
                EngineParser.SetSetting("Engine.GameEngine", "bSmoothFrameRate", 0, value.ToString());
            }
        }

        internal bool StartupMovies
        {
            get
            {
                ConfigEntry regularlogo = EngineParser.GetSetting("FullScreenMovie", "StartupMovies", 0);
                return regularlogo.isCommented;
            }
            set
            {
                bool currentSetting = StartupMovies;
                if (value == false && !currentSetting)
                {
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 0, "//");
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 1, "//");
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 2, "//");
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 3, "//");
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 0, "//");
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 1, "//");
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 2, "//");
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 3, "//");
                }
                else if (value == true && currentSetting)
                {
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 0, null);
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 1, null);
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 2, null);
                    EngineParser.SetSettingComment("FullScreenMovie", "StartupMovies", 3, null);
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 0, null);
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 1, null);
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 2, null);
                    EngineParser.SetSettingComment("FullScreenMovie", "SkippableMovies", 3, null);
                }
            }
        }

        internal short MaxAnisotropy
        {
            get
            {
                return short.Parse(EngineParser.GetSetting("SystemSettings", "MaxAnisotropy", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "MaxAnisotropy", 0, value.ToString());
            }
        }

        internal short MaxMultisamples
        {
            get
            {
                return short.Parse(EngineParser.GetSetting("SystemSettings", "MaxMultisamples", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "MaxMultisamples", 0, value.ToString());
            }
        }

        internal int ResX
        {
            get
            {
                return int.Parse(EngineParser.GetSetting("SystemSettings", "ResX", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "ResX", 0, value.ToString());
            }
        }

        internal int ResY
        {
            get
            {
                return int.Parse(EngineParser.GetSetting("SystemSettings", "ResY", 0).value);
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "ResY", 0, value.ToString());
            }
        }

        internal int ScreenPercentage
        {
            get
            {
                bool parseRes;
                double result;
                parseRes = double.TryParse(EngineParser.GetSetting("SystemSettings", "ScreenPercentage", 0).value, out result);

                if (parseRes)
                {
                    return (int)result;
                }
                else
                {
                    return 100;
                }
            }
            set
            {
                EngineParser.SetSetting("SystemSettings", "ScreenPercentage", 0, value.ToString("N6"));
            }
        }

        internal bool HasVoiceEnabled
        {
            get
            {
                return bool.Parse(EngineParser.GetSetting("VoIP", "bHasVoiceEnabled", 0).value);
            }
            set
            {
                EngineParser.SetSetting("VoIP", "bHasVoiceEnabled", 0, value.ToString());
            }
        }

        internal bool DisableOutlineShader
        {
            get
            {
                return EngineParser.GetSetting("Engine.Engine", "DefaultPostProcessName", 0).value.Equals("WillowEngineMaterials.WillowScenePostProcess_cinematic");
            }
            set
            {
                if (value == true)
                {
                    EngineParser.SetSetting("Engine.Engine", "DefaultPostProcessName", 0, "WillowEngineMaterials.WillowScenePostProcess_cinematic");
                }
                else
                {
                    EngineParser.SetSetting("Engine.Engine", "DefaultPostProcessName", 0, OutLineShaderString);
                }
            }
        }

        internal void Save()
        {
            EngineParser.SaveSettings();
        }
    }
}

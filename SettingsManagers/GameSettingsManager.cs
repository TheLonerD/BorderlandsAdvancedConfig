///Borderlands Advanced Settings Tool
///Developed By Babak B. MDKv4
///Code Release Date: 9/12/2010

using BorderlandsAdvancedConfig.INIParser;

namespace BorderlandsAdvancedConfig.SettingsManagers
{
    public class GameSettingsManager
    {
        private INIFileParser GameParser;

        public GameSettingsManager(INIFileParser gameParser)
        {
            this.GameParser = gameParser;
        }

        internal int PlayerInfoMaxDist
        {
            get
            {
                return int.Parse(GameParser.GetSetting("WillowGame.WillowHUD", "PlayerInfoMaxDist", 0).value);
            }
            set
            {
                GameParser.SetSetting("WillowGame.WillowHUD", "PlayerInfoMaxDist", 0, value.ToString());
            }
        }

        internal void Save()
        {
            GameParser.SaveSettings();
        }
    }
}

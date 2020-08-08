using System.Configuration;

namespace CoH2ReplaySaver
{
    public class ConfigHelper
    {
        public const string REPLAYS_DIRECTORY_PATH_KEY = "ReplaysDirectoryPath";
        public const string REPLAY_FILE_NAME_FORMAT_KEY = "ReplayFileNameFormat";

        public static string GetReplaysDirectoryPath()
        {
            return ConfigurationManager.AppSettings[REPLAYS_DIRECTORY_PATH_KEY];
        }

        public static string GetReplayFileNameFormat()
        {
            return ConfigurationManager.AppSettings[REPLAY_FILE_NAME_FORMAT_KEY];
        }
    }
}

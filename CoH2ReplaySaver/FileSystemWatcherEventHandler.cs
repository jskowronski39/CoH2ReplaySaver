using System;
using System.IO;
using NLog;

namespace CoH2ReplaySaver
{
    public class FileSystemWatcherEventHandler
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static void OnChanged(object source, FileSystemEventArgs e)
        {
            var createdReplay = new FileInfo(e.FullPath);

            // Do nothing if new empty replay file was created on match start.
            if (createdReplay.Length == 0) return;

            var replaysDirectoryPath = Path.GetDirectoryName(e.FullPath);
            var currentDateTimeString = DateTime.Now.ToString(ConfigHelper.GetReplayFileNameFormat());
            var fileName = $"{currentDateTimeString}.rec";
            var targetFilePath = Path.Combine(replaysDirectoryPath, fileName);

            // Do nothing if replay was already saved.
            // This prevent copying replay multiple times due to events being triggered more than once.
            if (File.Exists(targetFilePath)) return;

            try
            {
                Console.WriteLine("New replay found. Saving...");
                createdReplay.CopyTo(targetFilePath);
                Console.WriteLine($"Replay saved: \"{fileName}\"");
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error while saving replay. See log for details.");
                Logger.Error(ex);
            }
        }
    }
}

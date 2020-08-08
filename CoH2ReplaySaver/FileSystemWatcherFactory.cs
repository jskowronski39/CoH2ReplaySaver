using System;
using System.IO;

namespace CoH2ReplaySaver
{
    public class FileSystemWatcherFactory
    {
        public const string FILE_TO_WATCH = "temp.rec";

        public static FileSystemWatcher create(
            string replaysDirectoryPath,
            FileSystemEventHandler onChangedEventHandler
        )
        {
            var watcher = new FileSystemWatcher();

            if (replaysDirectoryPath == "") replaysDirectoryPath = GetDefaultReplaysDirectoryPath();

            watcher.Path = replaysDirectoryPath;
            watcher.NotifyFilter = NotifyFilters.Size;
            watcher.Filter = FILE_TO_WATCH;
            watcher.Changed += onChangedEventHandler;
            watcher.EnableRaisingEvents = true;

            return watcher;
        }

        private static string GetDefaultReplaysDirectoryPath()
        {
            var myDocumentsPathDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var defaultReplaysDirectoryPat = Path.Combine(myDocumentsPathDirectoryPath, @"My Games\Company of Heroes 2\playback");

            return defaultReplaysDirectoryPat;
        }
    }
}

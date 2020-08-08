using System;
using System.IO;

namespace CoH2ReplaySaver
{
    internal class Program
    {
        private static ConsoleKeyInfo _consoleKeyInfo;

        public static void Main(string[] args)
        {
            var onChangedEventHandler = new FileSystemEventHandler(FileSystemWatcherEventHandler.OnChanged);
            FileSystemWatcherFactory.create(ConfigHelper.GetReplaysDirectoryPath(), onChangedEventHandler);

            Console.WriteLine("Watching for new replays...");
            Console.WriteLine("Press \"q\" to close application");

            do
            {
                _consoleKeyInfo = Console.ReadKey();
            } while (_consoleKeyInfo.Key != ConsoleKey.Q);
        }
    }
}

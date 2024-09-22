using System.Collections.Concurrent;

namespace PicKeyFinder.Code.Modules
{
    public enum LogLevel
    {
        Info,
        Warning,
        Error
    }

    internal class Logger
    {
        private static ConcurrentQueue<(LogLevel Level, string Message)> logList = new();
        private static bool isLogging = false;

        public static void LogSystemMessage(LogLevel level, string message)
        {
            logList.Enqueue((level, message));
            _ = StartLogging();
        }

        private static async Task StartLogging()
        {
            if (isLogging) return;
            isLogging = true;

            while (logList.TryDequeue(out var logEntry))
            {
                await WriteLogToFile(logEntry.Level, logEntry.Message);
            }

            isLogging = false;
        }

        private static async Task WriteLogToFile(LogLevel level, string message)
        {
            string logLine = $"{DateTime.Now}: [{level}] {message}{Environment.NewLine}";
            await File.AppendAllTextAsync("log.txt", logLine);
        }
    }
}

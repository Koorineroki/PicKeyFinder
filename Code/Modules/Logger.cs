using System.Collections.Concurrent;

namespace PicKeyFinder.Code.Modules
{
    public enum LogLevel
    {
        None,
        Info,
        Warning,
        Error
    }

    internal static class Logger
    {
        private static ConcurrentQueue<(LogLevel Level, string Message, string FileName)> logList = new();
        private static bool isLogging = false;
        private static string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        // Log System Message
        public static void LogSystemMessage(LogLevel level, string message)
        {
            Console.WriteLine(message);
            logList.Enqueue((level, message, "SystemLogs.txt"));
            _ = StartLogging();
        }

        // Log Message
        public static void LogMessage(string message, string fileName)
        {
            logList.Enqueue((LogLevel.None, message, fileName));
            _ = StartLogging();
        }

        // Start log method
        private static async Task StartLogging()
        {
            if (isLogging) return;
            isLogging = true;

            while (logList.TryDequeue(out var logEntry))
            {
                await WriteLogToFile(logEntry.Level, logEntry.Message, logEntry.FileName);
            }

            isLogging = false;
        }

        // Start log message in File
        private static async Task WriteLogToFile(LogLevel level, string message, string filename)
        {
            Directory.CreateDirectory(logPath);
            var logFilePath = Path.Combine(logPath, filename);

            string logLine;
            if (level != LogLevel.None) logLine = $"{DateTime.Now}: 【{level}】{message}{Environment.NewLine}";
            else logLine = $"{message}{Environment.NewLine}";


            await File.AppendAllTextAsync(logFilePath, logLine);
        }
    }
}

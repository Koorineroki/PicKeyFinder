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
        private ConcurrentQueue<(LogLevel Level, string Message)> logList = new();
        private bool isLogging = false;
        private string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        private string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "Log.txt");

        // LogMessage
        public void LogSystemMessage(LogLevel level, string message)
        {
            logList.Enqueue((level, message));
            _ = StartLogging();
        }

        // Start log method
        private async Task StartLogging()
        {
            if (isLogging) return;
            isLogging = true;

            while (logList.TryDequeue(out var logEntry))
            {
                await WriteLogToFile(logEntry.Level, logEntry.Message);
            }

            isLogging = false;
        }

        // Start log message in File
        private async Task WriteLogToFile(LogLevel level, string message)
        {
            string logLine = $"{DateTime.Now}: 【{level}]】{message}{Environment.NewLine}";
            Directory.CreateDirectory(logPath);
            await File.AppendAllTextAsync(logFilePath, logLine);
        }
    }
}

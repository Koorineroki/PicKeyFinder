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

    internal class Logger
    {
        private ConcurrentQueue<(LogLevel Level, string Message, string FileName)> logList = new();
        private bool isLogging = false;
        private string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        // LogMessage
        public void LogSystemMessage(LogLevel level, string message)
        {
            logList.Enqueue((level, message, "SystemLogs.txt"));
            _ = StartLogging();
        }

        // LogMessage
        public void LogMessage(string message, string fileName)
        {
            logList.Enqueue((LogLevel.None, message, fileName));
            _ = StartLogging();
        }

        // Start log method
        private async Task StartLogging()
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
        private async Task WriteLogToFile(LogLevel level, string message, string filename)
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

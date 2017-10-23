using System;
using System.IO;
using NBautoFramework.Config;

namespace NBautoFramework.Helpers
{
    /// <summary>
    /// Log Helper
    /// </summary>
    public class LogHelpers
    {
        private static readonly string _LogFileName = $"{DateTime.Now:yyyy MMMM dd}";
        private static StreamWriter _StreamW;

        /// <summary>
        /// Create Log File
        /// </summary>
        public static void CreateLogFile()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory + Settings.LogsFolder;
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            _StreamW = File.AppendText(dir + _LogFileName + ".log");
        }

        /// <summary>
        /// Write the Text in the log file
        /// </summary>
        /// <param name="logMessage"></param>
        public static void Write(string logMessage)
        {
            if (!string.IsNullOrWhiteSpace(logMessage) && Settings.IsToLog)
            {
                if (_StreamW == null)
                {
                    CreateLogFile();
                }
                _StreamW?.WriteLine($"{DateTime.Now.ToLongTimeString()} - {DateTime.Now.ToLongDateString()}");
                _StreamW?.WriteLine($"{logMessage}");
                _StreamW?.Flush();
            }
        }
    }
}

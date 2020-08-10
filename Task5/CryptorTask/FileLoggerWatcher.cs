using System.IO;

namespace CryptorTask
{
    public class FileLoggerWatcher : ILoggerWatcher
    {
        private readonly string _path;

        public FileLoggerWatcher(string path)
        {
            _path = path;
        }
        private void Log(string message)
        {
            if (!File.Exists(_path))
            {
                using (File.CreateText(_path)) { }
            }

            using (StreamWriter sw = new StreamWriter(_path, true))
            {
                sw.WriteLine(message);
            }
        }

        public void ProcessCompleteHandler(object sender, ProcessCompleteEventArgs e)
        {
            Log($"[{e.CompleteTime}]: Process was completed.");
        }

        public void ProcessErrorHandler(object sender, ProcessErrorEventArgs e)
        {
            Log($"[{e.EventTime} ERROR]: {e.Exception.Message}");
        }

        public void ProcessStartHandler(object sender, ProcessStartEventArgs e)
        {
            Log($"[{e.StartTime}]: Process was started.");
        }

        public void ProcessStateChangeHandler(object sender, ProcessStateChangeEventArgs e)
        {
           Log($"[{e.EventTime}]: {e.PercentProcessState}% was processed...");
        }
    }
}

using System;

namespace CryptorTask
{
    public class ProcessErrorEventArgs : EventArgs
    {
        public DateTime EventTime { get; }
        public Exception Exception { get; }

        public ProcessErrorEventArgs(Exception ex)
        {
            EventTime = DateTime.Now;
            Exception = ex;
        }
    }
}

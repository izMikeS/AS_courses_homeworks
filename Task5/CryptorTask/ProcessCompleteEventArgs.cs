using System;

namespace CryptorTask
{
    public class ProcessCompleteEventArgs : EventArgs
    {
        public DateTime CompleteTime { get; }

        public ProcessCompleteEventArgs()
        {
            CompleteTime = DateTime.Now;
        }
    }
}

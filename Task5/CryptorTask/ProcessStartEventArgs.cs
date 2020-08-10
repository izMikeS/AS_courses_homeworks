using System;

namespace CryptorTask
{
    public class ProcessStartEventArgs : EventArgs
    {
        public DateTime StartTime { get; }

        public ProcessStartEventArgs()
        {
            StartTime = DateTime.Now;
        }
    }
}

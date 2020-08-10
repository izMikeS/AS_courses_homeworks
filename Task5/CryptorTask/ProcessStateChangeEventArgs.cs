using System;

namespace CryptorTask
{
    public class ProcessStateChangeEventArgs : EventArgs
    {
        public double PercentProcessState { get; }
        public DateTime EventTime { get; }

        public ProcessStateChangeEventArgs(double percentState)
        {
            PercentProcessState = percentState;
            EventTime = DateTime.Now;
        }
    }
}

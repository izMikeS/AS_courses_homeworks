using System;

namespace CryptorTask
{
    public class ConsoleLoggerWatcher : ILoggerWatcher
    {
        public void ProcessCompleteHandler(object sender, ProcessCompleteEventArgs e)
        {
            Console.WriteLine($"[{e.CompleteTime}]: Process was completed.");
        }

        public void ProcessErrorHandler(object sender, ProcessErrorEventArgs e)
        {
            Console.WriteLine($"[{e.EventTime} ERROR]: {e.Exception.Message}");
        }

        public void ProcessStartHandler(object sender, ProcessStartEventArgs e)
        {
            Console.WriteLine($"[{e.StartTime}]: Process was started.");
        }

        public void ProcessStateChangeHandler(object sender, ProcessStateChangeEventArgs e)
        {
            Console.WriteLine($"[{e.EventTime}]: {e.PercentProcessState}% was processed...");
        }
    }
}

namespace CryptorTask
{
    public interface ILoggerWatcher
    {
        void ProcessStartHandler(object sender, ProcessStartEventArgs e);
        void ProcessErrorHandler(object sender, ProcessErrorEventArgs e);
        void ProcessStateChangeHandler(object sender, ProcessStateChangeEventArgs e);
        void ProcessCompleteHandler(object sender, ProcessCompleteEventArgs e);
    }
}

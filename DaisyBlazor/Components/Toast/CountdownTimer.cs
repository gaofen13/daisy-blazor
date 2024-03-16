namespace DaisyBlazor.Components.Toast
{
    internal class CountdownTimer : IDisposable
    {
        private readonly int _timeout;
        private readonly Timer _timer;
        private Action? _elapsedDelegate;

        internal CountdownTimer(int timeout)
        {
            _timeout = timeout;
            _timer = new Timer(TimerElapsed);
        }

        private void TimerElapsed(object? state)
        {
            _elapsedDelegate?.Invoke();
        }

        internal CountdownTimer OnElapsed(Action elapsedDelegate)
        {
            _elapsedDelegate = elapsedDelegate;
            return this;
        }

        internal void Start()
        {
            _timer?.Change(_timeout, Timeout.Infinite);
        }

        internal void Stop()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            Stop();
            _timer.Dispose();
        }
    }
}

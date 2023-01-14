namespace DaisyBlazor.Components.Countdown
{
    internal class CountdownTimer : IDisposable
    {
        private int _days;
        private int _hours;
        private int _minutes;
        private int _seconds;
        private readonly PeriodicTimer _timer;
        private readonly CancellationToken _cancellationToken;

        private Func<int, int, int, int, Task>? _tickDelegate;
        private Func<Task>? _elapsedDelegate;

        internal CountdownTimer(int days, int hours, int minutes, int seconds, CancellationToken cancellationToken = default)
        {
            _days = days;
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _timer = new PeriodicTimer(TimeSpan.FromSeconds(1));
            _cancellationToken = cancellationToken;
        }

        internal CountdownTimer OnTick(Func<int, int, int, int, Task> updateProgressDelegate)
        {
            _tickDelegate = updateProgressDelegate;
            return this;
        }

        internal CountdownTimer OnElapsed(Func<Task> elapsedDelegate)
        {
            _elapsedDelegate = elapsedDelegate;
            return this;
        }

        internal async Task StartAsync()
        {
            await DoWorkAsync();
        }

        private async Task DoWorkAsync()
        {
            while (await _timer.WaitForNextTickAsync(_cancellationToken) && !_cancellationToken.IsCancellationRequested)
            {
                if (_seconds > 0)
                {
                    _seconds--;
                }
                else
                {
                    if (_minutes > 0)
                    {
                        _minutes--;
                        _seconds = 59;
                    }
                    else
                    {
                        if (_hours > 0)
                        {
                            _hours--;
                            _minutes = 59;
                            _seconds = 59;
                        }
                        else
                        {
                            if (_days > 0)
                            {
                                _days--;
                                _hours = 23;
                                _minutes = 59;
                                _seconds = 59;
                            }
                            else
                            {
                                _elapsedDelegate?.Invoke();
                            }
                        }
                    }
                }

                await _tickDelegate?.Invoke(_days, _hours, _minutes, _seconds)!;
            }
        }

        public void Dispose() => _timer.Dispose();
    }
}

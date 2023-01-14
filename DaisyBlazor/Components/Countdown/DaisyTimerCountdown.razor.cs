using DaisyBlazor.Components.Countdown;
using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTimerCountdown : IDisposable
    {
        private int _days;
        private int _hours;
        private int _minutes;
        private int _seconds;

        private CountdownTimer? _countdownTimer;

        private string TimerCountdownClass =>
            new ClassBuilder("countdown-container")
            .AddClass($"countdown-container-vertical", Vertical)
            .AddClass(Class)
            .Build();

        /// <summary>
        /// 起始数值，必须为0到99之间的数值
        /// </summary>
        [Parameter]
        public int Days { get; set; }

        /// <summary>
        /// 起始数值，必须为0到23之间的数值
        /// </summary>
        [Parameter]
        public int Hours { get; set; }

        /// <summary>
        /// 起始数值，必须为0到59之间的数值
        /// </summary>
        [Parameter]
        public int Minutes { get; set; }

        /// <summary>
        /// 起始数值，必须为0到59之间的数值
        /// </summary>
        [Parameter]
        public int Seconds { get; set; }

        /// <summary>
        /// 是否立即执行
        /// </summary>
        [Parameter]
        public bool Immediate { get; set; }

        [Parameter]
        public bool ShowDays { get; set; }

        [Parameter]
        public string? DaysLabel { get; set; }

        [Parameter]
        public RenderFragment? DaysLabelContent { get; set; }

        [Parameter]
        public bool ShowHours { get; set; }

        [Parameter]
        public string? HoursLabel { get; set; }

        [Parameter]
        public RenderFragment? HoursLabelContent { get; set; }

        [Parameter]
        public bool ShowMinutes { get; set; }

        [Parameter]
        public string? MinutesLabel { get; set; }

        [Parameter]
        public RenderFragment? MinutesLabelContent { get; set; }

        [Parameter]
        public bool ShowSeconds { get; set; } = true;

        [Parameter]
        public string? SecondsLabel { get; set; }

        [Parameter]
        public RenderFragment? SecondsLabelContent { get; set; }

        [Parameter]
        public bool UnderLabel { get; set; }

        [Parameter]
        public bool Vertical { get; set; }

        [Parameter]
        public bool Inbox { get; set; }

        [Parameter]
        public Func<Task>? OnFinished { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _days = Days;
            _hours = Hours;
            _minutes = Minutes;
            _seconds = Seconds;

            if (Immediate)
            {
                await StartAsync();
            }
        }

        public async Task<bool> StartAsync()
        {
            if (_countdownTimer != null)
            {
                return false;
            }
            _countdownTimer = new CountdownTimer(_days, _hours, _minutes, _seconds)
                    .OnTick(OnCountdown)
                    .OnElapsed(CloseAsync);

            await _countdownTimer.StartAsync();
            return true;
        }

        private Task OnCountdown(int days, int hours, int minutes, int seconds)
        {
            _days = days;
            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            return InvokeAsync(StateHasChanged);
        }

        public Task CloseAsync()
        {
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            if (OnFinished is not null)
            {
                OnFinished();
            }
            return Task.CompletedTask;
        }

        void IDisposable.Dispose()
        {
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            GC.SuppressFinalize(this);
        }
    }
}

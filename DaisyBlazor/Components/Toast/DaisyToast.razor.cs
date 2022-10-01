﻿using DaisyBlazor.Components.Toast;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyToast
    {
        private int _progress = 100;
        private CountdownTimer? _countdownTimer;

        [CascadingParameter]
        private DaisyToastContainer? ToastContainer { get; set; }

        [Parameter]
        public Level ToastLevel { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool ShowProgressBar { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public Guid ToastId { get; set; }

        [Parameter]
        public GlobalSettings ToastSettings { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            _countdownTimer = new CountdownTimer(ToastSettings.TimeOut)
                .OnTick(CalculateProgressAsync)
                .OnElapsed(Close);

            await _countdownTimer.StartAsync();
        }

        private async Task CalculateProgressAsync(int percentComplete)
        {
            _progress = 100 - percentComplete;
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Closes the toast
        /// </summary>
        public void Close() => ToastContainer?.RemoveToast(ToastId);

        public void Dispose()
        {
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            GC.SuppressFinalize(this);
        }
    }
}

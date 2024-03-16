using DaisyBlazor.Components.Toast;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class ToastInstance
    {
        private ToastOptions? _options;
        private CountdownTimer? _countdownTimer;

        [CascadingParameter]
        private DaisyToastContainer? ToastContainer { get; set; }

        [Parameter]
        public Guid Id { get; set; }

        [Parameter]
        public ToastOptions? Options { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override Task OnInitializedAsync()
        {
            _options = Options ?? ToastContainer?.GlobalOptions;

            if (_options?.AutoClose == true)
            {
                _countdownTimer = new CountdownTimer(_options.TimeOut)
                    .OnElapsed(Close);

                _countdownTimer.Start();
            }

            return base.OnInitializedAsync();
        }

        /// <summary>
        /// Closes the toast
        /// </summary>
        public void Close() => ToastContainer?.RemoveToast(Id);

        void IDisposable.Dispose()
        {
            _countdownTimer?.Dispose();
            _countdownTimer = null;
            GC.SuppressFinalize(this);
        }
    }
}

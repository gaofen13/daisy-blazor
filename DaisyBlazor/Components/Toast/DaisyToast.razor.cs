using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyToast
    {
        [CascadingParameter]
        private ToastInstance? ToastInstance { get; set; }

        [Parameter]
        public Level? ToastLevel { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Message { get; set; }

        /// <summary>
        /// Closes the toast
        /// </summary>
        public void Close() => ToastInstance?.Close();
    }
}

using Microsoft.AspNetCore.Components;

namespace DaisyBlazor.Components.Toast
{
    internal class ToastInstance
    {
        public ToastInstance(ToastOptions settings)
        {
            Options = settings;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public ToastOptions Options { get; set; }

        public Level ToastLevel { get; set; }

        public string? Title { get; set; }

        public RenderFragment? MessageContent { get; set; }
    }
}

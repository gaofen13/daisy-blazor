using Microsoft.AspNetCore.Components;

namespace DaisyBlazor.Components.Toast
{
    internal class DaisyInstance
    {
        public DaisyInstance(GlobalSettings settings)
        {
            ToastSettings = settings;
        }

        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime TimeStamp { get; set; } = DateTime.Now;

        public GlobalSettings ToastSettings { get; set; }

        public Level ToastLevel { get; set; }

        public string? Title { get; set; }

        public RenderFragment? MessageContent { get; set; }
    }
}

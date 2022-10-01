using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyAlert
    {
        private string Classname =>
          new ClassBuilder("alert shadow-lg")
            .AddClass($"alert-{AlertLevel.ToString().ToLower()}", Filled)
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string? Message { get; set; }

        [Parameter]
        public Level AlertLevel { get; set; }

        [Parameter]
        public bool ShowIcon { get; set; } = true;

        [Parameter]
        public bool ShowProgressBar { get; set; }

        [Parameter]
        public int ProgressValue { get; set; }

        [Parameter]
        public bool Indeterminate { get; set; }

        [Parameter]
        public bool Filled { get; set; }

        [Parameter]
        public RenderFragment? MessageTemplate { get; set; }

        [Parameter]
        public RenderFragment? ActionTemplate { get; set; }

        [Parameter]
        public RenderFragment? InfoIconTemplate { get; set; }

        [Parameter]
        public RenderFragment? SuccessIconTemplate { get; set; }

        [Parameter]
        public RenderFragment? WarningIconTemplate { get; set; }

        [Parameter]
        public RenderFragment? ErrorIconTemplate { get; set; }
    }
}

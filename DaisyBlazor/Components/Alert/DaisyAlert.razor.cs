using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyAlert
    {
        private string Classname =>
          new ClassBuilder("alert")
            .AddClass($"alert-{AlertLevel.ToString().ToLower()}", Filled)
            .AddClass(Class)
            .Build();

        private string BodyClass =>
            new ClassBuilder("alert-body")
            .AddClass("alert-text-filled", Filled)
            .AddClass($"alert-text-{AlertLevel.ToString().ToLower()}", !Filled)
            .Build();

        private string IconClass =>
            new ClassBuilder()
            .AddClass(Filled ? "alert-icon-filled" : $"alert-icon-{AlertLevel.ToString().ToLower()}")
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
        public bool Filled { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public RenderFragment? ActionContent { get; set; }

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

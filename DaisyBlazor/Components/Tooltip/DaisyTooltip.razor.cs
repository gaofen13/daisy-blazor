using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTooltip
    {
        private string TooltipClass =>
          new ClassBuilder("tooltip")
            .AddClass("tooltip-open", ForceOpen)
            .AddClass($"tooltip-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"tooltip-{Position.ToString()?.ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Text { get; set; }

        [Parameter]
        public Position Position { get; set; }

        [Parameter]
        public bool ForceOpen { get; set; }

        [Parameter]
        public Color? Color { get; set; }
    }
}

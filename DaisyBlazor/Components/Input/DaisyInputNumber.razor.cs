using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyInputNumber<TValue>
    {
        private string InputClass =>
          new ClassBuilder("input")
            .AddClass("input-bordered", Bordered)
            .AddClass("input-ghost ", Ghost)
            .AddClass($"input-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"input-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool AutoFocus { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public int Min { get; set; } = int.MinValue;

        [Parameter]
        public int Max { get; set; } = int.MaxValue;

        [Parameter]
        public TValue? Step { get; set; } 

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }
    }
}
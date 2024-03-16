using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyRadialProgress
    {
        private string Classname =>
          new ClassBuilder("radial-progress")
            .AddClass(Class)
            .Build();

        private string Stylelist =>
            new StyleBuilder("--value", Value.ToString())
            .AddStyle("--size", Size!, !string.IsNullOrWhiteSpace(Size))
            .AddStyle("--thickness", Thickness!, !string.IsNullOrWhiteSpace(Thickness))
            .Build();

        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public string? Size { get; set; }

        [Parameter]
        public string? Thickness { get; set; }
    }
}

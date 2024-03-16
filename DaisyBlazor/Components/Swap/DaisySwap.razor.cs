using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisySwap
    {
        private string Classname =>
            new ClassBuilder("swap")
            .AddClass("swap-rotate", Rotate)
            .AddClass("swap-flip", Flip)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Rotate { get; set; }

        [Parameter]
        public bool Flip { get; set; }

        [Parameter]
        public RenderFragment? OnContent { get; set; }

        [Parameter]
        public RenderFragment? OffContent { get; set; }
    }
}
using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCard
    {
        private string Classname =>
          new ClassBuilder("card")
            .AddClass("card-compact", Compact)
            .AddClass("card-side", ImageOnSide)
            .AddClass("image-full", ImageOverlay)
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool ImageOverlay { get; set; }

        [Parameter]
        public bool ImageOnSide { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public RenderFragment? ImageContent { get; set; }

        [Parameter]
        public RenderFragment? ActionContent { get; set; }

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public bool Neutra { get; set; }
    }
}

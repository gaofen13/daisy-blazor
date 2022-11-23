using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCard
    {
        private string CardClass =>
          new ClassBuilder("card")
            .AddClass("card-compact", Compact)
            .AddClass("card-bg-base", !Neutra)
            .AddClass("card-bg-neutral", Neutra)
            .AddClass("card-glass", Glass && !Neutra)
            .AddClass($"card-img-{ImgPostion.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public RenderFragment? ImgContent { get; set; }

        [Parameter]
        public Position ImgPostion { get; set; }

        [Parameter]
        public RenderFragment? ActionContent { get; set; }

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public bool Neutra { get; set; }

        [Parameter]
        public bool Glass { get; set; }
    }
}

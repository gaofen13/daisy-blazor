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
        public RenderFragment? TitleTemplate { get; set; }

        [Parameter]
        public RenderFragment? ImgTemplate { get; set; }

        [Parameter]
        public Position ImgPostion { get; set; }

        [Parameter]
        public RenderFragment? ActionTemplate { get; set; }

        [Parameter]
        public RenderFragment? ContentTemplate { get; set; }

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public bool Neutra { get; set; }

        [Parameter]
        public bool Glass { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

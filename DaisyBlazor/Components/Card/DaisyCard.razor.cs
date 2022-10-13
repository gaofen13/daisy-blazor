using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCard
    {
        private string Classname =>
          new ClassBuilder("card")
            .AddClass("card-compact", Compact)
            .AddClass("card-bg-base", !Neutra)
            .AddClass("card-bg-neutral", Neutra)
            .AddClass("card-glass", Glass && !Neutra)
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public bool Neutra { get; set; }

        [Parameter]
        public bool Glass { get; set; }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCard
    {
        private string Classname =>
          new ClassBuilder("card w-full shadow-xl")
            .AddClass("card-compact", Compact)
            .AddClass("bg-base-100", !Neutra)
            .AddClass("bg-neutral text-neutral-content", Neutra)
            .AddClass("class", Glass && !Neutra)
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

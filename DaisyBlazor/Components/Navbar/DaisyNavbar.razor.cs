using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyNavbar
    {
        private string Classname =>
            new ClassBuilder("navbar")
            .AddClass($"shadow-{ShadowSize.ToString().ToLower()}", !DisabledShadow)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool DisabledShadow { get; set; }

        [Parameter]
        public Size ShadowSize { get; set; } = Size.Md;

        [Parameter]
        public RenderFragment? StartContent { get; set; }

        [Parameter]
        public RenderFragment? CenterContent { get; set; }

        [Parameter]
        public RenderFragment? EndContent { get; set; }
    }
}

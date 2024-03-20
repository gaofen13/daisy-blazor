using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCollapse
    {
        private string Classname =>
            new ClassBuilder("collapse")
            .AddClass("collapse-arrow", HasArrow && ArrowIcon == ArrowIcon.Default)
            .AddClass("collapse-plus", HasArrow && ArrowIcon == ArrowIcon.PlusMinus)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public bool HasArrow { get; set; }

        [Parameter]
        public ArrowIcon ArrowIcon { get; set; } = ArrowIcon.Default;

        [Parameter]
        public RenderFragment? TitleContent { get; set; }
    }

    public enum ArrowIcon
    {
        Default,
        PlusMinus
    }
}

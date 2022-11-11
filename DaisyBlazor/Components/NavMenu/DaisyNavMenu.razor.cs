using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyNavMenu
    {
        private string MenuClass =>
            new ClassBuilder("menu")
            .AddClass("menu-shadow-xl", Shadow)
            .AddClass("menu-compact", Compact)
            .AddClass(Class)
            .Build();

        private string MenuStyle =>
            new StyleBuilder()
            .AddStyle("--menu-width", Width)
            .AddStyle(Style)
            .Build();

        [Parameter]
        public string Width { get; set; } = "14rem";

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Shadow { get; set; } = true;

        [Parameter]
        public bool Compact { get; set; }
    }
}

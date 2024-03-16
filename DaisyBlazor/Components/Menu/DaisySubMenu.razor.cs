using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisySubMenu
    {
        private string TitleClassname =>
            new ClassBuilder("menu-dropdown-toggle")
            .AddClass("menu-dropdown-show", Open)
            .Build();

        private string ContentClassname =>
            new ClassBuilder("menu-dropdown")
            .AddClass("menu-dropdown-show", Open)
            .Build();

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }
    }
}

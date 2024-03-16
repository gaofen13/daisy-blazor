using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyMenu
    {
        private string Classname =>
            new ClassBuilder("menu bg-base-200")
            .AddClass("menu-horizontal", Horizontal)
            .AddClass($"menu-{Size.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Horizontal { get; set; }

        [Parameter]
        public Size Size { get; set; } = Size.Md;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public string ActiveClass { get; set; } = "active";
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyBadge
    {
        private string Classname =>
            new ClassBuilder("badge")
            .AddClass($"badge-{Color.ToString()?.ToLower()}", Color is not null)
            .AddClass($"badge-{Size.ToString().ToLower()}")
            .AddClass("badge-outline", Outline)
            .AddClass("badge-ghost", Ghost)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size Size { get; set; } = Size.Md;

        [Parameter]
        public bool Outline { get; set; }

        [Parameter]
        public bool Ghost { get; set; }
    }
}
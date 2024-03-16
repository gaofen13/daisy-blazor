using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyDivider
    {
        private string Classname =>
            new ClassBuilder("divider")
            .AddClass("divider-horizontal", Vertical)
            .AddClass($"divider-{Color.ToString()?.ToLower()}", Color is not null)
            .AddClass($"divider-{Position.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Vertical { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public PositionX Position { get; set; } = PositionX.Center;
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyAlert
    {
        private string Classname =>
          new ClassBuilder("alert")
            .AddClass($"alert-{Level.ToString()?.ToLower()}", Level is not null)
            .AddClass($"shadow-{ShadowSize.ToString().ToLower()}", !DisabledShadow)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Level? Level { get; set; }

        [Parameter]
        public bool DisabledShadow { get; set; }

        [Parameter]
        public Size ShadowSize { get; set; } = Size.Md;

        [Parameter]
        public RenderFragment? IconContent { get; set; }

        [Parameter]
        public RenderFragment? ActionContent { get; set; }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyAlert
    {
        private string Classname =>
          new ClassBuilder("alert")
            .AddClass($"alert-{Level.ToString()?.ToLower()}", Level is not null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Level? Level { get; set; }

        [Parameter]
        public RenderFragment? IconContent { get; set; }

        [Parameter]
        public RenderFragment? ActionContent { get; set; }
    }
}

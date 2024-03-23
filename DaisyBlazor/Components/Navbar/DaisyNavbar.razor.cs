using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyNavbar
    {
        private string Classname =>
            new ClassBuilder("navbar")
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment? StartContent { get; set; }

        [Parameter]
        public RenderFragment? CenterContent { get; set; }

        [Parameter]
        public RenderFragment? EndContent { get; set; }
    }
}

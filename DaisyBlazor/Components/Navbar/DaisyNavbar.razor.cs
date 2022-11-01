using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyNavbar
    {
        private string NavbarClass =>
            new ClassBuilder("navbar")
            .AddClass("navbar-rounded-box", Rounded)
            .AddClass("navbar-shadow-xl", Shadow)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Rounded { get; set; }

        [Parameter]
        public bool Shadow { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

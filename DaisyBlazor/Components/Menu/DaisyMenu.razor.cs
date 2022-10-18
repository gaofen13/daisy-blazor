using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyMenu
    {
        private string Classname =>
            new ClassBuilder("menu")
            .AddClass("menu-horizontal", Horizontal)
            .AddClass("menu-compact", Compact)
            .AddClass("rounded-box", Rounded)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Horizontal { get; set; }

        [Parameter]
        public bool Rounded { get; set; } = true;

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

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
            .AddClass("menu-shadow-xl", Shadow)
            .AddClass("menu-horizontal", Horizontal)
            .AddClass("menu-compact", Compact)
            .AddClass("rounded-box", Rounded)
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
        public bool Horizontal { get; set; }

        [Parameter]
        public bool Rounded { get; set; }

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Shadow { get; set; } = true;

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

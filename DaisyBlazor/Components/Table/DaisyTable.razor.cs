using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyTable
    {
        private string TableClass =>
            new ClassBuilder("table")
            .AddClass("table-hover", Hover)
            .AddClass("table-zebra", Zebra)
            .AddClass("table-compact", Compact)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Hover { get; set; } = true;

        [Parameter]
        public bool Zebra { get; set; } = true;

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyDivider
    {
        private string DividerClass =>
            new ClassBuilder("divider")
            .AddClass("divider-horizontal", Horizontal)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Horizontal { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

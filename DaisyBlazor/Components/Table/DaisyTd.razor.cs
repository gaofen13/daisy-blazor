using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyTd
    {
        [Parameter]
        public int Colspan { get; set; } = 1;

        [Parameter]
        public int Rowspan { get; set; } = 1;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

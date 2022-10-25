using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyTHead
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

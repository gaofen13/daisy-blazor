using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyTr
    {
        private string TrClass =>
            new ClassBuilder()
            .AddClass("active", Active)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

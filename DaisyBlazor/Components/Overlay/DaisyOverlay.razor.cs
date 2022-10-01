using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyOverlay
    {
        private string Classname =>
          new ClassBuilder("modal modal-open")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Visible { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback OnBackgroundClick { get; set; }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyMenuItemGroup
    {
        private string Classname =>
            new ClassBuilder("menu-title")
            .AddClass(Class)
            .Build();

        [CascadingParameter]
        private DaisyMenu? Menu { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

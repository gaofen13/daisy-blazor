using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyTooltip
    {
        private string Classname =>
          new ClassBuilder("tooltip")
            .AddClass("tooltip-open", ForceOpen)
            .AddClass($"tooltip-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"tooltip-{Position.ToString()?.ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Text { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public Position Position { get; set; }

        [Parameter]
        public bool ForceOpen { get; set; }

        [Parameter]
        public Color? Color { get; set; }
    }
}

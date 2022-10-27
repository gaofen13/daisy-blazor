using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyColumn
    {
        [CascadingParameter(Name = "RenderMode")]
        public RenderMode Mode { get; set; }

        [Parameter]
        public bool Visible { get; set; } = true;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleTemplate { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public enum RenderMode
        {
            Head,
            Body
        }
    }
}

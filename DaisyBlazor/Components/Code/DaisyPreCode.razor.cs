using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyPreCode
    {
        private string Classname =>
            new ClassBuilder()
            .AddClass("code-data-prefix", !string.IsNullOrWhiteSpace(DataPrefix))
            .AddClass(Class)
            .Build();
        [Parameter]
        public string? DataPrefix { get; set; }

        [Parameter]
        public string? CodeText { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

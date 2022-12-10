using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyDropdown
    {
        private string DropdownClass =>
          new ClassBuilder("dropdown")
            .AddClass("dropdown-open", Open)
            .AddClass("dropdown-end", AlignsToEnd)
            .AddClass($"dropdown-{DropPosition.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        private string DropdownContentClass =>
          new ClassBuilder("dropdown-content")
            .AddClass("menu")
            .AddClass("rounded-box", RoundedBox)
            .AddClass(ContentClass)
            .Build();

        [Parameter]
        public string? TitleClass { get; set; }

        [Parameter]
        public string? ContentClass { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public Position DropPosition { get; set; } = Position.Bottom;

        [Parameter]
        public bool AlignsToEnd { get; set; }

        [Parameter]
        public bool RoundedBox { get; set; }
    }
}

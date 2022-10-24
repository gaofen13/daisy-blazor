﻿using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyLink
    {
        private string LinkClass =>
            new ClassBuilder("link")
            .AddClass($"link-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass("link-hover", UnderlineOnHover)
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public string? Target { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public bool UnderlineOnHover { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
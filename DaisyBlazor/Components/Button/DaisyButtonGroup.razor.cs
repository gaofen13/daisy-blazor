﻿using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyButtonGroup
    {
        private string Classname =>
          new ClassBuilder("btn-group")
            .AddClass("btn-group-vertical", Vertical)
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool Vertical { get; set; }
    }
}
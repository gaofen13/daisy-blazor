﻿using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyRadialProgress
    {
        private string Classname =>
          new ClassBuilder("radial-progress")
            .AddClass($"text-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"bg-{BgColor.ToString()?.ToLower()}", BgColor != null)
            .AddClass($"border-{BorderColor.ToString()?.ToLower()}", BorderColor != null)
            .AddClass(Class)
            .Build();

        private string StyleAttribute =>
            new StyleBuilder("--value", Value.ToString())
            .AddStyle("--size", $"{Size}rem")
            .Build();

        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Color? BgColor { get; set; }

        [Parameter]
        public Color? BorderColor { get; set; }

        [Parameter]
        public float Size { get; set; } = 4;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
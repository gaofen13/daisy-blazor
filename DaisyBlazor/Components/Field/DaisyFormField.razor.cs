﻿using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace DaisyBlazor
{
    public partial class DaisyFormField
    {
        private int _colspan = 2;

        private string FieldClass =>
          new ClassBuilder("form-field")
            .AddClass($"form-field-{Breakpoint.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        private string FieldStyle =>
            new StyleBuilder("--label-width", (_colspan * 100.00 / 12) + "%")
            .AddStyle(Style)
            .Build();

        private string FieldLabelClass =>
            new ClassBuilder("form-field-label")
            .AddClass("required", LabelRequired)
            .Build();

        [CascadingParameter]
        protected EditContext? CascadedEditContext { get; set; }

        [Parameter]
        public Expression<Func<object>>? For { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public bool LabelRequired { get; set; }

        [Parameter]
        public Size Breakpoint { get; set; } = Size.Md;

        [Parameter]
        public int LabelColspan
        {
            get => _colspan;
            set
            {
                if (value >= 0 && value <= 12 && value != _colspan)
                {
                    _colspan = value;
                }
            }
        }
    }
}

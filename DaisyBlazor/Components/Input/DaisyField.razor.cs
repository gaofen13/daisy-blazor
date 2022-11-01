using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyField
    {
        private int _colspan = 2;

        private string FieldClass =>
          new ClassBuilder("form-field")
            .AddClass($"form-field-{Breakpoint.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        private string FieldStyle =>
            new StyleBuilder("--label-width", (_colspan * 100 / 12) + "%")
            .AddStyle(Style)
            .Build();

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public Size Breakpoint { get; set; } = Size.Md;

        [Parameter]
        public int LabelColspan
        {
            get => _colspan;
            set
            {
                if (value > 0 && value < 12 && value != _colspan)
                {
                    _colspan = value;
                }
            }
        }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

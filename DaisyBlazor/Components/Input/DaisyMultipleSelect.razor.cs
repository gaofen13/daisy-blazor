using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace DaisyBlazor
{
    public partial class DaisyMultipleSelect<TValue>
    {
        private string SelectClass =>
          new ClassBuilder("select")
            .AddClass("select-bordered", Bordered)
            .AddClass("select-ghost ", Ghost)
            .AddClass($"select-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"select-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public Size Breakpoint { get; set; } = DaisyBlazor.Size.Md;

        [Parameter]
        public int LabelColspan { get; set; }

        [Parameter]
        public bool AutoFocus { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public int Height { get; set; }

        private void SetCurrentValueAsStringArray(string?[]? value)
        {
            CurrentValue = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
                ? result : default;
        }
    }
}

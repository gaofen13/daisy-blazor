using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace DaisyBlazor
{
    public partial class DaisyMultiSelect<TValue>
    {
        private string SelectClass =>
          new ClassBuilder("select")
            .AddClass("select-bordered", Bordered)
            .AddClass("select-ghost ", Ghost)
            .AddClass($"select-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"select-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(FieldClass)
            .AddClass(Class)
            .Build();

        [Parameter]
        public int Height { get; set; }

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

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
            => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);

        private void SetCurrentValueAsStringArray(string?[]? value)
        {
            CurrentValue = BindConverter.TryConvertTo<TValue>(value, CultureInfo.CurrentCulture, out var result)
                ? result
                : default;
        }
    }
}

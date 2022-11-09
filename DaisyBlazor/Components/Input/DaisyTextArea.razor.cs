using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace DaisyBlazor
{
    public partial class DaisyTextArea
    {
        private string InputClass =>
          new ClassBuilder("textarea")
            .AddClass("textarea-bordered", Bordered)
            .AddClass("textarea-ghost ", Ghost)
            .AddClass($"textarea-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass(FieldClass)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool AutoFocus { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public int Rows { get; set; } = 5;

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        protected override bool TryParseValueFromString(string? value, out string? result, [NotNullWhen(false)] out string? validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }
    }
}

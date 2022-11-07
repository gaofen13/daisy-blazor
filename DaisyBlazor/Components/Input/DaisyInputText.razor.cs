using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyInputText
    {
        private string InputClass =>
          new ClassBuilder("input")
            .AddClass("input-bordered", Bordered)
            .AddClass("input-ghost ", Ghost)
            .AddClass($"input-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"input-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(FieldClass)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool AutoFocus { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public int MaxLength { get; set; } = int.MaxValue;

        [Parameter]
        public string Type { get; set; } = "text";

        [Parameter]
        public string? Pattern { get; set; }

        [Parameter]
        public bool Trim { get; set; }

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        private void OnInputChanged(ChangeEventArgs args)
        {
            var value = $"{args.Value}";
            if (Trim)
            {
                value = value.Trim();
            }
            CurrentValue = value;
        }
    }
}

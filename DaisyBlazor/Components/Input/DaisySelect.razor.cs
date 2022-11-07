using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace DaisyBlazor
{
    public partial class DaisySelect<TValue>
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

        private string? CurrentValueAsString => JsonSerializer.Serialize(Value);

        private void OnChanged(ChangeEventArgs args)
        {
            var jsonValue = args.Value?.ToString();
            if (jsonValue != null)
            {
                CurrentValue = JsonSerializer.Deserialize<TValue>(jsonValue);
            }
            else
            {
                CurrentValue = default;
            }
        }
    }
}

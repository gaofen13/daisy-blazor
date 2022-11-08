using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace DaisyBlazor
{
    public partial class DaisyRadioGroup<TValue>
    {
        private readonly string _defaultGroupName = Guid.NewGuid().ToString("N");

        public string RadioName => Name ?? _defaultGroupName;

        private string RadioGroupClass =>
          new ClassBuilder("radio-group")
            .AddClass($"radio-group-vertical", Vertical)
            .AddClass(FieldClass)
            .AddClass(Class)
            .Build();

        [Parameter]
        public Position LabelPosition { get; set; } = Position.Right;

        [Parameter]
        public bool Vertical { get; set; }

        public void OnCheckedRadioChanged(string? value)
        {
            if (value == null)
            {
                CurrentValue = default;
            }
            else
            {
                CurrentValue = JsonSerializer.Deserialize<TValue>(value);
            }
        }
    }
}

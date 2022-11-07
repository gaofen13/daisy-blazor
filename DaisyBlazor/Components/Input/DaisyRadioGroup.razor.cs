using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyRadioGroup<TValue>
    {
        private readonly string _defaultGroupName = Guid.NewGuid().ToString("N");

        private DaisyRadio<TValue>? _checkedRadio;

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

        public void OnCheckedRadioChanged(DaisyRadio<TValue> radio)
        {
            _checkedRadio = radio;
            CurrentValue = radio.Value;
        }
    }
}

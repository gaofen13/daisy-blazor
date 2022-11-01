using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyRadioGroup<TValue>
    {
        private DaisyRadio<TValue>? _checkedRadio;

        private string RadioGroupClass =>
          new ClassBuilder("radio-group")
            .AddClass($"radio-group-vertical", Vertical)
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public Position LabelPosition { get; set; } = Position.Right;

        [Parameter]
        public bool Vertical { get; set; }

        public bool CheckCurrentValue(TValue? value)
        {
            if (Value == null && value == null)
            {
                return true;
            }
            return Value?.Equals(value) == true;
        }

        public void OnCheckedRadioChanged(DaisyRadio<TValue> radio)
        {
            _checkedRadio = radio;
            if (!CheckCurrentValue(radio.Value))
            {
                Value = radio.Value;
                ValueChanged.InvokeAsync(Value);
            }
        }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace DaisyBlazor
{
    public partial class DaisyRadioGroup<TValue>
    {
        private DaisyRadio<TValue>? _checkedRadio;

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

        protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
            => this.TryParseSelectableValueFromString(value, out result, out validationErrorMessage);

        public void OnCheckedRadioChanged(DaisyRadio<TValue> radio)
        {
            _checkedRadio = radio;
            if (!EqualityComparer<TValue>.Default.Equals(radio.Value, CurrentValue))
            {
                CurrentValue = radio.Value;
            }
        }
    }
}

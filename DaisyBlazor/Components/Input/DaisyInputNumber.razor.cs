using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;

namespace DaisyBlazor
{
    public partial class DaisyInputNumber<TValue>
    {
        private string Classname =>
          new ClassBuilder("input")
            .AddClass("input-bordered", Bordered)
            .AddClass("input-ghost ", Ghost)
            .AddClass($"input-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"input-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        private bool CheckCurrentValue(TValue? value)
        {
            if (Value == null && value == null)
            {
                return true;
            }
            return Value?.Equals(value) == true;
        }

        private void OnInputChanged(ChangeEventArgs args)
        {
            if (BindConverter.TryConvertTo(args.Value, CultureInfo.InvariantCulture, out TValue? res))
            {
                if (!CheckCurrentValue(res))
                {
                    Value = res;
                    ValueChanged.InvokeAsync(Value);
                }
            }
        }
    }
}
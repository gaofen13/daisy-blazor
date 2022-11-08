using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace DaisyBlazor
{
    public partial class DaisyRadio<TValue>
    {
        private string RadioClass =>
          new ClassBuilder("radio")
            .AddClass($"radio-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"radio-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        private string ContainerClass =>
          new ClassBuilder("input-container")
            .AddClass($"label-{LabelPosition.ToString()?.ToLower()}")
            .Build();

        [CascadingParameter]
        private DaisyRadioGroup<TValue>? RadioGroup { get; set; }

        [Parameter]
        public bool Checked { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public Position? LabelPosition { get; set; }

        private string? StringValue => JsonSerializer.Serialize(Value);

        protected override void OnInitialized()
        {
            LabelPosition ??= RadioGroup?.LabelPosition;
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (RadioGroup is not null)
            {
                Checked = JsonSerializer.Serialize(RadioGroup.Value) == StringValue;
            }
        }

        private void OnInputChanged(ChangeEventArgs args)
        {
            Checked = true;
            RadioGroup?.OnCheckedRadioChanged(args.Value?.ToString());
        }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Globalization;

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
        public string? Id { get; set; }

        [Parameter]
        public string? Name { get; set; }

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

        protected override void OnInitialized()
        {
            LabelPosition ??= RadioGroup?.LabelPosition;
            base.OnInitialized();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            if (RadioGroup != null)
            {
                Checked = EqualityComparer<TValue>.Default.Equals(Value, RadioGroup.Value);
            }
        }

        private void OnRadioChanged(ChangeEventArgs args)
        {
            RadioGroup?.OnCheckedRadioChanged(this);
        }
    }
}

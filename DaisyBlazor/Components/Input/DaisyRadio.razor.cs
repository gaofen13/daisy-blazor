using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyRadio<TValue>
    {
        private string Classname =>
          new ClassBuilder("radio")
            .AddClass($"radio-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"radio-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        private string ContainerClass =>
          new ClassBuilder("input-container")
            .AddClass($"label-{LabelPosition.ToString()?.ToLower()}")
            .Build();

        private bool Checked => RadioGroup?.CheckCurrentValue(Value) == true;

        [CascadingParameter]
        private DaisyRadioGroup<TValue>? RadioGroup { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public Position? LabelPosition { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            LabelPosition ??= RadioGroup?.LabelPosition;
            base.OnInitialized();
        }

        private void OnInputChanged(ChangeEventArgs args)
        {
            RadioGroup?.OnCheckedRadioChanged(this);
        }
    }
}

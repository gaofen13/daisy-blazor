using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyRadioGroup<TValue>
    {
        private readonly List<DaisyRadio<TValue>> _radios = new();

        private string Classname =>
          new ClassBuilder("radio-group")
            .AddClass($"radio-group-vertical", Vertical)
            .AddClass(Class)
            .Build();

        public InputRadioGroup<TValue>? RadioGroup { get; protected set; }

        [Parameter]
        public RenderFragment? RadioList { get; set; }

        [Parameter]
        public Position LabelPosition { get; set; } = Position.Right;

        [Parameter]
        public bool Vertical { get; set; }
    }
}

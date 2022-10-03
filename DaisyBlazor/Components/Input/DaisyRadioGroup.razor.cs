using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyRadioGroup<TValue>
    {
        private readonly List<DaisyRadio<TValue>> _radios = new();

        public InputRadioGroup<TValue>? RadioGroup { get; protected set; }

        [Parameter]
        public RenderFragment? RadioList { get; set; }
    }
}

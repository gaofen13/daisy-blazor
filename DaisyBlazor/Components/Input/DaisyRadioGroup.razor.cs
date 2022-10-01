using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

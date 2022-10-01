using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public InputRadio<TValue>? Radio { get; protected set; }

        [CascadingParameter]
        private DaisyRadioGroup<TValue> RadioGroup { get; set; } = default!;

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }
    }
}

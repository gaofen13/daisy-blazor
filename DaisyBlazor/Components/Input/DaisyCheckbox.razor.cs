using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyCheckbox
    {
        private string Classname =>
          new ClassBuilder("checkbox")
            .AddClass($"checkbox-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"checkbox-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        public InputCheckbox? Checkbox { get; protected set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }
    }
}

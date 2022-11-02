using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyTextArea
    {
        public InputTextArea? Input { get; private set; }

        private string InputClass =>
          new ClassBuilder("textarea")
            .AddClass("textarea-bordered", Bordered)
            .AddClass("textarea-ghost ", Ghost)
            .AddClass($"textarea-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public int Rows { get; set; } = 5;

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }
    }
}

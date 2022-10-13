using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyInputTextArea
    {
        private string Classname =>
          new ClassBuilder("textarea")
            .AddClass("textarea-bordered", Bordered)
            .AddClass("textarea-ghost ", Ghost)
            .AddClass($"textarea-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass(Class)
            .Build();

        public InputTextArea? InputTextArea { get; protected set; }

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }
    }
}

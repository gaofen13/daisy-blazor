using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyInputText
    {
        private string Classname =>
          new ClassBuilder("input w-full max-w-xs")
            .AddClass("input-bordered", Bordered)
            .AddClass("input-ghost ", Ghost)
            .AddClass($"input-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"input-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        public ElementReference InputElement { get; set; }

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        protected void OnChanged(ChangeEventArgs args)
        {
            var value = args.Value as string;
            Value = value;
            ValueChanged.InvokeAsync(Value);
        }
    }
}

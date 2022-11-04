using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyButton
    {
        private string BtnClass =>
          new ClassBuilder("btn")
            .AddClass($"btn-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"btn-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass("btn-active", Active)
            .AddClass("btn-disabled", Disabled)
            .AddClass("btn-outline", Outline)
            .AddClass("btn-glass", Glass)
            .AddClass("btn-wide", Wide)
            .AddClass("btn-square", Square)
            .AddClass("btn-circle", Circle)
            .AddClass("btn-block", Block)
            .AddClass("btn-loading", Loading)
            .AddClass("no-animation", NoAnimation)
            .AddClass(Class)
            .Build();

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public bool StopPropagation { get; set; } = true;

        [Parameter]
        public string Type { get; set; } = "button";

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Outline { get; set; }

        [Parameter]
        public bool Glass { get; set; }

        [Parameter]
        public bool Wide { get; set; }

        [Parameter]
        public bool Square { get; set; }

        [Parameter]
        public bool Circle { get; set; }

        [Parameter]
        public bool Block { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public bool NoAnimation { get; set; }

        public ValueTask FocusAsync()
        {
            return Element.FocusAsync();
        }

        private async Task Click(MouseEventArgs args)
        {
            if (Disabled)
                return;
            if (OnClick.HasDelegate)
            {
                await OnClick.InvokeAsync(args);
            }
        }
    }
}

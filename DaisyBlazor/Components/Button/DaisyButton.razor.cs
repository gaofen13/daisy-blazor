using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyButton
    {
        private string Classname =>
          new ClassBuilder("btn")
            .AddClass($"btn-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"btn-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass("btn-ghost", Ghost)
            .AddClass("btn-link", Href is not null)
            .AddClass("btn-outline", Outline)
            .AddClass("btn-active", Active)
            .AddClass("btn-disabled", Disabled)
            .AddClass("glass", Glass)
            .AddClass("no-animation", NoAnimation)
            .AddClass("btn-wide", Wide)
            .AddClass("btn-block", Block)
            .AddClass("btn-circle", Circle)
            .AddClass("btn-square", Square)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public string HtmlTag { get; set; } = "button";

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public bool Active { get; set; }

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
        public bool Ghost { get; set; }

        [Parameter]
        public bool Block { get; set; }

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public bool NoAnimation { get; set; }

        protected override void OnInitialized()
        {
            if (Href is not null)
            {
                HtmlTag = "a";
            }
            base.OnInitialized();
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

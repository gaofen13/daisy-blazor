using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisySubMenu
    {
        private string SubClass =>
            new ClassBuilder("menu-sub")
            .AddClass("menu-sub-collapsed", Collapsed)
            .AddClass("menu-sub-arrow")
            .AddClass(Class)
            .Build();

        private string SubContentClass =>
            new ClassBuilder()
            .AddClass("rounded-box", Root?.Rounded == true)
            .Build();

        [CascadingParameter]
        private DaisyMenu? Root { get; set; }

        [CascadingParameter]
        private DaisySubMenu? Parent { get; set; }

        [Parameter]
        public bool Collapsed { get; set; } = true;

        [Parameter]
        public EventCallback<bool> CollapsedChanged { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnTitleClicked { get; set; }

        private async Task OnHandlerClickTilte(MouseEventArgs args)
        {
            if (OnTitleClicked.HasDelegate)
            {
                await OnTitleClicked.InvokeAsync(args);
            }
            else
            {
                Collapsed = !Collapsed;
                await CollapsedChanged.InvokeAsync(Collapsed);
            }
        }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyNavMenuGroup
    {
        private string GroupClass =>
        new ClassBuilder("menu-group")
            .AddClass("menu-group-collapsed", !Collapsed)
            .Build();

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public bool Collapsed { get; set; } = true;

        [Parameter]
        public EventCallback<bool> CollapsedChanged { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnTitleClicked { get; set; }

        private async Task OnClickTitleAsync(MouseEventArgs args)
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

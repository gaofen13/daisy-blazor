using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyCollapse
    {
        private string CollapseClass =>
            new ClassBuilder("collapse collapse-arrow")
            .AddClass("collapse-open", !Collapsed)
            .Build();

        [Parameter]
        public bool Collapsed { get; set; } = true;

        [Parameter]
        public EventCallback<bool> CollapsedChanged { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public string? Message { get; set; }

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

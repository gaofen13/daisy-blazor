using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyCollapse
    {
        private string Classname =>
            new ClassBuilder("collapse collapse-arrow")
            .AddClass("collapse-open", Collapsed)
            .Build();

        [Parameter]
        public bool Collapsed { get; set; }

        [Parameter]
        public EventCallback<bool> CollapsedChanged { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public string? Message { get; set; }

        [Parameter]
        public RenderFragment? MessageContent { get; set; }

        private async Task OnClickTitleAsync()
        {
            Collapsed = !Collapsed;
            await CollapsedChanged.InvokeAsync(Collapsed);
        }
    }
}

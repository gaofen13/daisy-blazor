using DaisyBlazor.Generators;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;

namespace DaisyBlazor.Shared.Components
{
    public partial class DemoSection
    {
        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        [Parameter, EditorRequired]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment? Description { get; set; }

        [Parameter, EditorRequired]
        public string ExampleFile { get; set; } = string.Empty;

        private string? CodeContents { get; set; }

        public string Id { get; } = Guid.NewGuid().ToString("N");

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (!string.IsNullOrEmpty(ExampleFile))
                {
                    SetCodeContents();
                }
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        protected void SetCodeContents()
        {
            try
            {
                CodeContents = DemoSnippets.GetRazor($"{ExampleFile}");
                StateHasChanged();
            }
            catch
            {
                //Do Nothing
            }
        }

        private async Task OnActivedCode()
        {
            await JSRuntime.InvokeVoidAsync("HighlightCode", Id);
        }
    }
}

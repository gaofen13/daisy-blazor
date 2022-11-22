using DaisyBlazor.Generators;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Reflection.Metadata;

namespace DaisyBlazor.Shared.Components
{
    public partial class DemoSection
    {
        private ElementReference _button;
        private string? _codeString;

        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        [Parameter, EditorRequired]
        public string Title { get; set; } = string.Empty;

        [Parameter]
        public RenderFragment? Description { get; set; }

        [Parameter, EditorRequired]
        public string ExampleFile { get; set; } = string.Empty;

        private MarkupString? CodeContents { get; set; }

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

        protected async void SetCodeContents()
        {
            try
            {
                _codeString = DemoSnippets.GetRazor($"{ExampleFile}");
                var res = await JSRuntime.InvokeAsync<string>("HighlightCode", _codeString);
                if (!string.IsNullOrWhiteSpace(res))
                {
                    CodeContents = new MarkupString(res);
                }
                StateHasChanged();
            }
            catch
            {
                //Do Nothing
            }
        }

        private async Task CopyCode()
        {
            await JSRuntime.InvokeVoidAsync("copyCode", _button, _codeString);
        }
    }
}

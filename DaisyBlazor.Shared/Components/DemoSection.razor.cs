using DaisyBlazor.Generators;
using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Reflection.Metadata;

namespace DaisyBlazor.Shared.Components
{
    public partial class DemoSection
    {
        private bool _codeTabActived;

        private string CodeTitleStylelist =>
            new StyleBuilder()
            .AddStyle("--tab-bg", "var(--fallback-n, oklch(var(--n)))", _codeTabActived)
            .AddStyle("--tab-color", "var(--fallback-nc,oklch(var(--nc)))", _codeTabActived)
            .Build();

        [Parameter, EditorRequired]
        public string Title { get; set; } = string.Empty;

        [Parameter, EditorRequired]
        public Type Component { get; set; } = default!;

        [Parameter]
        public IDictionary<string, object>? ComponentParameters { get; set; }

        [Parameter]
        public string Language { get; set; } = "language-cshtml-razor";

        private string? CodeContents { get; set; }

        protected override void OnInitialized()
        {
            SetCodeContents();
            base.OnInitialized();
        }

        protected void SetCodeContents()
        {
            try
            {
                CodeContents = DemoSnippets.GetRazor(Component.Name);
            }
            catch
            {
                //Do Nothing
            }
        }

        private void OnTabChanged(bool activedCode)
        {
            _codeTabActived = activedCode;
            StateHasChanged();
        }
    }
}

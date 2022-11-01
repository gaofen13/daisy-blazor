using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyPreCode
    {
        private string CodeClass =>
            new ClassBuilder()
            .AddClass("code-data-prefix", !string.IsNullOrWhiteSpace(DataPrefix))
            .AddClass(Class)
            .Build();
        [Parameter]
        public string? DataPrefix { get; set; }

        [Parameter]
        public string? CodeText { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

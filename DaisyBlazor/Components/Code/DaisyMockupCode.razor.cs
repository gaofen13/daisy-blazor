using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyMockupCode
    {
        private string PrefixClass =>
            new ClassBuilder()
            .AddClass("code-data-prefix", !string.IsNullOrWhiteSpace(DataPrefix))
            .Build();

        [Parameter]
        public string? Id { get; set; }

        [Parameter]
        public string? DataPrefix { get; set; }

        [Parameter]
        public string? CodeText { get; set; }
    }
}

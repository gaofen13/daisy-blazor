using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisySelectOption<TValue>
    {
        [Parameter]
        public bool DefaultSelected { get; set; }

        [Parameter]
        public string? Text { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

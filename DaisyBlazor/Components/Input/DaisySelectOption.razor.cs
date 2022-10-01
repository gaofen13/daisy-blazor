using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisySelectOption<TValue>
    {
        [CascadingParameter]
        private DaisySelect<TValue> DaisySelect { get; set; } = default!;

        [Parameter]
        public string? Text { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

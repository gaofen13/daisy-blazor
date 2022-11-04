using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisySelectOption<TValue>
    {
        [Parameter]
        public bool Default { get; set; }

        [Parameter]
        public string? Text { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
    }
}

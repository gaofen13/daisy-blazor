using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public class DaisyInputBase<TValue> : DaisyComponentBase
    {
        public ElementReference Element { get; protected set; }

        [Parameter]
        public string? Name { get; set; }

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool ReadOnly { get; set; }

        [Parameter]
        public string? Placeholder { get; set; }

        [Parameter]
        public bool AutoFocus { get; set; }

        public ValueTask FocusAsync()
        {
            return Element.FocusAsync();
        }
    }
}

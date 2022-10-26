using Microsoft.AspNetCore.Components;
using System.Globalization;

namespace DaisyBlazor
{
    public class DaisyInputBase<TValue> : DaisyComponentBase
    {
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
    }
}

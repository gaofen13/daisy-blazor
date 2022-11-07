using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace DaisyBlazor
{
    public partial class DaisySelectOption<TValue>
    {
        private string? StringValue => JsonSerializer.Serialize(Value);

        [Parameter]
        public TValue? Value { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Default { get; set; }

        [Parameter]
        public string? Text { get; set; }
    }
}

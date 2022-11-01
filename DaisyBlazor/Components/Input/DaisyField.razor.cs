using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyField
    {
        private string FieldClass =>
          new ClassBuilder("form-field")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}

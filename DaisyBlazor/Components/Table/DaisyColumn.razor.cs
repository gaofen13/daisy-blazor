using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyColumn
    {
        [CascadingParameter(Name = "RenderMode")]
        public RenderMode Mode { get; set; }

        [Parameter]
        public bool Visible { get; set; } = true;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleTemplate { get; set; }

        public enum RenderMode
        {
            Head,
            Body
        }
    }
}

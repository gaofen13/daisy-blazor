using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyColumn
    {
        [CascadingParameter(Name = "RenderMode")]
        public RenderMode Mode { get; set; }

        [Parameter]
        public bool Visible { get; set; } = true;

        public enum RenderMode
        {
            Head,
            Body
        }
    }
}

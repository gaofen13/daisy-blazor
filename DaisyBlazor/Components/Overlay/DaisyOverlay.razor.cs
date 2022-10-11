using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyOverlay
    {
        private string Classname =>
          new ClassBuilder("modal modal-open items-center")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Visible { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public EventCallback OnBackgroundClick { get; set; }
    }
}

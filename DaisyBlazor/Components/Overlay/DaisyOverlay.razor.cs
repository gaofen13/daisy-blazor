using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyOverlay
    {
        private string OverlayClass =>
          new ClassBuilder("overlay")
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Visible { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnBackgroundClick { get; set; }
    }
}

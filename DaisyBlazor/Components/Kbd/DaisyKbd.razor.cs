using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyKbd
    {
        private string KdbClass =>
            new ClassBuilder("kbd")
            .AddClass(Class)
            .Build();

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public bool StopPropagation { get; set; }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyKbd
    {
        private string Classname =>
            new ClassBuilder("kbd")
            .AddClass($"kbd-{Size.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public bool StopPropagation { get; set; }

        [Parameter]
        public Size Size { get; set; }
    }
}

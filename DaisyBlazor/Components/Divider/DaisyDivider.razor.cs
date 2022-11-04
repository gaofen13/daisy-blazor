using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyDivider
    {
        private string DividerClass =>
            new ClassBuilder("divider")
            .AddClass("divider-horizontal", Horizontal)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Horizontal { get; set; }
    }
}

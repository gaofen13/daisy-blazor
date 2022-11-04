using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyMenuItemGroup
    {
        private string MenuGroupClass =>
            new ClassBuilder("menu-title")
            .AddClass(Class)
            .Build();

        [CascadingParameter]
        private DaisyMenu? Menu { get; set; }

        [Parameter]
        public string? Title { get; set; }
    }
}

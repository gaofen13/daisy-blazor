using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DaisyBlazor
{
    public partial class DaisyMenuItem
    {
        private string Classname =>
            new ClassBuilder()
            .AddClass("disabled", Disabled)
            .AddClass(Class)
            .Build();

        [CascadingParameter]
        private DaisyMenu? Root { get; set; }

        [Parameter]
        public string ActiveClass { get; set; } = "";

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

        [Parameter]
        public bool Disabled { get; set; }

        protected override void OnInitialized()
        {
            if (!string.IsNullOrWhiteSpace(Root?.ActiveClass))
            {
                ActiveClass = Root.ActiveClass;
            }
            base.OnInitialized();
        }
    }
}

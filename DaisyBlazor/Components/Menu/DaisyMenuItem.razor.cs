using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DaisyBlazor
{
    public partial class DaisyMenuItem
    {
        private string MenuItemClass =>
            new ClassBuilder()
            .AddClass("disabled", Disabled)
            .AddClass("bordered", Root?.Bordered == true)
            .AddClass(Class)
            .Build();

        private Dictionary<string, object>? NavLinkAttributes => Disabled || string.IsNullOrWhiteSpace(Href) ? null : new Dictionary<string, object> { { "href", Href } };

        [CascadingParameter]
        private DaisyMenu? Root { get; set; }

        [CascadingParameter]
        private DaisySubMenu? Parent { get; set; }

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public string? Text { get; set; }

        [Parameter]
        public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

        [Parameter]
        public bool Disabled { get; set; }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyMenuItem
    {
        private string Classname =>
            new ClassBuilder()
            .AddClass("disabled", Disabled)
            .AddClass("bordered", Menu?.Bordered == true)
            .AddClass(Class)
            .Build();

        private Dictionary<string, object>? NavLinkAttributes => Disabled || string.IsNullOrWhiteSpace(Href) ? null : new Dictionary<string, object> { { "href", Href } };

        [CascadingParameter]
        private DaisyMenu? Menu { get; set; }

        [Parameter]
        public string? Href { get; set; }

        [Parameter]
        public string? Text { get; set; }

        [Parameter]
        public NavLinkMatch Match { get; set; } = NavLinkMatch.Prefix;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        private void OnHandlerClick()
        {
            if (string.IsNullOrWhiteSpace(Href))
            {
                return;
            }
        }
    }
}

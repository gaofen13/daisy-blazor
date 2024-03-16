using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DaisyBlazor.Shared.Shared
{
    public partial class MainLayout : IDisposable
    {
        private bool showSidebar;

        private string? theme;

        private readonly string[] daisyTheme = ["light", "dark", "cupcake", "bumblebee", "emerald", "corporate", "synthwave", "retro", "cyberpunk", "valentine", "halloween", "garden", "forest", "aqua", "lofi", "pastel", "fantasy", "wireframe", "black", "luxury", "dracula", "cmyk", "autumn", "business", "acid", "lemonade", "night", "coffee", "winter"];

        [Inject]
        private NavigationManager Navigation { get; set; } = default!;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Navigation.LocationChanged += OnLoactionChanged;
            }
            base.OnAfterRender(firstRender);
        }

        private void OnLoactionChanged(object? sender, LocationChangedEventArgs args)
        {
            showSidebar = false;
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            Navigation.LocationChanged -= OnLoactionChanged;
            GC.SuppressFinalize(this);
        }
    }
}

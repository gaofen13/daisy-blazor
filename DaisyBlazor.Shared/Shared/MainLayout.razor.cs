using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace DaisyBlazor.Shared.Shared
{
    public partial class MainLayout : IDisposable
    {
        private bool _showSidebar;
        private bool _hideScrollToTop = true;
        private string? _theme;
        private int _windowWidth;
        private IJSObjectReference? _jsModule;
        private DotNetObjectReference<MainLayout>? _objectReference;

        private readonly string[] daisyTheme = ["light", "dark", "cupcake", "bumblebee", "emerald", "corporate", "synthwave", "retro", "cyberpunk", "valentine", "halloween", "garden", "forest", "aqua", "lofi", "pastel", "fantasy", "wireframe", "black", "luxury", "dracula", "cmyk", "autumn", "business", "acid", "lemonade", "night", "coffee", "winter"];

        private bool Persistent => _windowWidth >= 1024;

        private string DrawerStylelist =>
            new StyleBuilder()
            .AddStyle("z-index", "1001", _showSidebar && !Persistent)
            .Build();

        private string SiderStylelist =>
            new StyleBuilder()
            .AddStyle("height", "calc(100vh - 70px)", Persistent)
            .Build();

        [Inject]
        private IJSRuntime JSRuntime { get; set; } = default!;

        [Inject]
        private NavigationManager Navigation { get; set; } = default!;

        protected override void OnInitialized()
        {
            Navigation!.LocationChanged += OnLoactionChanged;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _objectReference = DotNetObjectReference.Create(this);
                _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import",
                     "./_content/DaisyBlazor.Shared/Shared/MainLayout.razor.js");
                await _jsModule!.InvokeVoidAsync("AddWindowWidthListener", _objectReference);
                //await _jsModule!.InvokeVoidAsync("AddScrollListener", _objectReference, "body");
                var width = await _jsModule!.InvokeAsync<int>("GetWindowWidth");
                UpdateLayout(width);
                // var scrollTop = await _jsModule!.InvokeAsync<double>("GetScrollTop");
                // UpdateScrollToTop(scrollTop);
            }
        }

        [JSInvokable]
        public void UpdateLayout(int width)
        {
            _windowWidth = width;
            if (width >= 1024)
            {
                if (!_showSidebar)
                {
                    _showSidebar = true;
                    StateHasChanged();
                }
            }
            else
            {
                if (_showSidebar)
                {
                    _showSidebar = false;
                    StateHasChanged();
                }
            }
        }

        [JSInvokable]
        public void UpdateScrollToTop(double scrollHeight)
        {
            if (scrollHeight >= 500)
            {
                if (_hideScrollToTop)
                {
                    _hideScrollToTop = false;
                    StateHasChanged();
                }
            }
            else
            {
                if (!_hideScrollToTop)
                {
                    _hideScrollToTop = true;
                    StateHasChanged();
                }
            }
        }

        private async Task ScrollToTopAsync()
        {
            await _jsModule!.InvokeVoidAsync("ScrollToTop");
        }

        private void OnLoactionChanged(object? sender, LocationChangedEventArgs args)
        {
            if (_windowWidth < 1024 && _showSidebar)
            {
                _showSidebar = false;
                StateHasChanged();
            }
        }

        void IDisposable.Dispose()
        {
            Navigation.LocationChanged -= OnLoactionChanged;
            GC.SuppressFinalize(this);
        }
    }
}

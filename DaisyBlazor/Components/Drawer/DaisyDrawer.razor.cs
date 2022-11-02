using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;

namespace DaisyBlazor
{
    public partial class DaisyDrawer
    {
        private DotNetObjectReference<DaisyDrawer>? _objectReference;
        private Size _breakpoint = Size.Md;
        private int _windowWidth;
        private int _breakpointWidth;
        private DrawerVariant _variant;
        private DrawerVariant _currentVariant;

        private bool OverlayVisible => _currentVariant == DrawerVariant.Temporary;

        private string DrawerClass =>
            new ClassBuilder("sidebar")
            .AddClass("sidebar-right", RightSide)
            .AddClass($"sidebar-{_currentVariant.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        private string DrawerStyle =>
            new StyleBuilder()
            .AddStyle(RightSide ? "--drawer-width-right" : "--drawer-width-left", Width)
            .AddStyle(Style)
            .Build();

        [Inject]
        private NavigationManager? Navigation { get; set; }

        [Inject]
        private IJSRuntime? JSRuntime { get; set; }

        [Parameter]
        public bool Show { get; set; }

        [Parameter]
        public EventCallback<bool> ShowChanged { get; set; }

        [Parameter]
        public bool RightSide { get; set; }

        [Parameter]
        public string Width { get; set; } = "14rem";

        [Parameter]
        public DrawerVariant Variant
        {
            get => _variant;
            set
            {
                if (_variant != value)
                {
                    _variant = value;
                    if (value == DrawerVariant.Responsive)
                    {
                        UpdateWindowWidth(_windowWidth);
                    }
                    else
                    {
                        _currentVariant = value;
                    }
                }
            }
        }

        [Parameter]
        public Size Breakpoint
        {
            get => _breakpoint;
            set
            {
                if (_breakpoint != value)
                {
                    _breakpoint = value;
                    _breakpointWidth = GetBreakpointWidth(value);
                }
            }
        }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            _breakpointWidth = GetBreakpointWidth(_breakpoint);
            Navigation!.LocationChanged += OnLoactionChanged;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _objectReference = DotNetObjectReference.Create(this);
                await JSRuntime!.InvokeVoidAsync("AddWindowWidthListener", _objectReference);
                var width = await JSRuntime!.InvokeAsync<int>("GetWindowWidth");
                UpdateWindowWidth(width);
                StateHasChanged();
            }
        }

        [JSInvokable]
        public void UpdateWindowWidth(int width)
        {
            _windowWidth = width;
            if (_windowWidth <= _breakpointWidth)
            {
                if (Variant == DrawerVariant.Responsive && _currentVariant != DrawerVariant.Temporary)
                {
                    _currentVariant = DrawerVariant.Temporary;
                }
                if (Show)
                {
                    Show = false;
                    ShowChanged.InvokeAsync(Show);
                }
            }
            else if (_windowWidth > _breakpointWidth)
            {
                if (Variant == DrawerVariant.Responsive && _currentVariant != DrawerVariant.Persistent)
                {
                    _currentVariant = DrawerVariant.Persistent;
                }
                if (!Show)
                {
                    Show = true;
                    ShowChanged.InvokeAsync(Show);
                }
            }
        }

        private void OnLoactionChanged(object? sender, LocationChangedEventArgs args)
        {
            if (_currentVariant == DrawerVariant.Temporary)
            {
                if (Show)
                {
                    Show = false;
                    ShowChanged.InvokeAsync(Show);
                }
            }
        }

        private async Task OnClickedOverlayAsync()
        {
            if (Show)
            {
                Show = false;
                await ShowChanged.InvokeAsync(Show);
            }
        }

        async ValueTask IAsyncDisposable.DisposeAsync()
        {
            try
            {
                if (_objectReference is not null)
                {
                    await JSRuntime!.InvokeVoidAsync("RemoveWindowWidthListener", _objectReference);
                    _objectReference.Dispose();
                }
                GC.SuppressFinalize(this);
            }
            finally { }
        }

        private static int GetBreakpointWidth(Size breakpoint)
        {
            return breakpoint switch
            {
                Size.Sm => 640,
                Size.Md => 768,
                Size.Lg => 1024,
                Size.Xl => 1280,
                _ => 768,
            };
        }
    }
}

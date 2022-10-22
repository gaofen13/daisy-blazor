using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor.Shared.Shared
{
    public partial class MainLayout
    {
        private DotNetObjectReference<MainLayout> objectReference = default!;
        private bool showSidebar = true;
        private int windowWidth;

        [Inject] NavigationManager? Navigation { get; set; }
        [Inject] IJSRuntime? JSRuntime { get; set; }

        private string ShowClass => showSidebar ? "sidebar-show" : "";

        protected override void OnInitialized()
        {
            objectReference = DotNetObjectReference.Create(this);
            Navigation!.LocationChanged += OnLoactionChanged;
            base.OnInitialized();
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime!.InvokeVoidAsync("AddWindowWidthListener", objectReference);
            }
            base.OnAfterRender(firstRender);
        }

        [JSInvokable]
        public void UpdateWindowWidth(int width)
        {
            windowWidth = width;
            if (windowWidth > 0 && windowWidth <= 768)
            {
                if (showSidebar)
                {
                    showSidebar = false;
                    StateHasChanged();
                }
            }
            else if (windowWidth > 768)
            {
                if (!showSidebar)
                {
                    showSidebar = true;
                    StateHasChanged();
                }
            }
        }

        private void OnLoactionChanged(object? sender, LocationChangedEventArgs args)
        {
            if (windowWidth > 0 && windowWidth <= 768)
            {
                if (showSidebar)
                {
                    showSidebar = false;
                    StateHasChanged();
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            await JSRuntime!.InvokeVoidAsync("RemoveWindowWidthListener", objectReference);
            objectReference.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

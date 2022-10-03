using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTab
    {
        private string Classname =>
          new ClassBuilder("Tab")
            .AddClass("tab-active", Active)
            .AddClass($"tab-{TabType.ToString()?.ToLower()}", TabType != null)
            .AddClass($"tab-{TabSize.ToString()?.ToLower()}", TabSize != null)
            .AddClass(Class)
            .Build();

        [CascadingParameter]
        private DaisyTabs DaisyTabs { get; set; } = default!;

        [Parameter]
        public string? TabName { get; set; }

        [Parameter]
        public RenderFragment? TabTemplate { get; set; }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]
        public Size? TabSize { get; set; }

        [Parameter]
        public TabType? TabType { get; set; }

        protected override void OnInitialized()
        {
            DaisyTabs.AddTab(this);
            base.OnInitialized();
        }

        public void ActiveTab()
        {
            Active = true;
            DaisyTabs.OnActiveTabChanged(this);
        }

        void IDisposable.Dispose()
        {
            DaisyTabs.RemoveTab(this);
            GC.SuppressFinalize(this);
        }
    }
}

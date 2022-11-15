using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTab
    {
        private bool _active;

        public string TabClass =>
            new ClassBuilder("tab")
            .AddClass($"tab-{Size.ToString().ToLower()}")
            .AddClass("tab-bordered", Bordered && !Lifted)
            .AddClass("tab-lifted", Lifted && !Bordered)
            .AddClass("tab-active", _active)
            .Build();

        [CascadingParameter]
        private DaisyTabs DaisyTabs { get; set; } = default!;

        [Parameter]
        public bool Bordered { get; set; }

        [Parameter]
        public bool Lifted { get; set; }

        [Parameter]
        public Size Size { get; set; } = Size.Md;

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public bool Default { get; set; }

        [Parameter]
        public EventCallback<bool> OnActived { get; set; }

        protected override void OnInitialized()
        {
            ActiveTab(Default);
            DaisyTabs.AddTab(this);
            base.OnInitialized();
        }

        public void ActiveTab(bool active)
        {
            _active = active;
            OnActived.InvokeAsync(active);
        }

        void IDisposable.Dispose()
        {
            DaisyTabs.RemoveTab(this);
            GC.SuppressFinalize(this);
        }
    }
}

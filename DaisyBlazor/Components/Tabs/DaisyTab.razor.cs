using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTab
    {
        private bool _actived;

        private string TitleClassname =>
            new ClassBuilder("tab")
            .AddClass("tab-active", _actived)
            .AddClass(TitleClass)
            .Build();

        private string ContentClassname =>
            new ClassBuilder("tab-content bg-base-100 border-base-300 rounded-lg")
            .AddClass(ContentClass)
            .Build();

        private string TitleStylelist =>
            new StyleBuilder()
            .AddStyle(TitleStyle)
            .Build();

        private string ContentStylelist =>
            new StyleBuilder()
            .AddStyle(ContentStyle)
            .Build();

        [CascadingParameter]
        private DaisyTabs? DaisyTabs { get; set; }

        [Parameter]
        public string? Title { get; set; }

        [Parameter]
        public RenderFragment? TitleContent { get; set; }

        [Parameter]
        public string? TitleClass { get; set; }

        [Parameter]
        public string? TitleStyle { get; set; }

        [Parameter]
        public string? ContentClass { get; set; }

        [Parameter]
        public string? ContentStyle { get; set; }

        [Parameter]
        public bool Default { get; set; }

        [Parameter]
        public EventCallback<bool> OnChanged { get; set; }

        protected override void OnInitialized()
        {
            if (Default)
            {
                OnTabChanged(true);
                DaisyTabs?.OnActivedItemChanged(this);
            }
            base.OnInitialized();
        }

        internal void OnTabChanged(bool actived)
        {
            _actived = actived;
            StateHasChanged();
            if (OnChanged.HasDelegate)
            {
                OnChanged.InvokeAsync(actived);
            }
        }

        private void OnClickItem()
        {
            if (!_actived)
            {
                OnTabChanged(true);
                DaisyTabs?.OnActivedItemChanged(this);
            }
        }
    }
}

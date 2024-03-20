using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTabs
    {
        private DaisyTab? _currentActivedItem;

        private string Classname =>
            new ClassBuilder("tabs")
            .AddClass("tabs-lifted")
            .AddClass($"tabs-{Size.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public Size Size { get; set; } = Size.Md;

        internal void OnActivedItemChanged(DaisyTab item)
        {
            _currentActivedItem?.OnTabChanged(false);
            _currentActivedItem = item;
        }
    }
}

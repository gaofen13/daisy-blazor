using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTabs
    {
        private readonly List<DaisyTab> _tabs = new();
        private DaisyTab? _activeTab;

        private string TabsClass =>
            new ClassBuilder("tabs")
            .AddClass("tabs-boxed", Boxed)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Boxed { get; set; }

        public void AddTab(DaisyTab tab)
        {
            if (!_tabs.Contains(tab))
            {
                _tabs.Add(tab);
                if (tab.Default)
                {
                    OnActiveTabChanged(tab);
                }
                StateHasChanged();
            }
        }

        public void RemoveTab(DaisyTab tab)
        {
            if (_tabs.Contains(tab))
            {
                _tabs.Remove(tab);
                if (_activeTab == tab)
                {
                    var activeTab = _tabs.FirstOrDefault();
                    if (activeTab != null)
                    {
                        OnActiveTabChanged(activeTab);
                    }
                }
                StateHasChanged();
            }
        }

        private void OnActiveTabChanged(DaisyTab tab)
        {
            if (_activeTab != tab)
            {
                _activeTab?.DisactiveTab();
                _activeTab = tab;
                _activeTab.ActiveTab();
            }
        }
    }
}

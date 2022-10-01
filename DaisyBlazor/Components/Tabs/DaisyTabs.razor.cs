using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTabs
    {
        private List<DaisyTab> _tabs = new();
        private DaisyTab? _activeTab;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        public void AddTab(DaisyTab tab)
        {
            if (!_tabs.Contains(tab))
            {
                _tabs.Add(tab);
                if (_activeTab == null)
                {
                    tab.ActiveTab();
                }
            }
        }

        public void RemoveTab(DaisyTab tab)
        {
            if (_tabs.Contains(tab))
            {
                _tabs.Remove(tab);
                if (_activeTab == tab)
                {
                    _tabs.FirstOrDefault()?.ActiveTab();
                }
            }
        }

        public void OnActiveTabChanged(DaisyTab tab)
        {
            if (_activeTab != tab)
            {
                _activeTab = tab;
            }
        }
    }
}

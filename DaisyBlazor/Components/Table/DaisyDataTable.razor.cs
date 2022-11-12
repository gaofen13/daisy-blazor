using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyDataTable<TItem> : IDataTable<TItem>
    {
        private IEnumerable<TItem> _items = Enumerable.Empty<TItem>();
        private IEnumerable<TItem> _currentPageItems = Enumerable.Empty<TItem>();
        private readonly PagerState _pagerState = new(1, 10);
        private List<TItem> _selectedItems = new();
        private int _totalPager;

        private string TableClass =>
            new ClassBuilder("table")
            .AddClass("table-hover", Hover)
            .AddClass("table-zebra", Zebra)
            .AddClass("table-border", Border)
            .AddClass("table-compact", Compact)
            .AddClass(Class)
            .Build();

        private string PagerClass =>
            new ClassBuilder("table-pager")
            .AddClass($"pager-{PagePosition.ToString().ToLower()}")
            .Build();

        private static TItem DefaultValue
        {
            get
            {
                TItem? item = default;
                if (item == null)
                {
                    return Activator.CreateInstance<TItem>();
                }
                else
                {
                    return item;
                }
            }
        }

        [Parameter]
        public IEnumerable<TItem>? Items
        {
            get => _items;
            set
            {
                if (value == null)
                {
                    _items = Enumerable.Empty<TItem>();
                }
                else
                {
                    _items = value;
                }
                if (_selectedItems.Any())
                {
                    _selectedItems.Clear();
                    SelectedItemsChanged.InvokeAsync(_selectedItems);
                }
            }
        }

        [Parameter]
        public Func<PagerState, Task<TableData<TItem>>>? ServerDataFunc { get; set; }

        [Parameter]
        public IEnumerable<TItem> SelectedItems
        {
            get => _selectedItems;
            set
            {
                _selectedItems = value.ToList();
            }
        }

        [Parameter]
        public EventCallback<IEnumerable<TItem>> SelectedItemsChanged { get; set; }

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
        public bool Border { get; set; }

        [Parameter]
        public bool Hover { get; set; } = true;

        [Parameter]
        public bool Zebra { get; set; } = true;

        [Parameter]
        public bool Compact { get; set; }

        [Parameter]
        public RenderFragment<TItem>? Columns { get; set; }

        [Parameter]
        public RenderFragment? ToolbarTemplate { get; set; }

        [Parameter]
        public RenderFragment? HeadTemplate { get; set; }

        [Parameter]
        public RenderFragment? FootTemplate { get; set; }

        [Parameter]
        public bool ShowPager { get; set; }

        [Parameter]
        public bool OutlinePager { get; set; }

        [Parameter]
        public int PageSzie
        {
            get => _pagerState.PageSize;
            set
            {
                if (_pagerState.PageSize != value && value > 0)
                {
                    _pagerState.PageSize = value;
                    PageIndex = 1;
                    InvokeAsync(SetCurrentPageDataAsync);
                }
            }
        }

        [Parameter]
        public int PageIndex
        {
            get => _pagerState.PageIndex;
            set
            {
                if (_pagerState.PageIndex != value && value > 0)
                {
                    _pagerState.PageIndex = value;
                    InvokeAsync(SetCurrentPageDataAsync);
                }
            }
        }

        [Parameter]
        public int[] PageSizeOption { get; set; } = { 10, 20, 50, 100 };

        [Parameter]
        public PositionX PagePosition { get; set; }

        [Parameter]
        public RenderFragment? PagerTemplate { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (ServerDataFunc == null)
            {
                await SetCurrentPageDataAsync();
            }
            await base.OnInitializedAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender && ServerDataFunc != null)
            {
                await SetCurrentPageDataAsync();
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        public void AddSelectedItem(TItem item)
        {
            if (!_selectedItems.Contains(item))
            {
                _selectedItems.Add(item);
                SelectedItemsChanged.InvokeAsync(_selectedItems);
                if (_selectedItems.Count == _currentPageItems?.Count())
                {
                    StateHasChanged();
                }
            }
        }

        public void RemoveSelectedItem(TItem item)
        {
            if (_selectedItems.Contains(item))
            {
                _selectedItems.Remove(item);
                SelectedItemsChanged.InvokeAsync(_selectedItems);
                if (_selectedItems.Count + 1 == _currentPageItems?.Count())
                {
                    StateHasChanged();
                }
            }
        }

        public void SelectAllItems()
        {
            SelectedItems = _currentPageItems;
            SelectedItemsChanged.InvokeAsync(SelectedItems);
            StateHasChanged();
        }

        public void ClearSelectedItems()
        {
            _selectedItems.Clear();
            SelectedItemsChanged.InvokeAsync(SelectedItems);
            StateHasChanged();
        }

        private async Task SetCurrentPageDataAsync()
        {
            var items = Enumerable.Empty<TItem>();
            if (ShowPager)
            {
                if (ServerDataFunc != null)
                {
                    var res = await ServerDataFunc.Invoke(_pagerState);
                    if (res.Data != null)
                    {
                        items = res.Data;
                    }
                    _totalPager = GetTotalPageCount(res.Total, _pagerState.PageSize);
                }
                else
                {
                    items = _items.Skip((_pagerState.PageIndex - 1) * _pagerState.PageSize).Take(_pagerState.PageSize);
                    _totalPager = GetTotalPageCount(_items.Count(), _pagerState.PageSize);
                }
            }
            _currentPageItems = items;
        }

        private static int GetTotalPageCount(int total, int size)
        {
            var pageCount = total / size;
            return total % size == 0 ? pageCount : pageCount + 1;
        }
    }
}
﻿using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyDataTable<TItem> : IDataTable<TItem>
    {
        private IEnumerable<TItem> _items = Enumerable.Empty<TItem>();
        private List<TItem> _selectedItems = new();
        private int _pageIndex = 1;
        private int _pageSize = 10;

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

        private TItem DefaultValue => Activator.CreateInstance<TItem>();

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
        public int TotalPager { get; set; }

        [Parameter]
        public int PageSzie
        {
            get => _pageSize;
            set
            {
                if (_pageSize != value && value > 0)
                {
                    _pageSize = value;
                    PageSizeChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<int> PageSizeChanged { get; set; }

        [Parameter]
        public int PageIndex
        {
            get => _pageIndex;
            set
            {
                if (_pageIndex != value && value > 0)
                {
                    _pageIndex = value;
                    PageIndexChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<int> PageIndexChanged { get; set; }

        [Parameter]
        public int[] PageSizeOption { get; set; } = { 10, 20, 50, 100 };

        [Parameter]
        public PositionX PagePosition { get; set; }

        [Parameter]
        public RenderFragment? PagerTemplate { get; set; }

        public void AddSelectedItem(TItem item)
        {
            if (!_selectedItems.Contains(item))
            {
                _selectedItems.Add(item);
                SelectedItemsChanged.InvokeAsync(_selectedItems);
                if (_selectedItems.Count == Items?.Count())
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
                if (_selectedItems.Count + 1 == Items?.Count())
                {
                    StateHasChanged();
                }
            }
        }

        public void SelectAllItems()
        {
            SelectedItems = _items;
            SelectedItemsChanged.InvokeAsync(_items);
            StateHasChanged();
        }

        public void ClearSelectedItems()
        {
            _selectedItems.Clear();
            SelectedItemsChanged.InvokeAsync(_selectedItems);
            StateHasChanged();
        }
    }
}
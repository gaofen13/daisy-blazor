using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTable<TItem> : ITable<TItem>
    {
        private IEnumerable<TItem> _items = [];
        private List<TItem> _selectedItems = [];

        private string Classname =>
            new ClassBuilder("table")
            .AddClass("table-zebra", Zebra)
            .AddClass("table-pin-cols", PinCols)
            .AddClass("table-pin-rows", PinRows)
            .AddClass($"table-{Size.ToString().ToLower()}")
            .AddClass(Class)
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
#pragma warning disable BL0007 // Component parameters should be auto properties
        public IEnumerable<TItem>? Items
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _items;
            set
            {
                if (value == null)
                {
                    _items = [];
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
#pragma warning disable BL0007 // Component parameters should be auto properties
        public IEnumerable<TItem> SelectedItems
#pragma warning restore BL0007 // Component parameters should be auto properties
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
        public bool PinRows { get; set; }

        [Parameter]
        public bool Hover { get; set; } = true;

        [Parameter]
        public bool Zebra { get; set; } = true;

        [Parameter]
        public bool PinCols { get; set; }

        [Parameter]
        public Size Size { get; set; } = Size.Md;

        [Parameter]
        public RenderFragment<TItem>? Columns { get; set; }

        [Parameter]
        public RenderFragment? HeadContent { get; set; }

        [Parameter]
        public RenderFragment? FootContent { get; set; }

        public void AddSelectedItem(TItem item)
        {
            if (!_selectedItems.Contains(item))
            {
                _selectedItems.Add(item);
                SelectedItemsChanged.InvokeAsync(_selectedItems);
            }
        }

        public void RemoveSelectedItem(TItem item)
        {
            _selectedItems?.Remove(item);
            SelectedItemsChanged.InvokeAsync(_selectedItems);
        }

        public void SelectAllItems()
        {
            SelectedItems = _items;
            SelectedItemsChanged.InvokeAsync(SelectedItems);
            StateHasChanged();
        }

        public void ClearSelectedItems()
        {
            _selectedItems.Clear();
            SelectedItemsChanged.InvokeAsync(SelectedItems);
            StateHasChanged();
        }
    }
}
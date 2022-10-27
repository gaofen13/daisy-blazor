using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyHeadTr<TItem>
    {
        private string TrClass =>
            new ClassBuilder()
            .AddClass(Class)
            .Build();

        private bool Checked => SelectedItems?.Count() == Items?.Count();

        [CascadingParameter]
        public IDataTable<TItem>? Table { get; set; }

        [Parameter]
        public IEnumerable<TItem>? SelectedItems { get; set; }

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
        public IEnumerable<TItem>? Items { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        private void OnCheckedChanged(bool @checked)
        {
            if (@checked)
            {
                Table?.SelectAllItems();
            }
            else
            {
                Table?.ClearSelectedItems();
            }
        }
    }
}

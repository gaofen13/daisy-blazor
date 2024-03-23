using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace DaisyBlazor
{
    public partial class DaisyTr<TItem>
    {
        private string TrClass =>
            new ClassBuilder()
            .AddClass("hover", Table?.Hover == true)
            .AddClass("bg-base-200", Checked)
            .AddClass(Class)
            .Build();

        private bool Checked => SelectedItems?.Contains(Item) == true;

        [CascadingParameter]
        public ITable<TItem>? Table { get; set; }

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
        public IEnumerable<TItem>? SelectedItems { get; set; }

        [Parameter]
        [NotNull]
        public TItem? Item { get; set; }

        private void OnCheckedChanged(bool @checked)
        {
            if (@checked)
            {
                Table?.AddSelectedItem(Item);
            }
            else
            {
                Table?.RemoveSelectedItem(Item);
            }
        }
    }
}

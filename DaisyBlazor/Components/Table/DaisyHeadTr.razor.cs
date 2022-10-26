using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyHeadTr
    {
        private bool _checked;

        private string TrClass =>
            new ClassBuilder()
            .AddClass(Class)
            .Build();

        private bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    if (Checked)
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

        [CascadingParameter]
        public IDataTable? Table { get; set; }

        [Parameter]
        public bool MultiSelection { get; set; }

        [Parameter]
        public IEnumerable<dynamic>? Items { get; set; }

        [CascadingParameter(Name = "SelectedItems")]
        public IEnumerable<dynamic>? SelectedItems { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (SelectedItems == Items)
            {
                _checked = true;
            }
            base.OnInitialized();
        }
    }
}

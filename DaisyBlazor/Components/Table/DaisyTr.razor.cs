﻿using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyTr
    {
        private bool _checked;

        private string TrClass =>
            new ClassBuilder()
            .AddClass("active", Checked)
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
                        Table?.AddSelectedItem(Item);
                    }
                    else
                    {
                        Table?.RemoveSelectedItem(Item);
                    }
                }
            }
        }

        [CascadingParameter]
        public IDataTable? Table { get; set; }

        [CascadingParameter(Name = "MultiSelection")]
        public bool MultiSelection { get; set; }

        [CascadingParameter(Name = "SelectedItems")]
        public IEnumerable<dynamic>? SelectedItems { get; set; }

        [Parameter]
        public object Item { get; set; } = new();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override void OnInitialized()
        {
            if (SelectedItems?.Contains(Item) == true)
            {
                _checked = true;
            }
            base.OnInitialized();
        }
    }
}

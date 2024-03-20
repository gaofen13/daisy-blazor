using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyDrawer
    {
        private bool _open;

        private bool Checked => _open && !Persistent;

        private string Classname =>
            new ClassBuilder("drawer")
            .AddClass("drawer-open", Open && Persistent)
            .AddClass("drawer-end", RightSide)
            .AddClass(Class)
            .Build();

        private string SiderClassname =>
            new ClassBuilder("drawer-side")
            .AddClass(SiderClass)
            .Build();

        private string ContentClassname =>
            new ClassBuilder("drawer-content")
            .AddClass(SiderClass)
            .Build();

        [Parameter]
#pragma warning disable BL0007 // Component parameters should be auto properties
        public bool Open
#pragma warning restore BL0007 // Component parameters should be auto properties
        {
            get => _open;
            set
            {
                if (_open != value)
                {
                    _open = value;
                    OpenChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<bool> OpenChanged { get; set; }

        [Parameter]
        public RenderFragment? SiderContent { get; set; }

        [Parameter]
        public string? SiderClass { get; set; }

        [Parameter]
        public string? SiderStyle { get; set; }

        [Parameter]
        public string? ContentClass { get; set; }

        [Parameter]
        public string? ContentStyle { get; set; }

        [Parameter]
        public bool Persistent { get; set; }

        [Parameter]
        public bool RightSide { get; set; }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyDrawer
    {
        private string Classname =>
            new ClassBuilder("drawer")
            .AddClass("drawer-end", RightSide)
            .AddClass(Class)
            .Build();

        private bool CurrentOpened
        {
            get => Open;
            set
            {
                if (Open != value)
                {
                    Open = value;
                    OpenChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public bool Open { get; set; }

        [Parameter]
        public EventCallback<bool> OpenChanged { get; set; }

        [Parameter]
        public bool RightSide { get; set; }

        private void OnOpenChanged(ChangeEventArgs args)
        {
            var value = (bool)args.Value!;
            CurrentOpened = value;
        }
    }
}

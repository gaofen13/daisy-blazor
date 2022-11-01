using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyInputText
    {
        private string InputClass =>
          new ClassBuilder("input")
            .AddClass("input-bordered", Bordered)
            .AddClass("input-ghost ", Ghost)
            .AddClass($"input-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"input-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender && AutoFocus)
            {
                await FocusAsync();
            }
        }

        private void OnInputChanged(ChangeEventArgs args)
        {
            var value = args.Value as string;
            if (Value != value)
            {
                Value = value;
                ValueChanged.InvokeAsync(Value);
            }
        }
    }
}

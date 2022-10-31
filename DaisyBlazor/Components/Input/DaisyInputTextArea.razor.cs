using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyInputTextArea
    {
        private string Classname =>
          new ClassBuilder("textarea")
            .AddClass("textarea-bordered", Bordered)
            .AddClass("textarea-ghost ", Ghost)
            .AddClass($"textarea-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public Color? Color { get; set; }

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

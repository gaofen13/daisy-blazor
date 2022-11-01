using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCheckbox
    {
        private string CheckboxClass =>
          new ClassBuilder("checkbox")
            .AddClass($"checkbox-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"checkbox-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        private string ContainerClass =>
          new ClassBuilder("input-container")
            .AddClass($"label-{LabelPosition.ToString()?.ToLower()}")
            .Build();

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public Size? Size { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public Position LabelPosition { get; set; } = Position.Right;

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender && AutoFocus)
            {
                await FocusAsync();
            }
        }

        private void OnCheckedChanged(ChangeEventArgs args)
        {
            if (args.Value is not null)
            {
                var value = (bool)args.Value;
                if (Value != value)
                {
                    Value = value;
                    ValueChanged.InvokeAsync(Value);
                }
            }
        }
    }
}

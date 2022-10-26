using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace DaisyBlazor
{
    public partial class DaisyCheckbox
    {
        private string Classname =>
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

        private void OnCheckedChanged(ChangeEventArgs args)
        {
            if(args.Value is not null)
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

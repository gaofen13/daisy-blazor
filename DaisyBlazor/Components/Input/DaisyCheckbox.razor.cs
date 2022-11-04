using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System.Diagnostics.CodeAnalysis;

namespace DaisyBlazor
{
    public partial class DaisyCheckbox
    {
        private string CheckboxClass =>
          new ClassBuilder("checkbox")
            .AddClass($"checkbox-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"checkbox-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(FieldClass)
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

        private void OnInputChanged(ChangeEventArgs args)
        {
            CurrentValue = Convert.ToBoolean(args.Value);
        }
    }
}

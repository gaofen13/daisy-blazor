using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Globalization;

namespace DaisyBlazor
{
    public partial class DaisySelect<TValue>
    {
        private readonly List<DaisySelectOption<TValue>> _options = new();

        private string Classname =>
          new ClassBuilder("select")
            .AddClass("select-bordered", Bordered)
            .AddClass("select-ghost ", Ghost)
            .AddClass($"select-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"select-{Size.ToString()?.ToLower()}", Size != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public RenderFragment? ChildContent { get; set; }

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

        private bool CheckCurrentValue(TValue? value)
        {
            if (Value == null && value == null)
            {
                return true;
            }
            return Value?.Equals(value) == true;
        }

        private void OnSelectionChanged(ChangeEventArgs args)
        {
            if (BindConverter.TryConvertTo(args.Value, CultureInfo.InvariantCulture, out TValue? res))
            {
                if (!CheckCurrentValue(res))
                {
                    Value = res;
                    ValueChanged.InvokeAsync(Value);
                }
            }
        }
    }
}

using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyLoading
    {
        private string Classname =>
            new ClassBuilder("loading")
            .AddClass($"text-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass($"loading-{Icon.ToString().ToLower()}")
            .AddClass($"loading-{Size.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [Parameter]
        public LoadingIcon Icon { get; set; } = LoadingIcon.spinner;

        [Parameter]
        public Size Size { get; set; } = Size.Md;

        [Parameter]
        public Color? Color { get; set; }

        public enum LoadingIcon
        {
            spinner,
            dots,
            ring,
            ball,
            bars,
            infinity
        }
    }
}

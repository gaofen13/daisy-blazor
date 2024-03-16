using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyLayout
    {
        private string Classname =>
            new ClassBuilder("absolute top-0 bottom-0 left-0 right-0")
            .AddClass(Class)
            .Build();

        [Parameter]
        public string? Theme { get; set; }
    }
}
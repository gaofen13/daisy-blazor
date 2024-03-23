using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCountdown
    {
        private string Classname =>
            new ClassBuilder("countdown")
            .AddClass(Class)
            .Build();

        [Parameter]
        public int Value { get; set; }
    }
}

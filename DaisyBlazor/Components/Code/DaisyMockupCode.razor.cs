using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyMockupCode
    {
        private string MockupClass =>
            new ClassBuilder("mockup-code")
            .AddClass(Class)
            .Build();
    }
}

using DaisyBlazor.Utilities;

namespace DaisyBlazor
{
    public partial class DaisyMockupCode
    {
        private string Classname =>
            new ClassBuilder("mockup-code")
            .AddClass(Class)
            .Build();
    }
}

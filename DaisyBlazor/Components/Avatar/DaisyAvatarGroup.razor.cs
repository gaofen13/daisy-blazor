using DaisyBlazor.Utilities;

namespace DaisyBlazor
{
    public partial class DaisyAvatarGroup
    {
        private string Classname =>
            new ClassBuilder("avatar-group -space-x-6")
            .AddClass(Class)
            .Build();
    }
}
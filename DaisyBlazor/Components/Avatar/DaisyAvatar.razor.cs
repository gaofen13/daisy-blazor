using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyAvatar
    {
        private string Classname =>
            new ClassBuilder("avatar")
            .AddClass("placeholder", Placeholder)
            .AddClass("offline", Offline)
            .AddClass("online", Online)
            .AddClass(Class)
            .Build();

        private string ContainerClassname =>
            new ClassBuilder("rounded")
            .AddClass("bg-neutral text-neutral-content", Placeholder)
            .AddClass("rounded-full", Circle)
            .AddClass(GetSizeClass())
            .Build();

        [Parameter]
        public Size Size { get; set; } = Size.Md;

        [Parameter]
        public bool Circle { get; set; }

        [Parameter]
        public bool Online { get; set; }

        [Parameter]
        public bool Offline { get; set; }

        [Parameter]
        public bool Placeholder { get; set; }

        private string GetSizeClass()
        {
            return Size switch
            {
                Size.Lg => "w-24",
                Size.Md => "w-20",
                Size.Sm => "w-16",
                Size.Xs => "w-12",
                _ => "w-20",
            };
        }
    }
}
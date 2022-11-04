using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisySimpleTable
    {
        private string TableClass =>
            new ClassBuilder("table")
            .AddClass("table-hover", Hover)
            .AddClass("table-zebra", Zebra)
            .AddClass("table-border", Border)
            .AddClass("table-compact", Compact)
            .AddClass(Class)
            .Build();

        [Parameter]
        public bool Hover { get; set; } = true;

        [Parameter]
        public bool Zebra { get; set; } = true;

        [Parameter]
        public bool Border { get; set; }

        [Parameter]
        public bool Compact { get; set; }
    }
}

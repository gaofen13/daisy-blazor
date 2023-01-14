using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyCountdown
    {
        private string CountdownClass =>
            new ClassBuilder("countdown")
            .AddClass("countdown-label-under", UnderLabel)
            .AddClass($"countdown-inbox", Inbox)
            .AddClass(Class)
            .Build();

        /// <summary>
        /// 起始数值，必须为0到99之间的数值
        /// </summary>
        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public bool Inbox { get; set; }

        [Parameter]
        public bool UnderLabel { get; set; }

        [Parameter]
        public string? Label { get; set; }

        [Parameter]
        public RenderFragment? LabelContent { get; set; }
    }
}

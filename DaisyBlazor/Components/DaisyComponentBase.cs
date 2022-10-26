﻿using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public class DaisyComponentBase : ComponentBase
    {
        public ElementReference? Element { get; protected set; }

        [Parameter]
        public string? Class { get; set; }

        [Parameter]
        public string? Style { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public Dictionary<string, object>? Attributes { get; set; }

        [Parameter]
        public string? Id { get; set; }
    }
}

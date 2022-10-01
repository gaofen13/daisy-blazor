using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyProgress
    {
        private string Classname =>
          new ClassBuilder("progress")
            .AddClass($"progress-{Color.ToString()?.ToLower()}", Color != null)
            .AddClass(Class)
            .Build();

        [Parameter]
        public int Value { get; set; }

        [Parameter]
        public int Max { get; set; } = 100;

        [Parameter]
        public Color? Color { get; set; }

        [Parameter]
        public bool Indeterminate { get; set; }
    }
}

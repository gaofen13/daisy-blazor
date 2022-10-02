using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public class ToastOptions
    {
        public bool Filled { get; set; }

        public bool ShowIcon { get; set; } = true;

        public bool ShowProgressBar { get; set; } = true;

        public int TimeOut { get; set; } = 5;
    }
}

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
        public int TimeOut { get; set; } = 5;

        public bool ShowProgress { get; set; } = true;

        public bool ShowCloseButton { get; set; } = true;

        public bool ShowIcon { get; set; } = true;

        public bool Filled { get; set; }
    }
}

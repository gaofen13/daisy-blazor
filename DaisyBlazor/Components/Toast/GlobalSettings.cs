using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public class GlobalSettings
    {
        public PositionX PositionX { get; set; }

        public PositionY PositionY { get; set; }

        public bool Filled { get; set; }

        public bool ShowIcon { get; set; } = true;

        public bool ShowProgressBar { get; set; } = true;

        public bool RemoveToastsOnNavigation { get; set; }

        public int MaxItemsShown { get; set; } = 10;

        public int TimeOut { get; set; } = 5;
    }
}

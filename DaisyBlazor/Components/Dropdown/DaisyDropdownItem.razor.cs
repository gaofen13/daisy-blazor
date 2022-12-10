using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public partial class DaisyDropdownItem
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}

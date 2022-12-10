using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace DaisyBlazor
{
    public partial class DaisyDropdownItem
    {
        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }
    }
}

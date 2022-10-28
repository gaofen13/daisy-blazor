using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyPagination
    {
        private int _index = 1;
        private int _size = 10;

        private bool PrevDisabled => PageIndex <= 1 || Total <= 0;

        private bool NexDisabled => PageIndex == Total || Total <= 0;

        [Parameter]
        public int Total { get; set; }

        [Parameter]
        public bool ShowSizeOption { get; set; } = true;

        [Parameter]
        public string SizeOptionLabel { get; set; } = "每页行数：";

        [Parameter]
        public int[] SizeOption { get; set; } = { 10, 20, 50, 100 };

        [Parameter]
        public int PageSize
        {
            get => _size;
            set
            {
                if (_size != value && value > 0)
                {
                    _size = value;
                    PageSizeChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<int> PageSizeChanged { get; set; }

        [Parameter]
        public int PageIndex
        {
            get => _index;
            set
            {
                if (value > 0 && value <= Total && _index != value)
                {
                    _index = value;
                    PageIndexChanged.InvokeAsync(value);
                }
            }
        }

        [Parameter]
        public EventCallback<int> PageIndexChanged { get; set; }

        private void OnClickPrev()
        {
            if (PageIndex > 1)
            {
                PageIndex--;
            }
        }

        private void OnClickNex()
        {
            if (PageIndex < Total)
            {
                PageIndex++;
            }
        }

        private void OnClickPager(int pager)
        {
            PageIndex = pager;
        }
    }
}

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

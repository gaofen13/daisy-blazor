namespace DaisyBlazor
{
    public class ToastOptions
    {
        public bool AutoClose { get; set; } = true;
        
        /// <summary>
        /// Milliseconds, default:5000
        /// </summary>
        public int TimeOut { get; set; } = 5000;

        public bool ShowCloseButton { get; set; } = true;
    }
}

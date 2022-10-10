namespace DaisyBlazor
{
    public class ModalOptions
    {
        public Size MaxWidth { get; set; } = Size.Md;
        public string? OverlayClass { get; set; }
        public bool ClickBackgroundCancel { get; set; }
    }
}

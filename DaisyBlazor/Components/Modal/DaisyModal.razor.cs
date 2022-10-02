using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyModal
    {
        private string? _overlayClass;
        private bool _clickBackgroundCancel;

        private string Classname =>
          new ClassBuilder("modal-box relative")
            .AddClass(Class)
            .Build();

        [CascadingParameter] private DaisyModalContainer? ModalContainer { get; set; }

        [Parameter] public ModalOptions? Options { get; set; }
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public bool Visible { get; set; }
        [Parameter] public Guid InstanceId { get; set; }

        protected override void OnInitialized()
        {
            if (!string.IsNullOrWhiteSpace(Options?.OverlayClass))
            {
                _overlayClass = Options.OverlayClass;
            }
            else if (!string.IsNullOrWhiteSpace(ModalContainer?.GlobalOptions?.OverlayClass))
            {
                _overlayClass = ModalContainer.GlobalOptions.OverlayClass;
            }

            _clickBackgroundCancel = Options?.ClickBackgroundCancel == true || ModalContainer?.GlobalOptions?.ClickBackgroundCancel == true;

            base.OnInitialized();
        }

        /// <summary>
        /// Closes the modal with a default Ok result />.
        /// </summary>
        public async Task CloseAsync() => await CloseAsync(ModalResult.Ok());

        /// <summary>
        /// Closes the modal with the specified <paramref name="modalResult"/>.
        /// </summary>
        /// <param name="modalResult"></param>
        public async Task CloseAsync(ModalResult modalResult)
        {
            if (ModalContainer is not null)
            {
                await ModalContainer.DismissInstance(InstanceId, modalResult);
            }
        }

        /// <summary>
        /// Closes the modal and returns a cancelled ModalResult.
        /// </summary>
        public async Task CancelAsync() => await CloseAsync(ModalResult.Cancel());

        /// <summary>
        /// Closes the modal returning the specified <paramref name="payload"/> in a cancelled ModalResult.
        /// </summary>
        public async Task CancelAsync<TPayload>(TPayload payload) => await CloseAsync(ModalResult.Cancel(payload));

        private async Task OnClickBackgroundAsync()
        {
            if (_clickBackgroundCancel)
            {
                await CancelAsync();
            }
        }
    }
}

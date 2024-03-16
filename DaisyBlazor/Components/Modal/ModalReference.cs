using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public class ModalReference
    {
        private readonly TaskCompletionSource<ModalResult> _resultCompletion = new(TaskCreationOptions.RunContinuationsAsynchronously);
        private readonly Action<ModalResult> _closed;
        private readonly ModalService _modalService;

        internal RenderFragment ModalContent { get; }

        public ModalReference(RenderFragment modalContent, ModalService modalService)
        {
            ModalContent = modalContent;
            _closed = HandleClosed;
            _modalService = modalService;
        }

        public void Close(ModalResult result) => _modalService.Close(result);

        public Task<ModalResult> Result => _resultCompletion.Task;

        internal void Dismiss(ModalResult result) => _closed.Invoke(result);

        private void HandleClosed(ModalResult obj) => _resultCompletion.TrySetResult(obj);
    }
}

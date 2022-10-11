﻿using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyModal
    {
        private string? _overlayClass;
        private bool _clickBackgroundCancel;

        private string Classname =>
          new ClassBuilder("flex justify-center modal-w-full")
            .AddClass($"max-w-{Options.MaxWidth.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [CascadingParameter] private DaisyModalContainer? ModalContainer { get; set; }

        [Parameter] public ModalOptions Options { get; set; } = new();
        [Parameter] public RenderFragment? ChildContent { get; set; }
        [Parameter] public bool Visible { get; set; }
        [Parameter] public Guid InstanceId { get; set; }

        protected override void OnInitialized()
        {
            if (!string.IsNullOrWhiteSpace(Options.OverlayClass))
            {
                _overlayClass = Options.OverlayClass;
            }
            else if (!string.IsNullOrWhiteSpace(ModalContainer?.GlobalOptions.OverlayClass))
            {
                _overlayClass = ModalContainer.GlobalOptions.OverlayClass;
            }

            _clickBackgroundCancel = Options.ClickBackgroundCancel || ModalContainer?.GlobalOptions.ClickBackgroundCancel == true;

            base.OnInitialized();
        }

        /// <summary>
        /// Closes the modal with a default Ok result />.
        /// </summary>
        public void Close() => Close(ModalResult.Ok());

        /// <summary>
        /// Closes the modal with the specified <paramref name="modalResult"/>.
        /// </summary>
        /// <param name="modalResult"></param>
        public void Close(ModalResult modalResult)
        {
            ModalContainer?.DismissInstance(InstanceId, modalResult);
        }

        /// <summary>
        /// Closes the modal and returns a cancelled ModalResult.
        /// </summary>
        public void Cancel() => Close(ModalResult.Cancel());

        /// <summary>
        /// Closes the modal returning the specified <paramref name="payload"/> in a cancelled ModalResult.
        /// </summary>
        public void Cancel<TPayload>(TPayload payload) => Close(ModalResult.Cancel(payload));

        private void OnClickBackgroundAsync()
        {
            if (_clickBackgroundCancel)
            {
                Cancel();
            }
        }
    }
}

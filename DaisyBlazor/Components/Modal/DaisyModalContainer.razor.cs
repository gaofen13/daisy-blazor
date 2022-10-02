using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.ObjectModel;

namespace DaisyBlazor
{
    public partial class DaisyModalContainer
    {
        [Inject] private NavigationManager? NavigationManager { get; set; }
        [Inject] private ModalService ModalService { get; set; } = default!;
        [Parameter] public ModalOptions? GlobalOptions { get; set; }

        private readonly Collection<ModalReference> _modals = new();
        private bool _haveActiveModals;

        internal event Action? OnModalClosed;

        protected override void OnInitialized()
        {
            if (ModalService == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a cascading parameter of type {nameof(DaisyBlazor.ModalService)}.");
            }

            ModalService.OnModalInstanceAdded += Update;
            ModalService.OnModalCloseRequested += CloseInstance;
            NavigationManager!.LocationChanged += CancelModals;
        }

        internal async Task CloseInstance(ModalReference? modal, ModalResult result)
        {
            if (modal?.ModalInstanceRef != null)
            {
                // Gracefully close the modal
                await modal.ModalInstanceRef.CloseAsync(result);
                if (!_modals.Any())
                {
                    ClearBodyStyles();
                }
                OnModalClosed?.Invoke();
            }
            else
            {
                await DismissInstance(modal, result);
            }
        }

        internal Task DismissInstance(Guid id, ModalResult result)
        {
            var reference = GetModalReference(id);
            return DismissInstance(reference, result);
        }

        internal async Task DismissInstance(ModalReference? modal, ModalResult result)
        {
            if (modal != null)
            {
                modal.Dismiss(result);
                _modals.Remove(modal);
                if (!_modals.Any())
                {
                    ClearBodyStyles();
                }
                await InvokeAsync(StateHasChanged);
                OnModalClosed?.Invoke();
            }
        }

        private async void CancelModals(object? sender, LocationChangedEventArgs e)
        {
            foreach (var modalReference in _modals.ToList())
            {
                modalReference.Dismiss(ModalResult.Cancel());
            }

            _modals.Clear();
            ClearBodyStyles();
            await InvokeAsync(StateHasChanged);
        }

        private async Task Update(ModalReference modalReference)
        {
            _modals.Add(modalReference);

            if (!_haveActiveModals)
            {
                _haveActiveModals = true;
            }

            await InvokeAsync(StateHasChanged);
        }

        private ModalReference? GetModalReference(Guid id) => _modals.SingleOrDefault(x => x.InstanceId == id);

        private void ClearBodyStyles()
        {
            _haveActiveModals = false;
        }
    }
}

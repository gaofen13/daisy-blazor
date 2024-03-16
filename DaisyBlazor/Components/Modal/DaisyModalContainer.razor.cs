using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DaisyBlazor
{
    public partial class DaisyModalContainer
    {
        private string Classname =>
            new ClassBuilder("modal")
            .AddClass("modal-open", _currentModal is not null)
            .AddClass($"modal-{GlobalOptions.Position.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        [Inject] 
        private NavigationManager? NavigationManager { get; set; }

        [Inject] 
        private ModalService ModalService { get; set; } = default!;

        [Parameter] 
        public ModalOptions GlobalOptions { get; set; } = new();

        private ModalReference? _currentModal;

        protected override void OnInitialized()
        {
            if (ModalService == null)
            {
                throw new InvalidOperationException($"{GetType()} requires a cascading parameter of type {nameof(DaisyBlazor.ModalService)}.");
            }

            ModalService.OnModalInstanceShow += Show;
            ModalService.OnModalCloseRequested += CloseInstance;
            NavigationManager!.LocationChanged += CancelModal;
        }

        internal void CloseInstance(ModalResult result)
        {
            _currentModal?.Dismiss(result);
            _currentModal = null;
            StateHasChanged();
        }

        private void CancelModal(object? sender, LocationChangedEventArgs e)
        {
            CloseInstance(ModalResult.Cancel());
        }

        internal void Show(ModalReference modalReference)
        {
            _currentModal = modalReference;

            StateHasChanged();
        }
    }
}

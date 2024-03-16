using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public partial class DaisyModal
    {
        private ModalOptions? _options;

        private string Classname =>
          new ClassBuilder("modal-box")
            .AddClass(Class)
            .Build();

        [CascadingParameter]
        private DaisyModalContainer? ModalContainer { get; set; }

        [Parameter]
        public ModalOptions? Options { get; set; }

        [Parameter]
        public EventCallback<bool> ShowChanged { get; set; }

        [Parameter]
        public RenderFragment? ActionContent { get; set; }

        protected override void OnInitialized()
        {
            _options = Options ?? ModalContainer?.GlobalOptions ?? new ModalOptions();

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
            ModalContainer?.CloseInstance(modalResult);
        }

        /// <summary>
        /// Closes the modal and returns a cancelled ModalResult.
        /// </summary>
        public void Cancel() => Close(ModalResult.Cancel());
    }
}

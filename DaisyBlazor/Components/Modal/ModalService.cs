using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public class ModalService
    {
        internal event Func<ModalReference, Task>? OnModalInstanceAdded;
        internal event Func<ModalReference, ModalResult, Task>? OnModalCloseRequested;

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="title">Modal title.</param>
        public ModalReference Show<T>() where T : IComponent
            => Show<T>(new ModalParameters());

        /// <summary>
        /// Shows the modal with the component type using the specified <paramref name="title"/>,
        /// passing the specified <paramref name="parameters"/>.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        public ModalReference Show<T>(ModalParameters parameters) where T : IComponent
            => Show(typeof(T), parameters);

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="title">Modal title.</param>
        public ModalReference Show(Type contentComponent)
            => Show(contentComponent, new ModalParameters());

        /// <summary>
        /// Shows the modal with the component type using the specified <paramref name="title"/>,
        /// passing the specified <paramref name="parameters"/> and setting a custom CSS style.
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="title">Modal title.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        /// <param name="options">Options to configure the modal.</param>
        public ModalReference Show(Type contentComponent, ModalParameters parameters)
        {
            if (!typeof(IComponent).IsAssignableFrom(contentComponent))
            {
                throw new ArgumentException($"{contentComponent.FullName} must be a Blazor Component");
            }

            ModalReference? modalReference = null;
            var modalInstanceId = Guid.NewGuid();
            var modalContent = new RenderFragment(builder =>
            {
                var i = 0;
                builder.OpenComponent(i++, contentComponent);
                foreach (var (name, value) in parameters.Parameters)
                {
                    builder.AddAttribute(i++, name, value);
                }
                builder.CloseComponent();
            });
            var modalInstance = new RenderFragment(builder =>
            {
                builder.OpenComponent<DaisyModal>(0);
                builder.SetKey("ModalInstance_" + modalInstanceId);
                builder.AddAttribute(1, "InstanceId", modalInstanceId);
                builder.AddAttribute(2, "Visible", true);
                builder.AddAttribute(3, "ChildContent", modalContent);
                builder.AddComponentReferenceCapture(4, compRef => modalReference!.ModalInstanceRef = (DaisyModal)compRef);
                builder.CloseComponent();
            });
            modalReference = new ModalReference(modalInstanceId, modalInstance, this);

            OnModalInstanceAdded?.Invoke(modalReference);

            return modalReference;
        }

        internal void Close(ModalReference modal) => Close(modal, ModalResult.Ok());

        internal void Close(ModalReference modal, ModalResult result) => OnModalCloseRequested?.Invoke(modal, result);
    }
}

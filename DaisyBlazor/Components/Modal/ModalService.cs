using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public class ModalService
    {
        internal event Action<ModalReference>? OnModalInstanceShow;
        internal event Action<ModalResult>? OnModalCloseRequested;

        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="title">Modal title.</param>
        public ModalReference Show<T>() where T : IComponent
            => Show<T>([]);

        /// <summary>
        /// Shows the modal with the component type using the specified <paramref name="title"/>,
        /// passing the specified <paramref name="parameters"/>.
        /// </summary>
        /// <param name="title">Modal title.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        public ModalReference Show<T>(ComponentParameters parameters) where T : IComponent
            => Show(typeof(T), parameters);


        /// <summary>
        /// Shows the modal with the component type using the specified title.
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="title">Modal title.</param>
        public ModalReference Show(Type contentComponent)
            => Show(contentComponent, []);

        /// <summary>
        /// Shows the modal with the component type using the specified <paramref name="title"/>,
        /// passing the specified <paramref name="parameters"/> and setting a custom CSS style.
        /// </summary>
        /// <param name="contentComponent">Type of component to display.</param>
        /// <param name="parameters">Key/Value collection of parameters to pass to component being displayed.</param>
        public ModalReference Show(Type contentComponent, ComponentParameters parameters)
        {
            if (!typeof(IComponent).IsAssignableFrom(contentComponent))
            {
                throw new ArgumentException($"{contentComponent.FullName} must be a Blazor Component");
            }

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
            var modalReference = new ModalReference(modalContent, this);

            OnModalInstanceShow?.Invoke(modalReference);

            return modalReference;
        }

        public void Close() => Close(ModalResult.Ok());

        public void Close(ModalResult result) => OnModalCloseRequested?.Invoke(result);
    }
}

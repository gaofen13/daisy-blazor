using Microsoft.AspNetCore.Components;

namespace DaisyBlazor
{
    public class ToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<Type, ComponentParameters?, ToastOptions?>? OnShowComponent;

        /// <summary>
        /// A event that will be invoked when clearing all toasts
        /// </summary>
        public event Action? OnClearAll;

        /// <summary>
        /// Shows a information toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowInfo(string message, string title = "信息", ToastOptions? options = null)
            => ShowToast(Level.Info, message, title, options);

        /// <summary>
        /// Shows a success toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(string message, string title = "成功", ToastOptions? options = null)
            => ShowToast(Level.Success, message, title, options);

        /// <summary>
        /// Shows a warning toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(string message, string title = "警告", ToastOptions? options = null)
            => ShowToast(Level.Warning, message, title, options);

        /// <summary>
        /// Shows a error toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowError(string message, string title = "错误", ToastOptions? options = null)
            => ShowToast(Level.Error, message, title, options);


        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="level">Toast level to display</param>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(Level? level, string? message, string? title = null, ToastOptions? options = null)
            => ShowToast<DaisyToast>(SetParameters(level, message, title), options);

        private static ComponentParameters SetParameters(Level? level, string? message, string? title)
        {
            var res = new ComponentParameters();
            if (level != null)
            {
                res.Add("ToastLevel", level);
            }
            if (!string.IsNullOrWhiteSpace(message))
            {
                res.Add("Message", message);
            }
            if (!string.IsNullOrWhiteSpace(title))
            {
                res.Add("Title", title);
            }
            return res;
        }

        public void ShowToast<TComponent>(ComponentParameters? parameters = null, ToastOptions? options = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), parameters, options);

        public void ShowToast<TComponent>(ComponentParameters? parameters = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), parameters);

        public void ShowToast<TComponent>(ToastOptions? options = null) where TComponent : IComponent
            => ShowToast(typeof(TComponent), null, options);

        public void ShowToast<TComponent>() where TComponent : IComponent
            => ShowToast(typeof(TComponent));

        public void ShowToast(Type toastComponent, ComponentParameters? parameters = null, ToastOptions? options = null)
        {
            if (!typeof(IComponent).IsAssignableFrom(toastComponent))
            {
                throw new ArgumentException($"{toastComponent.FullName} must be a Blazor Component");
            }
            OnShowComponent?.Invoke(toastComponent, parameters, options);
        }

        /// <summary>
        /// Removes all toasts
        /// </summary>
        public void ClearAll() => OnClearAll?.Invoke();
    }
}

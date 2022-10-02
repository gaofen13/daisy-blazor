using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaisyBlazor
{
    public class ToastService
    {
        /// <summary>
        /// A event that will be invoked when showing a toast
        /// </summary>
        public event Action<Level, RenderFragment, string?, ToastOptions?>? OnShow;

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
        public void ShowInfo(string message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Info, message, title, options);

        /// <summary>
        /// Shows a information toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowInfo(RenderFragment message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Info, message, title, options);

        /// <summary>
        /// Shows a success toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(string message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Success, message, title, options);

        /// <summary>
        /// Shows a success toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowSuccess(RenderFragment message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Success, message, title, options);

        /// <summary>
        /// Shows a warning toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(string message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Warning, message, title, options);

        /// <summary>
        /// Shows a warning toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowWarning(RenderFragment message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Warning, message, title, options);

        /// <summary>
        /// Shows a error toast 
        /// </summary>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowError(string message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Error, message, title, options);

        /// <summary>
        /// Shows a error toast 
        /// </summary>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowError(RenderFragment message, string? title = null, ToastOptions? options = null)
            => ShowToast(Level.Error, message, title, options);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="level">Toast level to display</param>
        /// <param name="message">Text to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(Level level, string message, string? title = null, ToastOptions? options = null)
            => ShowToast(level, builder => builder.AddContent(0, message), title, options);

        /// <summary>
        /// Shows a toast using the supplied settings
        /// </summary>
        /// <param name="level">Toast level to display</param>
        /// <param name="message">RenderFragment to display on the toast</param>
        /// <param name="heading">The text to display as the toasts heading</param>
        /// <param name="onClick">Action to be executed on click</param>
        public void ShowToast(Level level, RenderFragment message, string? title = null, ToastOptions? options = null)
            => OnShow?.Invoke(level, message, title, options);

        /// <summary>
        /// Removes all toasts
        /// </summary>
        public void ClearAll() => OnClearAll?.Invoke();
    }
}

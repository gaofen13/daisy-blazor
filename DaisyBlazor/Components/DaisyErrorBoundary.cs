using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace DaisyBlazor
{
    public class DaisyErrorBoundary : ErrorBoundaryBase
    {
        protected Exception? Exception { get; set; }

        [Inject]
        [NotNull]
        private ToastService? ToastService { get; set; }

        [Inject]
        [NotNull]
        private ILogger<DaisyErrorBoundary>? Logger { get; set; }

        [Inject]
        [NotNull]
        private IErrorBoundaryLogger? ErrorBoundaryLogger { get; set; }

        [Parameter]
        public Func<ILogger, Exception, Task>? OnErrorHandleAsync { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            builder.OpenComponent<CascadingValue<DaisyErrorBoundary>>(0);
            builder.AddAttribute(1, nameof(CascadingValue<DaisyErrorBoundary>.Value), this);
            builder.AddAttribute(2, nameof(CascadingValue<DaisyErrorBoundary>.IsFixed), true);

            var content = ChildContent;

            var ex = Exception ?? CurrentException;

            if (ex != null && ErrorContent != null)
            {
                content = ErrorContent.Invoke(ex);
            }
            builder.AddAttribute(3, nameof(CascadingValue<DaisyErrorBoundary>.ChildContent), content);
            builder.CloseComponent();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            Exception = null;

            Recover();
        }

        protected override async Task OnErrorAsync(Exception exception)
        {
            // 由框架调用
            if (OnErrorHandleAsync != null)
            {
                await OnErrorHandleAsync(Logger, exception);
            }
            else
            {
                ToastService.ShowError(exception.Message, "ComponentError");

                // 此处注意 内部 logLevel=Warning
                await ErrorBoundaryLogger.LogErrorAsync(exception);
            }
        }

        public async Task HandlerExceptionAsync(Exception exception)
        {
            await OnErrorAsync(exception);

            if (OnErrorHandleAsync is null)
            {
                Exception = exception;
                StateHasChanged();
            }
        }
    }
}

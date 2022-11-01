using DaisyBlazor.Components.Toast;
using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DaisyBlazor
{
    public partial class DaisyToastContainer
    {
        private string ContainerClass =>
          new ClassBuilder("toast")
            .AddClass($"toast-{PositionX.ToString().ToLower()}")
            .AddClass($"toast-{PositionY.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        private string ContainerStyle =>
            new StyleBuilder("min-width", "300px")
            .AddStyle(Style)
            .Build();

        [Inject]
        private ToastService ToastService { get; set; } = default!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = default!;

        [Parameter]
        public bool RemoveToastsOnNavigation { get; set; }

        [Parameter]
        public int MaxItemsShown { get; set; } = 10;

        [Parameter]
        public PositionX PositionX { get; set; }

        [Parameter]
        public PositionY PositionY { get; set; }

        [Parameter]
        public ToastOptions GlobalOptions { get; set; } = new();

        private List<ToastInstance> ToastList { get; set; } = new();

        private Queue<ToastInstance> ToastWaitingQueue { get; set; } = new();

        protected override void OnInitialized()
        {
            ToastService.OnShow += ShowToast;
            ToastService.OnShowComponent += ShowToast;
            ToastService.OnClearAll += ClearAll;

            if (RemoveToastsOnNavigation)
            {
                NavigationManager.LocationChanged += ClearToasts;
            }
        }

        public void RemoveToast(Guid toastId)
        {
            InvokeAsync(() =>
            {
                var toastInstance = ToastList.SingleOrDefault(x => x.Id == toastId);

                if (toastInstance is not null)
                {
                    ToastList.Remove(toastInstance);
                    StateHasChanged();
                }

                if (ToastWaitingQueue.Any())
                {
                    ShowEnqueuedToast();
                }
            });
        }

        private void ClearToasts(object? sender, LocationChangedEventArgs args)
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();

                if (ToastWaitingQueue.Any())
                {
                    ShowEnqueuedToast();
                }
            });
        }

        private void ShowToast(Level level, RenderFragment message, string? title, ToastOptions? options)
        {
            InvokeAsync(() =>
            {
                var toast = new ToastInstance(options ?? GlobalOptions) { ToastLevel = level, MessageContent = message, Title = title };

                if (ToastList.Count < MaxItemsShown)
                {
                    ToastList.Add(toast);
                    StateHasChanged();
                }
                else
                {
                    ToastWaitingQueue.Enqueue(toast);
                }
            });

        }

        private void ShowToast(Type contentComponent, Level level, ToastParameters? parameters, ToastOptions? options)
        {
            InvokeAsync(() =>
            {
                var childContent = new RenderFragment(builder =>
                {
                    var i = 0;
                    builder.OpenComponent(i++, contentComponent);
                    if (parameters is not null)
                    {
                        foreach (var parameter in parameters.Parameters)
                        {
                            builder.AddAttribute(i++, parameter.Key, parameter.Value);
                        }
                    }
                    builder.CloseComponent();
                });

                var toast = new ToastInstance(childContent, options ?? GlobalOptions) { ToastLevel = level };

                if (ToastList.Count < MaxItemsShown)
                {
                    ToastList.Add(toast);
                    StateHasChanged();
                }
                else
                {
                    ToastWaitingQueue.Enqueue(toast);
                }
            });
        }

        private void ShowEnqueuedToast()
        {
            InvokeAsync(() =>
            {
                var toast = ToastWaitingQueue.Dequeue();

                ToastList.Add(toast);

                StateHasChanged();
            });
        }

        private void ClearAll()
        {
            InvokeAsync(() =>
            {
                ToastList.Clear();
                StateHasChanged();
            });
        }
    }
}

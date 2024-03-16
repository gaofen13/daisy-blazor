using DaisyBlazor.Utilities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace DaisyBlazor
{
    public partial class DaisyToastContainer
    {
        private string Classname =>
          new ClassBuilder("toast max-w-full w-96")
            .AddClass($"toast-{PositionX.ToString().ToLower()}")
            .AddClass($"toast-{PositionY.ToString().ToLower()}")
            .AddClass(Class)
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

        private List<ToastReference> ToastList { get; set; } = [];

        private Queue<ToastReference> ToastWaitingQueue { get; set; } = new();

        protected override void OnInitialized()
        {
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

                if (ToastWaitingQueue.Count > 0)
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

                if (ToastWaitingQueue.Count > 0)
                {
                    ShowEnqueuedToast();
                }
            });
        }
        private void ShowToast(Type contentComponent, ComponentParameters? parameters, ToastOptions? options)
        {
            InvokeAsync(() =>
            {
                var toastContent = new RenderFragment(builder =>
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

                var toastReference = new ToastReference(toastContent, options);

                if (ToastList.Count < MaxItemsShown)
                {
                    ToastList.Add(toastReference);
                    StateHasChanged();
                }
                else
                {
                    ToastWaitingQueue.Enqueue(toastReference);
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

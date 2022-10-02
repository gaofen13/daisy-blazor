using DaisyBlazor.Components.Toast;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using DaisyBlazor.Utilities;

namespace DaisyBlazor
{
    public partial class DaisyToastContainer
    {
        private string Classname =>
          new ClassBuilder("toast")
            .AddClass($"toast-{PositionX.ToString().ToLower()}")
            .AddClass($"toast-{PositionY.ToString().ToLower()}")
            .AddClass(Class)
            .Build();

        private string StyleAttribute =>
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

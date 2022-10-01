using Microsoft.Extensions.DependencyInjection;

namespace DaisyBlazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDaisyBlazor(this IServiceCollection services)
        {
            return services.AddDaisyModal()
                .AddDaisyToast();
        }

        public static IServiceCollection AddDaisyModal(this IServiceCollection services) => services.AddScoped<ModalService>();

        public static IServiceCollection AddDaisyToast(this IServiceCollection services) => services.AddScoped<ToastService>();
    }
}

using Microsoft.Extensions.DependencyInjection;

namespace CalmanFiltering.ViewModels
{
    internal static class ViewModelsRegistration
    {
        public static IServiceCollection AddViewModels(this IServiceCollection Services)
        {
            Services.AddSingleton<MainWindowViewModel>();
            Services.AddTransient<Moving1DViewModel>();

            return Services;
        }
    }
}

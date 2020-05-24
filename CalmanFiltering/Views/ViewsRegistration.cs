using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CalmanFiltering.Views
{
    internal static class ViewsRegistration
    {
        public static IServiceCollection AddViews(this IServiceCollection Services)
        {
            Services.AddSingleton((MainWindow)Application.Current.MainWindow);
            return Services;
        }
    }
}

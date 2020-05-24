using Microsoft.Extensions.DependencyInjection;

namespace CalmanFiltering.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}

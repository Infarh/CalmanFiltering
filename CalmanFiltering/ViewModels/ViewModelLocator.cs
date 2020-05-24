using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace CalmanFiltering.ViewModels
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}

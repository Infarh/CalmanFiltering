using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using CalmanFiltering.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CalmanFiltering
{
    public partial class App
    {
        public static bool IsDesignTime { get; private set; } = true;

        private static IHost __Host;
        public static IHost Host => __Host ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override void OnStartup(StartupEventArgs e)
        {
            IsDesignTime = false;

            base.OnStartup(e);

        }

        public static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton((MainWindow) Current.MainWindow);
            services.AddSingleton<MainWindowViewModel>();
        }

        public static string CurrentDirectory => IsDesignTime ? Path.GetDirectoryName(GetSourceCodePath()) : Environment.CurrentDirectory;

        public static string GetSourceCodePath([CallerFilePath] string path = null) => path;
    }
}

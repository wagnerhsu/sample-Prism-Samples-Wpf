using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Unity;
using Serilog;
using System.Windows;
using ViewModelLocator.Views;

namespace ViewModelLocator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterServices(AddServiceCollection);
        }

        private void AddServiceCollection(IServiceCollection services)
        {
            var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                 .WriteTo.Async(c => c.File("Logs/SunHealth.Tools.DeviceManager.log", rollingInterval: RollingInterval.Day,
                     rollOnFileSizeLimit: true))
                 .CreateLogger();
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            services.AddSingleton(typeof(IConfiguration), configuration);
            services.AddLogging(c =>
            {
                c.AddSerilog(log);
            });
        }
    }
}

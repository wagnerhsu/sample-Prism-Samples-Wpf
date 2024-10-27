using ActivationDeactivation.Views;
using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Unity;
using Serilog;
using System.Windows;

namespace ActivationDeactivation
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
                 .WriteTo.Async(c => c.File("Logs/ActivationDeactivation.log", rollingInterval: RollingInterval.Day,
                     rollOnFileSizeLimit: true))
                 .CreateLogger();
            services.AddLogging(c =>
            {
                c.AddSerilog(log);
            });
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Unity;
using Serilog;
using System.Windows;
using WpfPrism02.Views;
using WpfPrismCommon;

namespace WpfPrism02
{
    class Bootstrapper : PrismBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ICustomerStore, DbCustomerStore>();
            containerRegistry.RegisterServices(AddServiceCollection);
        }

        private void AddServiceCollection(IServiceCollection services)
        {
            var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                 .WriteTo.Async(c => c.File("Logs/WpfPrism02.log", rollingInterval: RollingInterval.Day,
                     rollOnFileSizeLimit: true))
                 .CreateLogger();
            services.AddLogging(c =>
            {
                c.AddSerilog(log);
            });
        }
    }
}

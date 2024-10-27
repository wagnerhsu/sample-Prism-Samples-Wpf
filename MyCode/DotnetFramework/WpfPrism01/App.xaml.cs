using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Unity;
using Serilog;
using System.Windows;
using Unity;
using WpfPrism01.Views;
using WpfPrismCommon;

namespace WpfPrism01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
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
                 .WriteTo.Async(c => c.File("Logs/WpfPrism01.log", rollingInterval: RollingInterval.Day,
                     rollOnFileSizeLimit: true))
                 .CreateLogger();
            services.AddLogging(c =>
            {
                c.AddSerilog(log);
            });
        }
    }
}

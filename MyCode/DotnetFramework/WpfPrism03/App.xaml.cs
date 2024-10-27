using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace WpfPrism03
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
            services.AddLogging(c =>
            {
                c.ClearProviders();
                c.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                c.AddNLog();
            });
        }
    }
}

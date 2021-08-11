using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using Unity;

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
        }
    }
}

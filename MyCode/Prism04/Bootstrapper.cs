using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Prism04
{
   public class Bootstrapper: UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            MainWindow shell = Container.TryResolve<MainWindow>();
            shell.Show();
            return shell;
        }
    }
}

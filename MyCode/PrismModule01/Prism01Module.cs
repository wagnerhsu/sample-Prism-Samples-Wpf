using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismModule01.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismModule01
{
    public class Prism01Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
    }
}

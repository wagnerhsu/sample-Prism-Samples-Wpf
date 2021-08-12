﻿using Microsoft.Extensions.Logging;
using Prism.Ioc;
using Prism.Regions;
using System.Windows;
using Unity;

namespace ActivationDeactivation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> _logger;
        private IContainerExtension _container;
        private IRegionManager _regionManager;
        private IRegion _region;

        private ViewA _viewA;
        private ViewB _viewB;

        public MainWindow(ILogger<MainWindow> logger,
            IContainerExtension container,
            IRegionManager regionManager)
        {
            InitializeComponent();
            _logger = logger;
            _container = container;
            _regionManager = regionManager;

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewA = _container.Resolve<ViewA>();
            _viewB = _container.Resolve<ViewB>();

            _region = _regionManager.Regions["ContentRegion"];

            _region.Add(_viewA);
            _region.Add(_viewB);
        }

        private void ActivevateViewA_Click(object sender, RoutedEventArgs e)
        {
            //activate view a
            _region.Activate(_viewA);
        }

        private void DeactivateViewA_Click(object sender, RoutedEventArgs e)
        {
            //deactivate view a
            _region.Deactivate(_viewA);
        }

        private void ActivateViewB_Click(object sender, RoutedEventArgs e)
        {
            //activate view b
            _region.Activate(_viewB);
        }

        private void DeactivateViewB_Click(object sender, RoutedEventArgs e)
        {
            //deactivate view b
            _region.Deactivate(_viewB);
        }

        private void RegionTest_Click(object sender, RoutedEventArgs e)
        {
            IViewsCollection activeViews = _region.ActiveViews;
            int i = 0;
            foreach (var view in activeViews)
            {
                _logger.LogInformation(i++.ToString() + ":" + view.ToString());
            }
        }
    }
}
﻿using NLog;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prism01.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IRegionManager regionManager,ILoggerFacade logger)
        {
            InitializeComponent();
            ((CustomLogger)logger).CreateLogger(LogManager.GetCurrentClassLogger());
            logger.Log("Test", Category.Info, Priority.None);
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewA));
            regionManager.RegisterViewWithRegion("TestRegion", typeof(ViewB));
        }
    }
}

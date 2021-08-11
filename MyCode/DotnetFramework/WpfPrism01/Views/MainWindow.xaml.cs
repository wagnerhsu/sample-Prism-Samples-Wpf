﻿using Microsoft.Extensions.Logging;
using System.Windows;

namespace WpfPrism01.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger<MainWindow> _logger;

        public MainWindow(ILogger<MainWindow> logger)
        {
            InitializeComponent();
            _logger = logger;
            _logger.LogInformation("MainWindow.ctor");
        }
    }
}

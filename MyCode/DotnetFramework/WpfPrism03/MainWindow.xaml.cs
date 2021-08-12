using Microsoft.Extensions.Logging;
using System.Windows;

namespace WpfPrism03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ILogger<MainWindow> logger)
        {
            InitializeComponent();
        }
    }
}

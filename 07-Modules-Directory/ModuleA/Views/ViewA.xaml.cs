using ModuleA.ViewModels;
using System.Windows.Controls;

namespace ModuleA.Views
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class ViewA : UserControl
    {
        public ViewA(ViewAViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}

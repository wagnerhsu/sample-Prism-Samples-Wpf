using Prism.Mvvm;

namespace ModuleA.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private string _title = "Prism Unity Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public ViewAViewModel()
        {

        }
    }
}

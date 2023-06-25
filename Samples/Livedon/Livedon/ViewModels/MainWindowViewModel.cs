using Livet;

namespace Livedon.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private string _Mesasge;
        public string Message
        {
            get { return _Mesasge; }
            set { RaisePropertyChangedIfSet(ref _Mesasge, value); }
        }
    }
}

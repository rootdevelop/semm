using MvvmCross.Core.ViewModels;

namespace KeepOnDroning.Core.ViewModels
{
    public class PreFlightCheckViewModel 
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";
        public string Hello
        { 
            get { return _hello; }
            set { SetProperty (ref _hello, value); }
        }
    }
}
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using UIKit;
using KeepOnDroning.Core.ViewModels.ViewModels;

namespace KeepOnDroning.iOS
{
    public partial class PreFlightCheckView : MvxViewController
    {
        public PreFlightCheckView()
            : base("PreFlightCheckView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationController.NavigationBarHidden = true;

            var set = this.CreateBindingSet<PreFlightCheckView, PreFlightCheckViewModel>();
            set.Bind(btnCustom).To(ViewModel => ViewModel.GoToCustomLocationCommand);
            set.Bind(btnGame).To(ViewModel => ViewModel.GoToGameCommand);
            set.Bind(btnInfo).To(ViewModel => ViewModel.InformationCommand);
            set.Bind(btnMap).To(ViewModel => ViewModel.GoToInteractiveMapCommand);
            set.Bind(btnStart).To(ViewModel => ViewModel.PreFlightCheckCommand);




            set.Apply();
        }

        public override bool PrefersStatusBarHidden()
        {
            return true;
        }
    }
}
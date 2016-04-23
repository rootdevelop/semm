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

			set.Bind (lblNoFlyZone).To (ViewModel => ViewModel.NoFlyText);
			set.Bind (lblBirds).To (ViewModel => ViewModel.BirdsText);
			set.Bind (lblPlains).To (ViewModel => ViewModel.PlanesText);
			set.Bind (lblWeather).To (ViewModel => ViewModel.WeatherText);

			// Bool to image converter
			//set.Bind (imgCheckNoFly).To (ViewModel => ViewModel.NoFlyIsOkay);
			//set.Bind (imgCheckBirds).To (ViewModel => ViewModel.BirdsIsOkay);
			//set.Bind (imgCheckPlains).To (ViewModel => ViewModel.PlanesIsOkay);
			//set.Bind (imgCheckWeather).To (ViewModel => ViewModel.WeatherIsOkay);
			set.Apply();
		}


        public override bool PrefersStatusBarHidden()
        {
            return true;
        }
    }
}
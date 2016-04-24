using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using UIKit;
using KeepOnDroning.Core.ViewModels;

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
            set.Bind(viewResults).For(x => x.Hidden).To(vm => vm.WaitingForStart);
            set.Bind(btnStart).For(x => x.Hidden).To(vm => vm.IsLoading);
            set.Bind(lblWindHeading).To(vm => vm.WindHeadingText);
            set.Bind(lblWindSpeed).To(vm => vm.WindSpeedText);


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
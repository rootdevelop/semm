using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using UIKit;
using KeepOnDroning.Core.ViewModels;
using System.Xml;

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
            set.Bind(btnReset).To(vm => vm.ResetCommand);
            set.Bind(btnCustom).To(ViewModel => ViewModel.GoToCustomLocationCommand);
            set.Bind(btnGame).To(ViewModel => ViewModel.GoToGameCommand);
            set.Bind(btnInfo).To(ViewModel => ViewModel.InformationCommand);
            set.Bind(btnMap).To(ViewModel => ViewModel.GoToInteractiveMapCommand);
            set.Bind(btnStart).To(ViewModel => ViewModel.PreFlightCheckCommand);
            set.Bind(viewResults).For(x => x.Hidden).To(vm => vm.WaitingForStart);
            set.Bind(btnStart).For(x => x.Hidden).To(vm => vm.IsLoading);
            set.Bind(lblWindHeading).To(vm => vm.WindHeadingText);
            set.Bind(lblWindSpeed).To(vm => vm.WindSpeedText);

            set.Bind(imgCheckNoFly).To(ViewModel => ViewModel.NoFlyIsOkay).WithConversion("BooleanToImage", "nofly");
            set.Bind(imgCheckBirds).To(ViewModel => ViewModel.BirdsIsOkay).WithConversion("BooleanToImage", "birds");
            set.Bind(imgCheckPlains).To(ViewModel => ViewModel.PlanesIsOkay).WithConversion("BooleanToImage", "planes");
            set.Bind(imgCheckWeather).To(ViewModel => ViewModel.WeatherIsOkay).WithConversion("BooleanToImage", "weather");

            set.Apply();
        }


        public override bool PrefersStatusBarHidden()
        {
            return true;
        }
    }
}
using MvvmCross.Platform.IoC;
using KeepOnDroning.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;
using System.Diagnostics;


namespace KeepOnDroning.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

		

            RegisterAppStart<PreFlightCheckViewModel>();
        }
    }
}

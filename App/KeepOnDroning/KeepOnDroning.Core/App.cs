using MvvmCross.Platform.IoC;
using KeepOnDroning.Core.ViewModels.ViewModels;

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

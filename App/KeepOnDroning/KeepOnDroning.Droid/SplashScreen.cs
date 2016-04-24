using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace KeepOnDroning.Droid
{
    [Activity(
        Label = "Keep On Droning"
        , MainLauncher = true
        , Icon = "@mipmap/icon"
        , Theme = "@style/Theme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

		protected override void OnCreate(Android.OS.Bundle bundle)
		{
			base.OnCreate(bundle);
		}
    }
}
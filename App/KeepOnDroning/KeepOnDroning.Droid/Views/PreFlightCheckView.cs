using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Android.Views;
using Android.Content.PM;

namespace KeepOnDroning.Droid.Views
{
	[Activity(
		Label = "View for PreFlightCheckViewModel",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait)]
    public class PreFlightCheckView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.PreFlightCheckView);
        }
    }
}

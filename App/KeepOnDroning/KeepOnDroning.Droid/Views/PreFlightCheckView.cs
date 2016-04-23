using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Android.Views;

namespace KeepOnDroning.Droid.Views
{
	[Activity(
		Label = "View for PreFlightCheckViewModel",
		Theme = "@style/Theme.Main")]
    public class PreFlightCheckView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.PreFlightCheckView);
        }
    }
}

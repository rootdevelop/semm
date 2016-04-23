using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.BindingContext;
using Android.Views;
using Android.Content.PM;

namespace KeepOnDroning.Droid.Views
{
	[Activity(Label = "View for InteractiveMapViewModel",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class InteractiveMapView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.InteractiveMapView);
        }
    }
}

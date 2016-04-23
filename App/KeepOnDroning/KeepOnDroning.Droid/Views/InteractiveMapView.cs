using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.BindingContext;
using Android.Views;

namespace KeepOnDroning.Droid.Views
{
	[Activity(Label = "View for InteractiveMapView")]
	public class InteractiveMapView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
			RequestWindowFeature(WindowFeatures.NoTitle);
			Window.AddFlags(WindowManagerFlags.Fullscreen);

            base.OnCreate(bundle);
			SetContentView(Resource.Layout.InteractiveMapView);
        }
    }
}

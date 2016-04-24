using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.BindingContext;
using Android.Views;
using Android.Content.PM;
using Android.Webkit;

namespace KeepOnDroning.Droid.Views
{
	[Activity(Label = "View for CustomLocationViewModel",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class CustomLocationView : MvxActivity
    {
		WebView webview;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.CustomLocationView);

			webview = FindViewById<WebView> (Resource.Id.webview);
			webview.SetWebViewClient (new CustomWebViewClient ());
			webview.Settings.JavaScriptEnabled = true;
			webview.LoadUrl ("http://maps.google.nl");
        }
    }
}

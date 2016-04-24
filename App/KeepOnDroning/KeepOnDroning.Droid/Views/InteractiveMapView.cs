using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.BindingContext;
using Android.Views;
using Android.Content.PM;
using Android.Webkit;

namespace KeepOnDroning.Droid.Views
{
	[Activity(Label = "View for InteractiveMapViewModel",
		Theme = "@style/Theme.Main",
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class InteractiveMapView : MvxActivity
    {
		WebView webview;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.InteractiveMapView);

			webview = FindViewById<WebView> (Resource.Id.webview);
			webview.SetWebViewClient (new CustomWebViewClient ());
			webview.Settings.JavaScriptEnabled = true;
			webview.LoadUrl ("http://maps.google.nl");
        }
    }

	public class CustomWebViewClient : WebViewClient
	{
		public override bool ShouldOverrideUrlLoading (WebView view, string url)
		{
			view.LoadUrl (url);
			return true;
		}
	}
}

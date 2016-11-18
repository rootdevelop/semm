using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using MvvmCross.Binding.BindingContext;
using Android.Views;
using Android.Content.PM;
using Android.Webkit;
using KeepOnDroning.Core.ViewModels;

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

			string url ="https://keepondroningnew.azurewebsites.net/Map/Index/lat=52.142244&lng=4.418725";

			webview = FindViewById<WebView> (Resource.Id.webview);
			webview.SetWebViewClient (new CustomWebViewClient ());
			webview.Settings.JavaScriptEnabled = true;
			webview.LoadUrl(url);
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

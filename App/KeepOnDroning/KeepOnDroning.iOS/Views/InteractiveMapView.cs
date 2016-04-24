using System;

using UIKit;
using MvvmCross.iOS.Views;
using Foundation;
using KeepOnDroning.Core.ViewModels;

namespace KeepOnDroning.iOS
{
    public partial class InteractiveMapView : MvxViewController
    {
        public InteractiveMapView()
            : base("InteractiveMapView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            NavigationController.NavigationBarHidden = true;

            BtnBack.TouchUpInside += (sender, e) => NavigationController.PopViewController(true);

			string url = "https://keepondroningnew.azurewebsites.net/Map/Index/lat=52.142244&lng=4.418725";

			WebView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
			WebView.ScalesPageToFit = false;
        }

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}
    }
}
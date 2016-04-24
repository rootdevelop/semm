using System;

using UIKit;
using MvvmCross.iOS.Views;
using Foundation;

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

			var url = "https://maps.google.com";
			WebView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
			WebView.ScalesPageToFit = false;
        }

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}
    }
}
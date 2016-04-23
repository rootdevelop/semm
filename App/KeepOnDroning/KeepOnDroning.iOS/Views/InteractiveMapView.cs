using System;

using UIKit;
using MvvmCross.iOS.Views;

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
        }

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}
    }
}



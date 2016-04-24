using MvvmCross.iOS.Views;

namespace KeepOnDroning.iOS
{
	public partial class InfoView : MvxViewController
	{
		public InfoView () : base ("InfoView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.
			btnBack.TouchUpInside += (sender, e) => NavigationController.PopViewController(true);
		}

		public override bool PrefersStatusBarHidden()
		{
			return true;
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}



using System;

using UIKit;
using CrashDrone.Common;

namespace CrashDrone.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController () : base ("ViewController", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			if (GameView != null)
			{
				// Set loading event to be called once game view is fully initialised
				GameView.ViewCreated += GameDelegate.LoadGame;
			}
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			if (GameView != null)
				GameView.Paused = true;
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

			if (GameView != null)
				GameView.Paused = false;
		}
	}
}



// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace KeepOnDroning.iOS
{
	[Register ("GameView")]
	partial class GameView
	{
		[Outlet]
		UIKit.UIButton BackButton { get; set; }

		[Outlet]
		UIKit.UIImageView BackImage { get; set; }

		[Outlet]
		CocosSharp.CCGameView GameUIView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BackButton != null) {
				BackButton.Dispose ();
				BackButton = null;
			}
			if (BackImage != null) {
				BackImage.Dispose ();
				BackImage = null;
			}
			if (GameUIView != null) {
				GameUIView.Dispose ();
				GameUIView = null;
			}
		}
	}
}

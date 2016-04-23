// WARNING
//
// This file has been generated automatically by Xamarin Studio Community to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

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
			if (GameUIView != null) {
				GameUIView.Dispose ();
				GameUIView = null;
			}

			if (BackImage != null) {
				BackImage.Dispose ();
				BackImage = null;
			}

			if (BackButton != null) {
				BackButton.Dispose ();
				BackButton = null;
			}
		}
	}
}

// WARNING
//
// This file has been generated automatically by Xamarin Studio Community to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SpaceGame.iOS
{
	[Register ("InitialViewController")]
	partial class InitialViewController
	{
		[Outlet]
		CocosSharp.CCGameView GameView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (GameView != null) {
				GameView.Dispose ();
				GameView = null;
			}
		}
	}
}

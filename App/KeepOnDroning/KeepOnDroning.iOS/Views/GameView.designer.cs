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
		CocosSharp.CCGameView GameUIView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (GameUIView != null) {
				GameUIView.Dispose ();
				GameUIView = null;
			}
		}
	}
}

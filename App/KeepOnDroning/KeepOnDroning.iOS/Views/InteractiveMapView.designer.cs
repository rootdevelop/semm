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
	[Register ("InteractiveMapView")]
	partial class InteractiveMapView
	{
		[Outlet]
		UIKit.UIButton BtnBack { get; set; }

		[Outlet]
		UIKit.UIWebView WebView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (BtnBack != null) {
				BtnBack.Dispose ();
				BtnBack = null;
			}

			if (WebView != null) {
				WebView.Dispose ();
				WebView = null;
			}
		}
	}
}

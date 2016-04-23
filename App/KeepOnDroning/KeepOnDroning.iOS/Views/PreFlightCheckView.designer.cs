// WARNING
//
// This file has been generated automatically by Xamarin Studio Business to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace KeepOnDroning.iOS
{
	[Register ("PreFlightCheckView")]
	partial class PreFlightCheckView
	{
		[Outlet]
		UIKit.UIButton btnCustom { get; set; }

		[Outlet]
		UIKit.UIButton btnGame { get; set; }

		[Outlet]
		UIKit.UIButton btnInfo { get; set; }

		[Outlet]
		UIKit.UIButton btnMap { get; set; }

		[Outlet]
		UIKit.UIButton btnStart { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnStart != null) {
				btnStart.Dispose ();
				btnStart = null;
			}

			if (btnMap != null) {
				btnMap.Dispose ();
				btnMap = null;
			}

			if (btnInfo != null) {
				btnInfo.Dispose ();
				btnInfo = null;
			}

			if (btnGame != null) {
				btnGame.Dispose ();
				btnGame = null;
			}

			if (btnCustom != null) {
				btnCustom.Dispose ();
				btnCustom = null;
			}
		}
	}
}

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

		[Outlet]
		UIKit.UIImageView imgCheckBirds { get; set; }

		[Outlet]
		UIKit.UIImageView imgCheckNoFly { get; set; }

		[Outlet]
		UIKit.UIImageView imgCheckPlains { get; set; }

		[Outlet]
		UIKit.UIImageView imgCheckWeather { get; set; }

		[Outlet]
		UIKit.UILabel lblBirds { get; set; }

		[Outlet]
		UIKit.UILabel lblNoFlyZone { get; set; }

		[Outlet]
		UIKit.UILabel lblPlains { get; set; }

		[Outlet]
		UIKit.UILabel lblWeather { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnCustom != null) {
				btnCustom.Dispose ();
				btnCustom = null;
			}

			if (btnGame != null) {
				btnGame.Dispose ();
				btnGame = null;
			}

			if (btnInfo != null) {
				btnInfo.Dispose ();
				btnInfo = null;
			}

			if (btnMap != null) {
				btnMap.Dispose ();
				btnMap = null;
			}

			if (btnStart != null) {
				btnStart.Dispose ();
				btnStart = null;
			}

			if (lblNoFlyZone != null) {
				lblNoFlyZone.Dispose ();
				lblNoFlyZone = null;
			}

			if (lblBirds != null) {
				lblBirds.Dispose ();
				lblBirds = null;
			}

			if (lblPlains != null) {
				lblPlains.Dispose ();
				lblPlains = null;
			}

			if (lblWeather != null) {
				lblWeather.Dispose ();
				lblWeather = null;
			}

			if (imgCheckNoFly != null) {
				imgCheckNoFly.Dispose ();
				imgCheckNoFly = null;
			}

			if (imgCheckBirds != null) {
				imgCheckBirds.Dispose ();
				imgCheckBirds = null;
			}

			if (imgCheckPlains != null) {
				imgCheckPlains.Dispose ();
				imgCheckPlains = null;
			}

			if (imgCheckWeather != null) {
				imgCheckWeather.Dispose ();
				imgCheckWeather = null;
			}
		}
	}
}

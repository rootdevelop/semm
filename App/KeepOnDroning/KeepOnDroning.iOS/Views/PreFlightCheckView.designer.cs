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
		UIKit.UILabel lblWindHeading { get; set; }

		[Outlet]
		UIKit.UILabel lblWindSpeed { get; set; }

		[Outlet]
		UIKit.UIView viewResults { get; set; }

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
			if (imgCheckBirds != null) {
				imgCheckBirds.Dispose ();
				imgCheckBirds = null;
			}
			if (imgCheckNoFly != null) {
				imgCheckNoFly.Dispose ();
				imgCheckNoFly = null;
			}
			if (imgCheckPlains != null) {
				imgCheckPlains.Dispose ();
				imgCheckPlains = null;
			}
			if (imgCheckWeather != null) {
				imgCheckWeather.Dispose ();
				imgCheckWeather = null;
			}
			if (lblWindHeading != null) {
				lblWindHeading.Dispose ();
				lblWindHeading = null;
			}
			if (lblWindSpeed != null) {
				lblWindSpeed.Dispose ();
				lblWindSpeed = null;
			}
			if (viewResults != null) {
				viewResults.Dispose ();
				viewResults = null;
			}
		}
	}
}

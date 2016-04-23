using System;
using KeepOnDroning.Core;
using MvvmCross.Platform.Converters;

namespace KeepOnDroning.Droid
{
	public class EPreFlightStatusToImageConverter : MvxValueConverter<EPreFlightStatus, int>
	{
		protected override int Convert (EPreFlightStatus value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int result = Resource.Drawable.RedButton;

			switch(value)
			{
			case EPreFlightStatus.Green:
				result = Resource.Drawable.GreenButton;
				break;
			case EPreFlightStatus.Orange:
				result = Resource.Drawable.OrangeButton;
				break;
			case EPreFlightStatus.Red:
				result = Resource.Drawable.RedButton;
				break;
			}

			return result;
		}
	}
}
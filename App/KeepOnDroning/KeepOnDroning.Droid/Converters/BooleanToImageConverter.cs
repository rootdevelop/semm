using System;
using MvvmCross.Platform.Converters;

namespace KeepOnDroning.Droid
{
	public class BooleanToImageConverter: MvxValueConverter<bool, int>
	{
		protected override int Convert (bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int result = Resource.Drawable.RedButton;

			if (value)
				result = Resource.Drawable.OK;
			else
				result = Resource.Drawable.ComputerSaysNo;

			return result;
		} 
	}
}
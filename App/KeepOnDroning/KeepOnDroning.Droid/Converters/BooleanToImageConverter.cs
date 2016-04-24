using System;
using MvvmCross.Platform.Converters;

namespace KeepOnDroning.Droid
{
	public class BooleanToImageConverter: MvxValueConverter<bool, int>
	{
		protected override int Convert (bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			int result = Resource.Drawable.ComputerSaysNo;
			string kind = parameter.ToString ();

			switch(kind)
			{
			case "nofly":
				if (value)
					result = Resource.Drawable.IMG_noflyzones_positive;
				else
					result = Resource.Drawable.IMG_noflyzones_negative;
				break;
			case "birds":
				if (value)
					result = Resource.Drawable.IMG_birds_positive;
				else
					result = Resource.Drawable.IMG_birds_negative;
				break;
			case "planes":
				if (value)
					result = Resource.Drawable.IMG_otherobjects_positive;
				else
					result = Resource.Drawable.IMG_otherobjects_negative;
				break;
			case "weather":
				if (value)
					result = Resource.Drawable.IMG_weather_positive;
				else
					result = Resource.Drawable.IMG_weather_negative;
				break;
			}

			return result;
		} 
	}
}
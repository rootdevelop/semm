using System;
using MvvmCross.Platform.Converters;
using UIKit;

namespace Converters
{
    public class BooleanToImageConverter: MvxValueConverter<bool, UIImage>
    {
        protected override UIImage Convert(bool value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            UIImage result = new UIImage();
            string kind = parameter.ToString();

            switch (kind)
            {
                case "nofly":
                    if (value)
                        result = UIImage.FromBundle("IMG_noflyzones_positive");
                    else
                        result = UIImage.FromBundle("IMG_noflyzones_negative");
                    break;
                case "birds":
                    if (value)
                        result = UIImage.FromBundle("IMG_birds_positive");
                    else
                        result = UIImage.FromBundle("IMG_birds_negative");
                    break;
                case "planes":
                    if (value)
                        result = UIImage.FromBundle("IMG_otherobjects_positive");
                    else
                        result = UIImage.FromBundle("IMG_otherobjects_negative");
                    break;
                case "weather":
                    if (value)
                        result = UIImage.FromBundle("IMG_weather_positive");
                    else
                        result = UIImage.FromBundle("IMG_weather_negative");
                    break;
            }

            return result;
        }
    }
}


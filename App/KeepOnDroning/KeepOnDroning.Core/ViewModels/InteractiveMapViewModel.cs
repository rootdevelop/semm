using System;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using MvvmCross.Platform;
using MvvmCross.Plugins.Location;

namespace KeepOnDroning.Core.ViewModels
{
    public class InteractiveMapViewModel : MvxViewModel
    {
        public InteractiveMapViewModel()
        {
			//var location = Mvx.Resolve<IMvxLocationWatcher>().CurrentLocation;
			//Lat = location.Coordinates.Latitude;
			//Long = location.Coordinates.Longitude;
        }

        public ICommand GoBackCommand
        {
            get
            {
                return new MvxCommand(() =>
                    {
                        Close(this);
                    });
            }
        }

		private double _lat;
		public double Lat
		{
			get { return _lat; }
			set
			{
				_lat = value;
				RaisePropertyChanged (() => Lat);
			}
		}

		private double _long;
		public double Long
		{
			get { return _lat; }
			set
			{
				_long = value;
				RaisePropertyChanged (() => Long);
			}
		}
    }
}


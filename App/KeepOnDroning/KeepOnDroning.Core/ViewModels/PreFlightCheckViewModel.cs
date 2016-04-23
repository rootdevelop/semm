using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using System.Threading.Tasks;

namespace KeepOnDroning.Core.ViewModels
{
    public class PreFlightCheckViewModel : MvxViewModel
    {
		private string _noFlyText;
		private string _birdsText;
		private string _planesText;
		private string _weatherText;
		private bool _noFlyIsOkay;
		private bool _birdsIsOkay;
		private bool _planesIsOkay;
		private bool _weatherIsOkay;
		private bool _showInformation = true;

		public PreFlightCheckViewModel()
		{
			NoFlyText = "Retrieving information...";
			BirdsText = "Retrieving information...";
			WeatherText = "Retrieving information...";
			PlanesText = "Retrieving information...";
		}

		public ICommand GoToInteractiveMapCommand
		{
			get
			{
				return new MvxCommand(() =>
					{
						ShowViewModel<InteractiveMapViewModel>();
					});
			}
		}

		public ICommand GoToGameCommand
		{
			get
			{
				return new MvxCommand(() =>
					{
						ShowViewModel<GameViewModel>();
					});
			}
		}

		public ICommand GoToCustomLocationCommand
		{
			get
			{
				return new MvxCommand(() =>
					{
						ShowViewModel<CustomLocationViewModel>();
					});
			}
		}

		public ICommand PreFlightCheckCommand
		{
			get
			{
				return new MvxCommand(async() =>
					{
						// Do checks
						NoFlyIsOkay = true;
						NoFlyText = "You are not in a no-fly zone!";
						await Task.Delay(1000);
						BirdsIsOkay = true;
						BirdsText = "No birds are near!";
						await Task.Delay(1000);
						PlanesIsOkay = true;
						PlanesText = "No roaring engines above you!";
						await Task.Delay(1000);
						WeatherIsOkay = true;
						WeatherText = "There is no bad weather, only wrong clothing!";
					});
			}
		}

		public string WelcomeText
		{
			get
			{
				return "Welcome to KeepOnDroning!";
			}
		}

		public ICommand InformationCommand
		{
			get
			{
				return new MvxCommand(() =>
					{
						ShowInformation = !ShowInformation ? true : false;
					});
			}
		}
		public bool ShowInformation
		{
			get {return _showInformation; }
			set
			{
				_showInformation = value;
				RaisePropertyChanged (() => ShowInformation);
			}
		}
		public bool NoFlyIsOkay
		{
			get {return _noFlyIsOkay; }
			set
			{
				_noFlyIsOkay = value;
				RaisePropertyChanged (() => NoFlyIsOkay);
			}
		}
		public bool BirdsIsOkay
		{
			get {return _birdsIsOkay; }
			set
			{
				_birdsIsOkay = value;
				RaisePropertyChanged (() => BirdsIsOkay);
			}
		}
		public bool PlanesIsOkay
		{
			get {return _planesIsOkay; }
			set
			{
				_planesIsOkay = value;
				RaisePropertyChanged (() => PlanesIsOkay);
			}
		}
		public bool WeatherIsOkay
		{
			get {return _weatherIsOkay; }
			set
			{
				_weatherIsOkay = value;
				RaisePropertyChanged (() => WeatherIsOkay);
			}
		}

		public string NoFlyText
		{
			get {return _noFlyText; }
			set
			{
				_noFlyText = value;
				RaisePropertyChanged (() => NoFlyText);
			}
		}
		public string BirdsText
		{
			get {return _birdsText; }
			set
			{
				_birdsText = value;
				RaisePropertyChanged (() => BirdsText);
			}
		}
		public string PlanesText
		{
			get {return _planesText; }
			set
			{
				_planesText = value;
				RaisePropertyChanged (() => PlanesText);
			}
		}

		public string WeatherText
		{
			get {return _weatherText; }
			set
			{
				_weatherText = value;
				RaisePropertyChanged (() => WeatherText);
			}
		}
    }
}
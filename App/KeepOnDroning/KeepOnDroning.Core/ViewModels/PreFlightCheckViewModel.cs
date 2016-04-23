using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using System.Threading.Tasks;
using MvvmCross.Platform;
using KeepOnDroning.Core.Enums;
using KeepOnDroning.Core.Services.Interfaces;

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
        private bool _isLoading;
        private bool _showInformation = true;
        private EPreFlightStatus _preFlightStatus;

        public PreFlightCheckViewModel()
        {
            NoFlyText = "Interact with Start Button for info";
            BirdsText = "Interact with Start Button for info";
            WeatherText = "Interact with Start Button for info";
            PlanesText = "Interact with Start Button for info";
            PreFlightStatus = EPreFlightStatus.Red;
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
                        IsLoading = true;

                        var res = await Mvx.Resolve<IToDroneOrNotToDroneOrMaybeShouldCouldIDroneTodayOrNotBecauseILikeDroningSoMuchPleaseYesService>().TellMe(0, 0); //TODO add GPS lat long

                        Reset();
                        await Task.Delay(500);
                        PreFlightStatus = EPreFlightStatus.Orange;


                        // Do checks
                        NoFlyIsOkay = !res.HasNoFlyZone;

                        if (NoFlyIsOkay)
                            NoFlyText = "You are not in a no-fly zone!";
                        else
                            NoFlyText = "You are in a no-fly zone!";
                        
                        await Task.Delay(1000);

                        BirdsIsOkay = !res.HasBirds;

                        if (BirdsIsOkay)
                            BirdsText = "No dangerous birds are near!";
                        else
                            BirdsText = "STOP! Angry birds are near";

                        await Task.Delay(1000);


                        PlanesIsOkay = !res.CrossingFlightpaths;

                        if (PlanesIsOkay)
                            PlanesText = "No roaring engines above you!";
                        else
                            PlanesText = "Planes ahead, only for the brave!";

                        await Task.Delay(1000);


                        WeatherIsOkay = !res.HasDangerDanger;

                        if (WeatherIsOkay)
                            WeatherText = "There is no bad weather, only wrong clothing!";
                        else
                            WeatherText = "Rain! Don't forget to give your drone an umbrella!";

						if(WeatherIsOkay && BirdsIsOkay && NoFlyIsOkay && PlanesIsOkay)
                        	PreFlightStatus = EPreFlightStatus.Green;
                        IsLoading = false;
                    });
            }
        }

        private void Reset()
        {
            PreFlightStatus = EPreFlightStatus.Red;
            NoFlyText = "Retrieving information...";
            BirdsText = "Retrieving information...";
            WeatherText = "Retrieving information...";
            PlanesText = "Retrieving information...";
            PlanesIsOkay = false;
            BirdsIsOkay = false;
            WeatherIsOkay = false;
            NoFlyIsOkay = false;
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

        public string WelcomeText
        {
            get
            {
                return "Welcome to KeepOnDroning!";
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public EPreFlightStatus PreFlightStatus
        {
            get { return _preFlightStatus; }
            set
            {
                _preFlightStatus = value;
                RaisePropertyChanged(() => PreFlightStatus);
            }
        }

        public bool ShowInformation
        {
            get { return _showInformation; }
            set
            {
                _showInformation = value;
                RaisePropertyChanged(() => ShowInformation);
            }
        }

        public bool NoFlyIsOkay
        {
            get { return _noFlyIsOkay; }
            set
            {
                _noFlyIsOkay = value;
                RaisePropertyChanged(() => NoFlyIsOkay);
            }
        }

        public bool BirdsIsOkay
        {
            get { return _birdsIsOkay; }
            set
            {
                _birdsIsOkay = value;
                RaisePropertyChanged(() => BirdsIsOkay);
            }
        }

        public bool PlanesIsOkay
        {
            get { return _planesIsOkay; }
            set
            {
                _planesIsOkay = value;
                RaisePropertyChanged(() => PlanesIsOkay);
            }
        }

        public bool WeatherIsOkay
        {
            get { return _weatherIsOkay; }
            set
            {
                _weatherIsOkay = value;
                RaisePropertyChanged(() => WeatherIsOkay);
            }
        }

        public string NoFlyText
        {
            get { return _noFlyText; }
            set
            {
                _noFlyText = value;
                RaisePropertyChanged(() => NoFlyText);
            }
        }

        public string BirdsText
        {
            get { return _birdsText; }
            set
            {
                _birdsText = value;
                RaisePropertyChanged(() => BirdsText);
            }
        }

        public string PlanesText
        {
            get { return _planesText; }
            set
            {
                _planesText = value;
                RaisePropertyChanged(() => PlanesText);
            }
        }

        public string WeatherText
        {
            get { return _weatherText; }
            set
            {
                _weatherText = value;
                RaisePropertyChanged(() => WeatherText);
            }
        }
    }
}
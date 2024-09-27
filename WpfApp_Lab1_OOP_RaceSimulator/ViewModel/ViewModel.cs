using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using WpfApp_Lab1_OOP_RaceSimulator.Models;
using WpfApp_Lab1_OOP_RaceSimulator.Models.AirTransports;
using WpfApp_Lab1_OOP_RaceSimulator.Models.GroundTransports;
using WpfApp_Lab1_OOP_RaceSimulator.Models.Races;
using WpfApp_Lab1_OOP_RaceSimulator.ViewModels;

namespace WpfApp_Lab1_OOP_RaceSimulator.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string _selectedRaceType;
        private string _winner;
        private string _raceDistance;
        private Race _currentRace;
        private ITransport _selectedTransport;
        private ObservableCollection<ITransport> _availableTransports;
        private ObservableCollection<ITransport> _registeredTransports;
        private ObservableCollection<RaceResult> _raceRating;
        private ObservableCollection<ITransport> AllTransports { get; }
        public ObservableCollection<ITransport> AvailableTransports
        {
            get => _availableTransports;
            set
            {
                _availableTransports = value;
                OnPropertyChanged(nameof(AvailableTransports));
            }
        }

        public ObservableCollection<ITransport> RegisteredTransports
        {
            get => _registeredTransports;
            set
            {
                _registeredTransports = value;
                OnPropertyChanged(nameof(RegisteredTransports));
            }
        }
        public ObservableCollection<RaceResult> RaceRating
        {
            get => _raceRating;
            set
            {
                _raceRating = value;
                OnPropertyChanged(nameof(RaceRating));
            }
        }
        public ObservableCollection<string> RaceTypes { get; set; }
        public string RaceDistance
        {
            get => _raceDistance;
            set
            {
                _raceDistance = value;
                OnPropertyChanged(nameof(RaceDistance));
            }
        }
        public string Winner
        {
            get => _winner;
            set
            {
                _winner = value;
                OnPropertyChanged(nameof(Winner));
            }
        }
        public ITransport SelectedTransport
        {
            get => _selectedTransport;
            set
            {
                _selectedTransport = value;
                OnPropertyChanged(nameof(SelectedTransport));
            }
        }
        public string SelectedRaceType
        {
            get => _selectedRaceType;
            set
            {
                if (_selectedRaceType != value)
                {
                    _selectedRaceType = value;
                    FilterTransportsByRaceType();
                    RegisteredTransports?.Clear();

                    OnPropertyChanged(nameof(SelectedRaceType));
                    OnPropertyChanged(nameof(RegisteredTransports));
                }
            }
        }
        private void FilterTransportsByRaceType()
        {   
            switch (SelectedRaceType)
            {
                case "Наземная":
                    AvailableTransports = new ObservableCollection<ITransport>(
                        AllTransports.Where(t => t is GroundTransport));
                    break;
                case "Воздушная":
                    AvailableTransports = new ObservableCollection<ITransport>(
                        AllTransports.Where(t => t is AirTransport));
                    break;
                case "Смешанная":
                    AvailableTransports = new ObservableCollection<ITransport>(AllTransports);
                    break;
                default:
                    AvailableTransports.Clear();
                    break;
            }
        }
        public ViewModel()
        {
            AllTransports = new ObservableCollection<ITransport>
            {
                new BabaYagaStupa(),
                new Broom(),
                new CarpetPlane(),
                new FlyingShip(),
                
                new BootsRunners(),
                new Centaur(),
                new HutOnChickenLegs(),
                new PumpkinCarriage()
            };
            AvailableTransports = new ObservableCollection<ITransport>(AllTransports);
            RaceTypes = new ObservableCollection<string>
            {
                "Наземная",
                "Воздушная",
                "Смешанная"
            };
            SelectedRaceType = RaceTypes[0];
            RegisteredTransports = new ObservableCollection<ITransport>();
        }
        public ICommand RegisterTransportCommand => new RelayCommand(RegisterTransports, CanRegisterTransport);

        private void RegisterTransports(object parameter)
        {
            RegisteredTransports.Add(SelectedTransport ?? null);
        }
        private bool CanRegisterTransport(object parameter)
        {
            return SelectedTransport != null;
        }

        public ICommand StartRaceCommand => new RelayCommand(StartRace, CanStartRace);

        private void StartRace(object parameter)
        {
            if (double.TryParse(RaceDistance, out double distance))
            {
                switch (SelectedRaceType)
                {
                    case "Наземная":
                        _currentRace = new GroundRace(distance);
                        break;
                    case "Воздушная":
                        _currentRace = new AirRace(distance);
                        break;
                    case "Смешанная":
                        _currentRace = new MixedRace(distance);
                        break;
                    default:
                        throw new InvalidOperationException("Неизвестный тип гонки.");
                }

                foreach (var transport in RegisteredTransports)
                {
                    _currentRace.RegisterTransport(transport);
                }

                RaceRating = new ObservableCollection<RaceResult>(_currentRace.StartRace());
                Winner = RaceRating.FirstOrDefault()?.Name;
                OnPropertyChanged(nameof(Winner));
            }
        }

        private bool CanStartRace(object parameter)
        {
            return RegisteredTransports.Count > 1 && !string.IsNullOrEmpty(RaceDistance);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

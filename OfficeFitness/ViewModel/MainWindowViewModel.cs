using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using OfficeFitness.Utils;
using OfficeFitness.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Threading;

namespace OfficeFitness.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged, IActivateWindow
    {

        public ObservableCollection<CheckedListExerciseItem> Sections { get; set; }       
        private bool _isTimerStarted = false;
        private bool _shouldStartLoop = false;

        private DispatcherTimer timer;

        private long selectedInterval;
        private long timeLeft;
        public TimeSpan TimeLeft { get { return TimeSpan.FromSeconds(timeLeft); } }
        IMapper mapperDTOToPresent = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ExerciseDTO, CheckedListExerciseItem>()
            .ForMember(checkItem => checkItem.IsChecked, m => m.MapFrom(u => u.IsChosen));
        }).CreateMapper();


        IMapper mapperPresentToDTO = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CheckedListExerciseItem, ExerciseDTO>()
            .ForMember(checkItem => checkItem.IsChosen, m => m.MapFrom(u => u.IsChecked));
        }).CreateMapper();


        IExercisesService exerciseService;

        public Action Activate { get; set; }

        public MainWindowViewModel()
        {
            exerciseService = new ExerciseService("ExercisesDbConnection");          
            Sections = mapperDTOToPresent.Map<ObservableCollection<CheckedListExerciseItem>>(exerciseService.GetAll());

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft >= 0)
            {
                OnPropertyChanged("TimeLeft");
            }
            else
            {
                _isTimerStarted = false;
                StopTimerCommand.RaiseCanExecuteChanged();
                StartTimerCommand.RaiseCanExecuteChanged();
                timer.Stop();
                _shouldStartLoop = true;
                ShowExercisesWindow();
            }
        }
        
        #region StartTimer
        private DelegateCommand _startTimerCommand;
        public DelegateCommand StartTimerCommand
        {
            get
            {
                return _startTimerCommand ?? (_startTimerCommand = new DelegateCommand(StartTime, CanExecuteStartTime));
            }
        }

        private void StartTime(object arg)
        {
            if (selectedInterval == 0)
            {
                MessageBox.Show("Нужно выбрать интервал между разминками", "Ошибочка!", MessageBoxButton.OK);
            }
            else if (Sections.Where(checkBox => checkBox.IsChecked == true).Count() < 3)
            {
                MessageBox.Show("Нужно выбрать минимум три упражнения для разминки", "Ошибочка!", MessageBoxButton.OK);
            }
            else
            {                
                timeLeft = selectedInterval;
                _isTimerStarted = true;
                StopTimerCommand.RaiseCanExecuteChanged();
                StartTimerCommand.RaiseCanExecuteChanged();
                exerciseService.UpdateChosenExercises(mapperPresentToDTO.Map<ExerciseDTO[]>(Sections.ToArray()));
                timer.Start();
            }

        }

        private bool CanExecuteStartTime(object arg)
        {
            return !_isTimerStarted;

        }
        #endregion

        #region StopTimer
        private DelegateCommand _stopTimerCommand;
        public DelegateCommand StopTimerCommand
        {
            get
            {
                return _stopTimerCommand ?? (_stopTimerCommand = new DelegateCommand(StopTime, CanExecuteStopTime));
            }

        }

        private void StopTime(object arg)
        {
            _isTimerStarted = false;
            _shouldStartLoop = false;
            StopTimerCommand.RaiseCanExecuteChanged();
            StartTimerCommand.RaiseCanExecuteChanged();
            timer.Stop();
            timeLeft = 0;
            OnPropertyChanged("TimeLeft");

        }

        private bool CanExecuteStopTime(object arg)
        {
            return _isTimerStarted;

        }
        #endregion

        #region SelectInterval
        private DelegateCommand _selectIntervalCommand;
        public DelegateCommand SelectIntervalCommand
        {
            get
            {
                return _selectIntervalCommand ?? (_selectIntervalCommand = new DelegateCommand(SelectInterval));
            }
        }

        private void SelectInterval(object arg)
        {
            string radioButtonName = (string)arg;
            switch (radioButtonName)
            {
                case "rb1m":
                    {
                        selectedInterval = 10;                       
                        break;
                    }
                case "rb30m":
                    {
                        selectedInterval = 30 * 60;
                        break;
                    }
                case "rb60m":
                    {
                        selectedInterval = 60 * 60;
                        break;
                    }
                case "rb90m":
                    {
                        selectedInterval = 90 * 60;
                        break;
                    }
            }
            timeLeft = selectedInterval;
            OnPropertyChanged("TimeLeft");

        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }

        private void ShowExercisesWindow()
        {
            Activate?.Invoke();
            List<CheckedListExerciseItem> exercises = Sections.Where(checkBox => checkBox.IsChecked == true).OrderBy(x => x.LastUsedTime).Take(5).ToList();
            ExercisesWindow window = new ExercisesWindow(exercises);
            window.ShowDialog();
            UpdateInfo();
        }

        private void UpdateInfo()
        {
            Sections = mapperDTOToPresent.Map<ObservableCollection<CheckedListExerciseItem>>(exerciseService.GetAll());
            timeLeft = selectedInterval;
            OnPropertyChanged("TimeLeft");
            if (_shouldStartLoop)
            {
                _isTimerStarted = true;
                StopTimerCommand.RaiseCanExecuteChanged();
                StartTimerCommand.RaiseCanExecuteChanged();
                timer.Start();
            }
        }

    }
}

using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using OfficeFitness.Model;
using OfficeFitness.Utils;
using OfficeFitness.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Threading;

namespace OfficeFitness.ViewModel
{
    class ExercisesWindowViewModel : INotifyPropertyChanged, ICloseWindow
    {        
        private List<CheckedListExerciseItem> ChosenExercises;

        private Boolean _isTimerStarted = false;
        private DispatcherTimer Timer;

        private long selectedInterval = 30;
        private long timeLeft;
        public TimeSpan TimeFromStart { get { return TimeSpan.FromSeconds(timeLeft); } }
        private ExercisePresentModel _currentExercise;
        public ExercisePresentModel CurrentExercise
        {
            get => _currentExercise;
            set
            {
                _currentExercise = value;
                OnPropertyChanged("CurrentExercise");
                
            }
        }

        IMapper mapper = new MapperConfiguration(cfg =>
       {
           cfg.CreateMap<ExerciseDTO, ExercisePresentModel>();
        }).CreateMapper();

        IExercisesService exerciseService;

        public Action Close { get; set; }

        public ExercisesWindowViewModel(List<CheckedListExerciseItem> chosenExercises)
        {
            this.ChosenExercises = chosenExercises;

            exerciseService = new ExerciseService("ExercisesDbConnection");
           
            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += new EventHandler(timer_Tick);

            LoadExercise();

        }
       
        private void timer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            if (timeLeft >= 0)
            {
                OnPropertyChanged("TimeFromStart");
            }
            else
            {
                _isTimerStarted = false;
                NextExerciseCommand.RaiseCanExecuteChanged();
                Timer.Stop();               
            }
        }
        
        #region NextExercise
        private DelegateCommand _nextExerciseCommand;
        public DelegateCommand NextExerciseCommand
        {
            get
            {
                return _nextExerciseCommand ?? (_nextExerciseCommand = new DelegateCommand(NextExercise, CanExecuteNextExercise));
            }
        }

        private void NextExercise(object arg)
        {                                  
            if(ChosenExercises.Count != 0)
            {
                LoadExercise();
            }
            else
            {
                Close?.Invoke();

            }

        }

        private bool CanExecuteNextExercise(object arg)
        {
            return !_isTimerStarted;

        }
        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }

        private void LoadExercise()
        {
            CurrentExercise = mapper.Map<ExercisePresentModel>(exerciseService.GetExercise(ChosenExercises[0].ExerciseId));
            exerciseService.UpdateExerciseLastShownTime(CurrentExercise.ExerciseId);
            ChosenExercises.Remove((ChosenExercises[0]));
            timeLeft = selectedInterval;
            Timer.Start();
            _isTimerStarted = true;
            NextExerciseCommand.RaiseCanExecuteChanged();
        }

    }
}

using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Services;
using OfficeFitness.View;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Threading;

namespace OfficeFitness.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {       

        public ObservableCollection<CheckedListExerciseItem> Sections { get; set; }
        private CheckedListExerciseItem _selectedSection;


        private DispatcherTimer timer;
        private long selectedInterval;
        public TimeSpan TimeFromStart { get { return TimeSpan.FromSeconds(selectedInterval); } }

        IExercisesService exerciseService;

        public MainWindowViewModel()
        {
            exerciseService = new ExerciseService("ExercisesDbConnection");
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExerciseDTO, CheckedListExerciseItem>()
                .ForMember(checkItem => checkItem.IsChecked, m => m.MapFrom(u => u.IsChosen));
            }).CreateMapper();

            Sections = mapper.Map<ObservableCollection<CheckedListExerciseItem>>(exerciseService.GetAll());

           

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
                      
        }

        public CheckedListExerciseItem SelectedSection
        {
            get { return _selectedSection; }
            set
            {
                _selectedSection = value;
                OnPropertyChanged("SelectedSection");
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            selectedInterval--;
            if (selectedInterval >= 0) {
                OnPropertyChanged("TimeFromStart");
            }
            else
            {
                timer.Stop();
            }
            
           
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }


    }
}

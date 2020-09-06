using OfficeFitness.Utils;
using OfficeFitness.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace OfficeFitness.View
{
    /// <summary>
    /// Логика взаимодействия для ExercisesWindow.xaml
    /// </summary>
    public partial class ExercisesWindow : Window
    {
        public ExercisesWindow(List<CheckedListExerciseItem> chosenExercises)
        {
            InitializeComponent();
            Owner = Application.Current.MainWindow;
            ExercisesWindowViewModel viewModel = new ExercisesWindowViewModel(chosenExercises);
            DataContext = viewModel;

            Loaded += ExerciseWindow_Loaded;

        }

        private void ExerciseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is ICloseWindow vm)
            {
                vm.Close += () =>
               {
                   this.Close();
               };
            }
        }
    }
}

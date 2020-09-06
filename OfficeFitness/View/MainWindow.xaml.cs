using OfficeFitness.Utils;
using System.Windows;

namespace OfficeFitness.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            Loaded += ExerciseWindow_Loaded;
        }

        private void ExerciseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is IActivateWindow vm)
            {
                vm.Activate += () =>
                {
                    this.Activate();
                };
            }
        }

    }
}

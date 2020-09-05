using System.ComponentModel;

namespace OfficeFitness.View
{
    public class CheckedListExerciseItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyChanged)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }

        public CheckedListExerciseItem()
        { }

        private bool isChecked;
        private string exerciseName;
        public int ExerciseId { get; set; }



        public string Name
        {
            get { return exerciseName; }
            set
            {
                exerciseName = value;
                OnPropertyChanged("Item");
            }
        }


        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }


    }
}

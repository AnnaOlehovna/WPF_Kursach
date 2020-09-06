using System.ComponentModel;
using System.Windows.Media.Imaging;

namespace OfficeFitness.Model
{
    class ExercisePresentModel : INotifyPropertyChanged
    {
        public int ExerciseId { get; set; }
        private string _name;
        public string Name { get=> _name;
            set {
                _name = value;
                OnPropertyChanged("Name");
            } }

        private string _description;
        public string Description { get => _description; set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private string _imageUri;
        public string ImageUri {
            get => _imageUri;
            set
            {
                _imageUri = value;
                OnPropertyChanged("ImageUri");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

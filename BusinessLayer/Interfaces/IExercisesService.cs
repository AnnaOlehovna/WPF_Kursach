using BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace BusinessLayer.Interfaces
{
    public interface IExercisesService
    {
        ObservableCollection<ExerciseDTO> GetAll();
        ObservableCollection<ExerciseDTO> GetAllChosenExercises();
        ObservableCollection<ExerciseDTO> GetRandomChosenExercises(int count);
        void SetExerciseChosen(int exerciseId, bool isChosen);
        void UpdateExerciseLastShownTime(int exerciseId);
    }
}

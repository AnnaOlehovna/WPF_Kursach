using BusinessLayer.Models;
using System.Collections.ObjectModel;

namespace BusinessLayer.Interfaces
{
    public interface IExercisesService
    {
        ObservableCollection<ExerciseDTO> GetAll();
        ExerciseDTO GetExercise(int exerciseId);
        void UpdateExerciseLastShownTime(int exerciseId);
        void UpdateChosenExercises(ExerciseDTO[] exercises);
    }
}

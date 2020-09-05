using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IExercisesRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetFiveRandom();
        void Update(T entity);
    }
}

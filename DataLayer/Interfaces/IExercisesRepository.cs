using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IExercisesRepository<T>
    {
        IEnumerable<T> GetAll();
        void Update(T entity);
        T Get(int id);
    }
}

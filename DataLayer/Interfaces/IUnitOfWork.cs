using DataLayer.Entities;
using System;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IExercisesRepository<Exercise> Exercises { get; }
        void Save();
    }
}

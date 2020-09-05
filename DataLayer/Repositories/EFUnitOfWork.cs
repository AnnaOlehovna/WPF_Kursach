using DataLayer.EFContext;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;

namespace DataLayer.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        ExercisesContext context;
        ExercisesRepository exercisesRepository;

        public EFUnitOfWork(string name)
        {
            context = new ExercisesContext(name);
        }
        public IExercisesRepository<Exercise> Exercises
        {
            get
            {
                if (exercisesRepository == null)
                    exercisesRepository = new ExercisesRepository(context);
                return exercisesRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)

                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

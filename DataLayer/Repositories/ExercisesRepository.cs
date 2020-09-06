using DataLayer.EFContext;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace DataLayer.Repositories
{
    class ExercisesRepository : IExercisesRepository<Exercise>
    {
        ExercisesContext context;
        public ExercisesRepository(ExercisesContext context)
        {
            this.context = context;
        }

        public Exercise Get(int id)
        {
            return context.Exercises.Find(id);
        }

        public IEnumerable<Exercise> GetAll()
        {
            return context.Exercises;
        }

        public void Update(Exercise entity)
        {
            context.Set<Exercise>().AddOrUpdate(entity);
        }
    }
}

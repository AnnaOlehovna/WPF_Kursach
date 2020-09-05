using DataLayer.EFContext;
using DataLayer.Entities;
using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace DataLayer.Repositories
{
    class ExercisesRepository : IExercisesRepository<Exercise>
    {
        ExercisesContext context;
        public ExercisesRepository(ExercisesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Exercise> GetAll()
        {
            return context.Exercises;
        }

        public IEnumerable<Exercise> GetFiveRandom()
        {
            return context.Exercises.OrderBy(x => Guid.NewGuid()).Take(3);
        }

        public void Update(Exercise entity)
        {
            context.Set<Exercise>().AddOrUpdate(entity);
        }
    }
}

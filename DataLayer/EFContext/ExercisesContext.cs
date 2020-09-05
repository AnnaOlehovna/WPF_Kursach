using DataLayer.Entities;
using System.Data.Entity;

namespace DataLayer.EFContext
{
    class ExercisesContext: DbContext
    {
        public ExercisesContext(string name) : base(name)
        {
            Database.SetInitializer(new ExercisesInitializer());
        }
        public DbSet<Exercise> Exercises { get; set; }
    }
}

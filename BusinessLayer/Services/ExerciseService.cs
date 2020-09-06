using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using System;
using System.Collections.ObjectModel;

namespace BusinessLayer.Services
{
    public class ExerciseService : IExercisesService
    {

        IUnitOfWork dataBase;
        IMapper mapperDTOToEntity;
        IMapper mapperEntityToDTO;

        public ExerciseService(string name)
        {
            dataBase = new EFUnitOfWork(name);

            mapperDTOToEntity = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExerciseDTO, Exercise>();
            }).CreateMapper();

            mapperEntityToDTO = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Exercise, ExerciseDTO>();
            }).CreateMapper();

        }

        public ObservableCollection<ExerciseDTO> GetAll()
        {
            return mapperEntityToDTO.Map<ObservableCollection<ExerciseDTO>>(dataBase.Exercises.GetAll());
        }


        public ExerciseDTO GetExercise(int exerciseId)
        {
            return mapperEntityToDTO.Map<ExerciseDTO>(dataBase.Exercises.Get(exerciseId));
        }

        public void UpdateChosenExercises(ExerciseDTO[] exercises)
        {
            foreach (ExerciseDTO ex in exercises)
            {
                var exercise = dataBase.Exercises.Get(ex.ExerciseId);
                exercise.IsChosen = ex.IsChosen;
                dataBase.Exercises.Update(exercise);

            }
            dataBase.Save();
        }

        public void UpdateExerciseLastShownTime(int exerciseId)
        {
            var exercise = dataBase.Exercises.Get(exerciseId);
            exercise.LastUsedTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            dataBase.Exercises.Update(exercise);
            dataBase.Save();
        }
    }
}

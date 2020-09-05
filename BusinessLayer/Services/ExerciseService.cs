using System.Collections.ObjectModel;
using AutoMapper;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;

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

        public ObservableCollection<ExerciseDTO> GetAllChosenExercises()
        {
            throw new System.NotImplementedException();
        }

        public ObservableCollection<ExerciseDTO> GetRandomChosenExercises(int count)
        {
            throw new System.NotImplementedException();
        }

        public void SetExerciseChosen(int exerciseId, bool isChosen)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateExerciseLastShownTime(int exerciseId)
        {
            throw new System.NotImplementedException();
        }
    }
}

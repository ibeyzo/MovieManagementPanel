using Application.Validation;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MovieManager
    {
        private readonly MovieRepository movieRepository;
        private readonly EntityValidation entityValidation;

        public MovieManager(MovieRepository movieRepository,
            EntityValidation entityValidation)
        {
            this.movieRepository = movieRepository;
            this.entityValidation = entityValidation;
        }

        public void Add(MovieCreateDto createDto)
        {
            Movie entity = new Movie()
            {
                Name = createDto.Name,
                YearOfConstruction = createDto.YearOfConstruction
            };
            movieRepository.Add(entity);
        }

        public void Update(MovieUpdateDto updateDto)
        {
            Movie entity = movieRepository.Get(x => x.Id == updateDto.Id);

            entityValidation.NotNull(entity);

            entity.Name = updateDto.Name;
            entity.YearOfConstruction = updateDto.YearOfConstruction;

            movieRepository.Update(entity);
        }

        public void Delete(int id)
        {
            Movie entity = movieRepository.Get(x => x.Id == id);

            entityValidation.NotNull(entity);

            movieRepository.Delete(entity);
        }

        public IEnumerable<Movie> GetAll()
        {
            IEnumerable<Movie> movies = movieRepository.GetList()
                .Include(x => x.Projections)
                .ThenInclude(x => x.Saloon);

            return movies;
        }

        public IEnumerable<Movie> GetAllByYearOfConstruction(int firstYear, int lastYear)
        {
            entityValidation.LowerThan(firstYear, lastYear);

            IEnumerable<Movie> movies = movieRepository
                .GetList(x => x.YearOfConstruction >= firstYear && x.YearOfConstruction <= lastYear)
                 .Include(x => x.Projections)
                .ThenInclude(x => x.Saloon);

            return movies;
        }

        public Movie GetById(int id)
        {
            entityValidation.GreaterThan(id, 0);
            Movie movie = movieRepository.Get(x => x.Id == id);
            return movie;
        }

        public IEnumerable<Movie> GetByName(string name)
        {
            IEnumerable<Movie> movies = movieRepository.GetList(x => x.Name == name)
                .Include(x => x.Projections)
                .ThenInclude(x => x.Saloon);
            return movies;
        }

        public IEnumerable<Movie> GetAllBySaloonName(string name)
        {
            var movies = movieRepository.GetList(m => m.Projections
                .Any(p => p.Saloon.Name == name))
                .Include(x => x.Projections)
                .ThenInclude(x => x.Saloon);

            foreach (var movie in movies)
            {
                movie.Projections = movie.Projections.Where(x => x.Saloon.Name == name).ToList();
            }
            return movies;
        }
    }
}

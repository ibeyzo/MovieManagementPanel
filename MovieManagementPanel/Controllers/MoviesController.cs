using Application.Services;
using Application.Validation;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MovieManagementPanel.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieManager movieManager;

        public MoviesController(MovieManager movieManager)
        {
            this.movieManager = movieManager;
        }

        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(MovieCreateDto createDto)
        {
            movieManager.Add(createDto);
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            movieManager.Delete(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var movie = movieManager.GetById(id);
            return View(new MovieUpdateDto()
            {
                Id = id,
                Name = movie.Name,
                YearOfConstruction = movie.YearOfConstruction
            });
        }

        [HttpPost]
        public IActionResult Update(MovieUpdateDto updateDto)
        {
            movieManager.Update(updateDto);
            return RedirectToAction("Index", "Home");
        }

        
    }
}

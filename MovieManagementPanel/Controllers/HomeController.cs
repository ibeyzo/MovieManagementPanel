using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MovieManagementPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieManager movieManager;

        public HomeController(MovieManager movieManager)
        {
            this.movieManager = movieManager;
        }

        public IActionResult Index()
        {
            return View(movieManager.GetAll());
        }

        [HttpGet]
        public IActionResult GetAllByYearOfConstruction([FromQuery] int firstYear, [FromQuery] int secondYear)
        {
            var movies = movieManager.GetAllByYearOfConstruction(firstYear, secondYear);
            return View("Index", movies);
        }

        [HttpGet]
        public IActionResult GetByName([FromQuery] string name)
        {
            var movie = movieManager.GetByName(name);
            return View("Index",movie);
        }

        [HttpGet]
        public IActionResult GetAllBySaloonName([FromQuery]string name)
        {
            var movies = movieManager.GetAllBySaloonName(name);
            return View("Index",movies);
        }
    }
}

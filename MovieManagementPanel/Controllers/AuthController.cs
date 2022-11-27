using Microsoft.AspNetCore.Mvc;
using MovieManagementPanel.Models;

namespace MovieManagementPanel.Controllers
{
    public class AuthController : Controller
    {
        

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserForRegister userForRegister)
        {
            if (true)
            {
                return RedirectToAction("Login", "Auth");
            }

            ModelState.AddModelError("error", "Lütfen alanları kontrol ediniz.");

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login( UserForLoginDto loginDto)
        {
            if (true)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("error", "Lütfen alanları kontrol ediniz.");

            return View();
        }
    }
}

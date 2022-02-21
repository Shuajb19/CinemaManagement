using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.Controllers
{
    public class Cian : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

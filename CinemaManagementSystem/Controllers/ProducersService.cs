using CinemaManagementSystem.Data.Services;
using CinemaManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class ProducersService : Controller
    {
        private readonly IProducersService _service;
        public ProducersController(IProducersService Service)
        {
            _service = Service;
        }

        public async Task<IActionResult> Index()
        {
            var allProducers=await _service.GetAllAsync();  
            return View(allProducers);
        }
        //GET: Producer/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind()] Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);

            await _service.AddAsync(producer);  
            return RedirectToAction(nameof(Index));
        }
    }
}

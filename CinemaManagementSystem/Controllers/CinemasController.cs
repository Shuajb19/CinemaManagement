using CinemaManagementSystem.Data;
using CinemaManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CinemaManagementSystem.Controllers
{
    public class CinemasController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CinemasController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Cinema> objList = _db.Cinema;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cinema obj)
        {
            _db.Cinema.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Cinema.Find(id);
            if(obj == null)
                return NotFound();
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cinema obj)
        {
            _db.Cinema.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Cinema obj)
        {
            _db.Cinema.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

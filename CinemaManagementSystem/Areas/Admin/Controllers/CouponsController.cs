using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CinemaManagementSystem.Data;
using CinemaManagementSystem.Models;
using CinemaManagementSystem.Data.Services;
using Microsoft.AspNetCore.Authorization;

namespace CinemaManagementSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CouponsController : Controller
    {
        private readonly ICouponsService _service;
        private readonly ApplicationDbContext _context;

        public CouponsController(ICouponsService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        // GET: Admin/Coupons
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons.ToListAsync());
        }

        // GET: Admin/Coupons/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var couponDetail = await _service.GetCouponByIdAsync(id);
            return View(couponDetail);
        }

        // GET: Admin/Coupons/Create
        public async Task<IActionResult> Create()
        {
            var couponDropdownsData = await _service.GetNewCouponDropdownsValues();

            ViewBag.Movies = new SelectList(couponDropdownsData.Movies, "Id", "Name");

            return View();
        }

        // POST: Admin/Coupons/Create
        [HttpPost]
        public async Task<IActionResult> Create(NewCouponVM coupon)
        {
            if (!ModelState.IsValid)
            {
                 var couponDropdownsData = await _service.GetNewCouponDropdownsValues();

                ViewBag.Movies = new SelectList(couponDropdownsData.Movies, "Id", "Name");

                return View(coupon);
        }
            await _service.AddNewCouponAsync(coupon);
            TempData["save"] = "A new Coupon has been Created!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Coupons/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var couponDetails = await _service.GetCouponByIdAsync(id);
            if (couponDetails == null) return View("NotFound");

            var response = new NewCouponVM()
            {
                CouponId = couponDetails.CouponId,
                CouponCode = couponDetails.CouponCode,
                Discount = couponDetails.Discount,
                EndDate = couponDetails.EndDate,
                StartDate = couponDetails.StartDate,
                MovieIds = couponDetails.Coupons_Movies.Select(m => m.MovieId).ToList(),
            };

            var couponDropdownsData = await _service.GetNewCouponDropdownsValues();

            ViewBag.Movies = new SelectList(couponDropdownsData.Movies, "Id", "Name");

            return View(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewCouponVM coupon)
        {
            if (id != coupon.CouponId) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var couponDropdownsData = await _service.GetNewCouponDropdownsValues();

                ViewBag.Movies = new SelectList(couponDropdownsData.Movies, "Id", "Name");

                return View(coupon);
            }
            await _service.UpdateCouponAsync(coupon);
            TempData["edit"] = "Coupon has been updated!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Admin/Coupons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coupon = await _context.Coupons
                .FirstOrDefaultAsync(m => m.CouponId == id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Admin/Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            _context.Coupons.Remove(coupon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

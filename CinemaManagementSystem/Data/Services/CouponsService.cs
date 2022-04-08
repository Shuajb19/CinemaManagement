using CinemaManagementSystem.Models;
using CinemaManagementSystem.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CinemaManagementSystem.Data.Base;

namespace CinemaManagementSystem.Data.Services
{
    public class CouponsService :  ICouponsService
    {
        private readonly ApplicationDbContext _context;

        public CouponsService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task AddNewCouponAsync(NewCouponVM coupon)
        {
            var newCoupon = new Coupon()
            {
                CouponCode = coupon.CouponCode,
                Discount = coupon.Discount,
                EndDate = coupon.EndDate,
                StartDate = coupon.StartDate,
                };
            await _context.Coupons.AddAsync(newCoupon);
            await _context.SaveChangesAsync();

          //Add Movie Coupon
            foreach (var movieId in coupon.MovieIds)
            {
                var newCouponMovie = new Coupon_Movie()
                {
                    CouponId = newCoupon.CouponId,
                    MovieId = movieId
                };
                await _context.Coupons_Movies.AddAsync(newCouponMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Coupon> GetCouponByIdAsync(int id)
        {
            var couponDetails = await _context.Coupons.Include(cm => cm.Coupons_Movies).ThenInclude(m => m.Movie)
                .FirstOrDefaultAsync(n => n.CouponId == id);
            return couponDetails;
        }

        public async Task<NewCouponDropdownsVM> GetNewCouponDropdownsValues()
        {
            var value = new NewCouponDropdownsVM()
            {
                Movies = await _context.Movies.OrderBy(n => n.Id).ToListAsync()
            };

            return value;
        }

        public async Task UpdateCouponAsync(NewCouponVM coupon)
        {
            var dbCoupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponId == coupon.CouponId);

            if (dbCoupon != null)
            {
                dbCoupon.CouponId = coupon.CouponId;
                dbCoupon.CouponCode = coupon.CouponCode;
                dbCoupon.Discount = coupon.Discount;
                dbCoupon.EndDate = coupon.EndDate;
                dbCoupon.StartDate = coupon.StartDate;
                await _context.SaveChangesAsync();
            }
            //Remove existing movies
            var existingMoviesDb = _context.Coupons_Movies.Where(c => c.CouponId == coupon.CouponId).ToList();
            _context.Coupons_Movies.RemoveRange(existingMoviesDb);
            await _context.SaveChangesAsync();

            //Add Coupon Movies
            foreach (var movieId in coupon.MovieIds)
            {
                var newCouponMovie = new Coupon_Movie()
                {
                    CouponId = coupon.CouponId,
                    MovieId = movieId
                };
                await _context.Coupons_Movies.AddAsync(newCouponMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
}


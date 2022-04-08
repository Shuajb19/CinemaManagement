using CinemaManagementSystem.Data.ViewModels;
using CinemaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Data.Services
{
    public interface ICouponsService 
    {
        Task<Coupon> GetCouponByIdAsync(int id);
        Task AddNewCouponAsync(NewCouponVM couponVM);
        Task<NewCouponDropdownsVM> GetNewCouponDropdownsValues();
        Task UpdateCouponAsync(NewCouponVM data);


    }
}

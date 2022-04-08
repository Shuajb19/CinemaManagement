using CinemaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Data.ViewModels
{
    public class NewCouponDropdownsVM
    {
        public NewCouponDropdownsVM()
        {
            Movies = new List<Movie>();
        }
        public List<Movie> Movies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Models
{
    public class Coupon_Movie
    {
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Models
{
    public class NewCouponVM
    {
        public int CouponId { get; set; }

        [Display(Name = "Coupon Code")]
        [Required(ErrorMessage = "Coupon Code is required")]
        public string CouponCode { get; set; }

        [Display(Name = "Discount in %")]
        [Required(ErrorMessage = "Discount is required")]
        public double Discount { get; set; }

        [Display(Name = "Coupon Start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Coupon End date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select Movie(s)")]
        [Required(ErrorMessage = "Coupon movies(s) is required")]
        public List<int> MovieIds { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movies { get; set; }
    }
}

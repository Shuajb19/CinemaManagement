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
        public string CouponCode { get; set; }
        public double Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> MovieIds { get; set; }
    }
}

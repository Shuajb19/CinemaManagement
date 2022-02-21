using System.Collections.Generic;

namespace CinemaManagementSystem.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Room { get; set; }
        public int Capacity { get; set; }
        public List<CinemaSeat> CinemaSeat { get; set; }
    }
}

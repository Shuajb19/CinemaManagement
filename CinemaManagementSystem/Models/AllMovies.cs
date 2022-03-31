using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Models
{
    public class AllMovies
    {
        public IEnumerable<Movie> Movies{ get; set; }
        public IEnumerable<Movie> FiveMovies{ get; set; }
    }
}

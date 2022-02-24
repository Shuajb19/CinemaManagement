using CinemaManagementSystem.Data.Base;
using CinemaManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Data.Services
{
    public class ProducersService: EntityBaseRepository<Producer>, IProducersService
    {
        public ProducersService(ApplicationDbContext context) : base(context)
        {     
        }
    }
}

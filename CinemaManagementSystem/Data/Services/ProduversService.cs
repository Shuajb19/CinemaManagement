using CinemaManagementSystem.Data.Base;
using CinemaManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Data.Services
{
    public class ProduversService:IEntityBaseRepository<Producer>,IProducersService
    {
        public ProduversService(ApplicationDbContext context) : base(context)
        {
                
        }

        public Task AddAsync(Producer entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Producer>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Producer> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(int id, Producer entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

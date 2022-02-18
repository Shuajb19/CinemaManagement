using CinemaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetIdAsync(int id);
        Task AddAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}

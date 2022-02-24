using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CinemaManagementSystem.Models;
using CinemaManagementSystem.Data.Base;

namespace CinemaManagementSystem.Data.Services
{
    public interface ICinemasService : IEntityBaseRepository<Cinema>
    {
    }
}

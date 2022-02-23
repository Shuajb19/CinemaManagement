using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CinemaManagementSystem.Models;
using CinemaManagementSystem.Data.Base;

namespace CinemaManagementSystem.Data.Services
{
    public class CinemasService:IEntityBaseRrepository<Cinema>, ICinemasService
    {
        public CinemasService(ApplicationDbContext context) : base(context) 
        { 

        }

    }
}

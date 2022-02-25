using CinemaManagementSystem.Data.Base;
using CinemaManagementSystem.Data.ViewModels;
using CinemaManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task UpdateMovieAsync(NewMovieVM data);
    }
}

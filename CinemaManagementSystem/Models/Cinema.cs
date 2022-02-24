using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using CinemaManagementSystem.Models;
using CinemaManagementSystem.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace CinemaManagementSystem.Models
{
    public class Cinema:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
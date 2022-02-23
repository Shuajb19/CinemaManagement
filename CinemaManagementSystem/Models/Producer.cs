using CinemaManagementSystem.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Models
{
    public class Producer:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Realationships
        public List<Movie> Movies { get; set; }
    }
}

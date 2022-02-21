using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaManagementSystem.Models
{
    public class CinemaSeat
    {
        public int Id { get; set; }
        [ForeignKey("Id")]
        public string CinemaId { get; set; }
        public int Number { get; set; }
        public  bool isAvailable { get; set; }  
    }
}

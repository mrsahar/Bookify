using System.ComponentModel.DataAnnotations;

namespace Bookify.Models.Entity
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}

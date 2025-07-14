using System.ComponentModel.DataAnnotations;

namespace Bookify.Models.Entity
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Isbn { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherID { get; set; }
        [Required]
        public int GenreID { get; set; }


    }
}

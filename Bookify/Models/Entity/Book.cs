﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookify.Models.Entity
{
    public class Book
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Isbn { get; set; }
        [Required]
        public int TotalPages { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int PublisherID { get; set; }
        [Required]
        public int GenreID { get; set; }
        [NotMapped]
        public string? AuthorName { get; set; }
        [NotMapped]
        public string? PublisherName { get; set; }
        [NotMapped]
        public string? GenreName { get; set; }

        [NotMapped]
        public List<SelectListItem>? AutherList { get; set; }
        [NotMapped]
        public List<SelectListItem>? GenreList { get; set; }
        [NotMapped]
        public List<SelectListItem>? PublisherList { get; set; }

    }
}

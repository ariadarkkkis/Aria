using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aria.Entities;

namespace Aria.DTOs
{
    public class MovieCreationDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Imdb { get; set; }
        public int Year { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
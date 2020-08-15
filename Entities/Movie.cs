using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Aria.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aria.Entities
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Imdb { get; set; }
        public int Year { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
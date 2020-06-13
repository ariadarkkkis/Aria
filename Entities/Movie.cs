using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Entites
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
        public int CategoryId { get; set; }
        [JsonIgnore]
        public virtual List<Category> Categories { get; set; }
    }
}
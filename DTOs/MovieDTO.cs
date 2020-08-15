using System;
using System.Collections.Generic;
using Aria.Entities;

namespace Aria.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imdb { get; set; }
        public int Year { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entites
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imdb { get; set; }
        public int Year { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
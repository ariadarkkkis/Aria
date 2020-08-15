using System.Collections.Generic;
using Aria.Entities;

namespace Aria.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
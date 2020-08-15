using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Aria.Entities;

namespace Aria.DTOs
{
    public class CategoryCreationDTO
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
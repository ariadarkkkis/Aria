using System.Collections.Generic;
using System.Text.Json.Serialization;
using Aria.Entities;

namespace Entites
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<MovieCategory> MovieCategories { get; set; }
    }
}
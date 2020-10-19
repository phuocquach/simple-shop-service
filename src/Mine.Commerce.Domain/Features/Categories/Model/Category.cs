using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Mine.Commerce.Domain
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [JsonIgnore]
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public Category()
        {
            Id = Guid.NewGuid();
        }
    }
}

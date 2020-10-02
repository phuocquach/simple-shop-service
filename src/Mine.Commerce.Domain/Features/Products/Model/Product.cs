using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Mine.Commerce.Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
        public bool InStock { get; set; }
        public string ProductCode { get; set; }
        public Guid BrandId { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductImage> ProductImages {get; set;}
        [JsonIgnore]
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public Brand Brand { get; set; }
    }
}

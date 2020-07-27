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

        public static Product Create(string name, 
                                    double price, 
                                    bool inStock, 
                                    string productCode,
                                    IEnumerable<Guid> categoryIds,
                                    string imageUrl,
                                    Guid brandId,
                                    string description)
        {
            var productId = Guid.NewGuid();
            return new Product
            {
                Id = productId,
                Name = name,
                Price = price,
                ProductCode = productCode,
                InStock = inStock,
                ProductCategories = categoryIds.Select(x=> new ProductCategory{ ProductId = productId, CategoryId = x}).ToList(),
                //Categories = categoryIds,
                BrandId = brandId,
                Description =description,
                CreatedDateUtc = DateTime.UtcNow,
                ProductImages = new List<ProductImage>() {new ProductImage
                {
                    Id = Guid.NewGuid(),
                    StorageUrl = imageUrl,
                    IsPrimary = true,
                    ProductId = productId
                }}
            };
        }
    }
}

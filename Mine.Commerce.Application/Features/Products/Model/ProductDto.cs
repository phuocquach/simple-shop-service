using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using Mine.Commerce.Application.Features.Products.Command.Model;

namespace Mine.Commerce.Application.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool InStock { get; set; }
        public string ProductCode { get; set; }
        [JsonConverter(typeof(FloatStringConverter))]
        public double Price { get; set; }
        public string  Description { get; set; }
        public ICollection<ProductImageDto> ProductImages {get; set;}
        public ICollection<ProductCategoryDto> ProductCategories {get; set;}
        public Guid BrandId {get;set;}
        public Guid? Category
        { 
            get 
            { 
                return ProductCategories.FirstOrDefault()?.CategoryId;
            }
        }
    }
}
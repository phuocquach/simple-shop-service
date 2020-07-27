using System;
using Mine.Commerce.Domain;

namespace Mine.Commerce.Domain
{
    public class CategoryBrand
    {
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Category Category { get; set; }
        public Brand Brand { get; set; }
    }
}
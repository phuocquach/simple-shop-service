using System;

namespace Mine.Commerce.Application.Products
{
    public class ProductImageDto
    {
        public Guid Id { get; set; }
        public string StorageUrl { get; set; }
        public bool IsPrimary { get; set; }
    }
}
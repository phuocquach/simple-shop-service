using System;

namespace Mine.Commerce.Domain
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public string OriginalName { get; set; }
        public string UsingName { get; set;}
        public string StorageUrl { get; set; }
        public bool IsPrimary { get; set; }
        public Guid ProductId { get; set; }
    }
}
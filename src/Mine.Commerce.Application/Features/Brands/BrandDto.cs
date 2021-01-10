using System;

namespace Mine.Commerce.Application.Features.Brands
{
    public record BrandDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
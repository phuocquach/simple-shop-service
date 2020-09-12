using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Mine.Commerce.Application.Products
{
    public class CreateRequest : IRequest<ProductDto> 
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool InStock { get; set; }
        public string ProductCode { get; set; }
        public IFormFile ProductImage { get; set; }
        public double Price {get; set;}
        public Guid Category { get; set; }
        public Guid BrandId { get; set; }
        public string Description { get; set; }
    }
}
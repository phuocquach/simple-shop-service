using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Mine.Commerce.Application.Products
{
    public class UpdateRequest : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool InStock { get; set; }
        public string ProductCode { get; set; }
        public IFormFile ProductImage { get; set; }
        public string Price {get; set;}
        public IEnumerable<Guid> CategoryIds { get; set; }
        public Guid BrandId { get; set; }
    }
}
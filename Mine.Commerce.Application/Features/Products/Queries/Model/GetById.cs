using System;
using MediatR;

namespace Mine.Commerce.Application.Products
{
    public class GetById : IRequest<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
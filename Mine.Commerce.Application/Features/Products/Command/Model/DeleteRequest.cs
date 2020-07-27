using System;
using MediatR;

namespace Mine.Commerce.Application.Products
{
    public class DeleteRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
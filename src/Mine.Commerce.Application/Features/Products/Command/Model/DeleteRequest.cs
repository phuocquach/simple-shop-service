using System;
using MediatR;

namespace Mine.Commerce.Application.Products.Command
{
    public class DeleteRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
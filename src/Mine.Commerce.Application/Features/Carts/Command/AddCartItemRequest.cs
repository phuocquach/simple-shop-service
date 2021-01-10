using System;
using MediatR;

namespace Mine.Commerce.Application.Features.Carts
{
    public class AddCartItemRequest : IRequest<Unit>
    {
        public Guid ProductId { get; set; }
        public long Number { get; set; }
    }
}
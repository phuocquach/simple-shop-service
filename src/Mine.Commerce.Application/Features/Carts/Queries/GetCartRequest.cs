using System;
using MediatR;

namespace Mine.Commerce.Application.Features.Carts
{
    public class GetCartRequest : IRequest<GetCartResponse>
    {
        public Guid Id { get; set; }
    }
}
using System;
using MediatR;

namespace Mine.Commerce.Application.Features.Carts
{
    public class CheckoutCartRequest: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
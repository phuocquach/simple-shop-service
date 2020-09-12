using System;
using MediatR;

namespace Mine.Commerce.Application.Orders
{
    public class CreateRequest : IRequest<Guid>
    {
        public Guid Id { get; set; }

    }
}
using System;
using MediatR;

namespace Mine.Commerce.Application.Categories
{
    public class CreateRequest : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
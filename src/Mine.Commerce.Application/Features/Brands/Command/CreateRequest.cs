using System;
using MediatR;

namespace Mine.Commerce.Application.Brands
{
    public class CreateRequest : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Country  { get; set; }
    }
}
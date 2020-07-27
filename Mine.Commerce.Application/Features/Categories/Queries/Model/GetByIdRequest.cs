using System;
using MediatR;

namespace Mine.Commerce.Application.Categories
{
    public class GetByIdRequest : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
    }
}
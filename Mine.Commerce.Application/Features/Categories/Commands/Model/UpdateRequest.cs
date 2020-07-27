using System;
using MediatR;

namespace Mine.Commerce.Application.Categories
{
    public class UpdateRequest : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
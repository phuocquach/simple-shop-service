using System;
using MediatR;

namespace Mine.Commerce.Application.Categories
{
    public class DeleteRequest :IRequest
    {
        public Guid Id { get; set; }
    }
}
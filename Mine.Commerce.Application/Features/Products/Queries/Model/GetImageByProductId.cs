using System;
using System.IO;
using MediatR;

namespace Mine.Commerce.Application.Products
{
    public class GetImageByProductId : IRequest<string>
    {
        public Guid ProductId { get; set; }
    }
}
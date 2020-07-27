using System.Collections.Generic;
using MediatR;

namespace Mine.Commerce.Application.Products
{
    public class GetAllRequest : IRequest<IEnumerable<ProductDto>>
    {
        
    }
}
using System.Collections.Generic;
using MediatR;

namespace Mine.Commerce.Application.Categories
{
    public class GetListRequest : IRequest<IEnumerable<CategoryDto>>
    {
        
    }
}
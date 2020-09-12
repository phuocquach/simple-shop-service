using System;
using System.Collections.Generic;
using MediatR;
using Mine.Commerce.Application.Features.Brands;

namespace Mine.Commerce.Application.Brands
{
    public class GetAllRequest : IRequest<IEnumerable<BrandDto>>
    {
        
    }
}
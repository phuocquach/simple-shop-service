using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mine.Commerce.Application.Products;
using Mine.Commerce.Application.Products.Command;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiController
    {
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllRequest(), cancellationToken));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProduct(Guid id)
        {
            return Ok(await Mediator.Send(
                new GetById
                {
                    Id = id
                }));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Guid id, UpdateRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostProduct([FromForm]CreateRequest request, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(request, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id, CancellationToken cancellationToken)
        {
           
            return Ok(await Mediator.Send(new DeleteRequest{Id = id}, cancellationToken));
        }
        
        [HttpGet("{id}/images")]
        public async Task<ActionResult> GetProductImage(Guid id)
        {
            return Ok(await Mediator.Send(
                new GetImageByProductId
                {
                    ProductId = id
                }));
        }
    }
}

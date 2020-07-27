using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mine.Commerce.Application.Brands;

namespace Mine.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ApiController
    {
        [Authorize]
        [HttpPost("")]
        public async Task<ActionResult<Guid>> PostBrand(CreateRequest request, CancellationToken cancellationtoken)
        {
            return Ok(await Mediator.Send(request, cancellationtoken));
        }

        [HttpGet("")]
        public async Task<ActionResult<Guid>> GetAllBrand([FromRoute]GetAllRequest request, CancellationToken cancellationtoken)
        {
            return Ok(await Mediator.Send(request, cancellationtoken));
        }
    }
}
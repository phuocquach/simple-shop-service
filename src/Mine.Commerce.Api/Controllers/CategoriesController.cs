using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mine.Commerce.Application.Categories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
namespace Mine.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories(CancellationToken cancellationtoken)
        {
            return Ok(await Mediator.Send(new GetListRequest(), cancellationtoken));
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory([FromRoute]Guid id, CancellationToken cancellationtoken)
        {
            return Ok(await Mediator.Send(new GetByIdRequest{Id =id}, cancellationtoken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute]Guid id, UpdateRequest request, CancellationToken cancellationtoken)
        {
            return Ok(await Mediator.Send(request, cancellationtoken));
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Guid>> PostCategory(CreateRequest request, CancellationToken cancellationtoken)
        {
            return Ok(await Mediator.Send(request, cancellationtoken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory([FromRoute]Guid id, CancellationToken cancellationtoken)
        {
            return Ok(await Mediator.Send(new DeleteRequest {Id = id}, cancellationtoken));
        }
    }
}

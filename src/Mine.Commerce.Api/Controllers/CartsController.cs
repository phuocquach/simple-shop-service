using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Mine.Commerce.Application.Features.Carts;
namespace Mine.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ApiController
    {
        [HttpPut("{id}")]
        public ActionResult AddCartItem([FromBody] IEnumerable<AddCartItemRequest> request)
        {
            return Ok(Mediator.Send(request));
        } 

        [HttpGet("{id}")]
        public ActionResult<GetCartResponse> Get([FromRoute] GetCartRequest request)
        {
            return Ok(Mediator.Send(request));
        } 

        [HttpPatch("{id}")]
        public ActionResult Checkout([FromBody] CheckoutCartRequest request)
        {
            return Ok(Mediator.Send(request));
        } 
    }
}
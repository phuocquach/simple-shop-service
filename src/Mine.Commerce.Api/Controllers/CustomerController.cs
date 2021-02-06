using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mine.Commerce.Application.Features.Customers;

namespace Mine.Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ApiController
    {
        [HttpGet("{id}")]
        public ActionResult<GetCustomerResponse> Get([FromRoute]GetCustomerRequest request)
        {
            return Ok(Mediator.Send(request));
        }

    }
}
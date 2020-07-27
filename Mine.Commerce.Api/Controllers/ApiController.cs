using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Mine.Commerce.Api.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected IMediator Mediator
        {
            get
            {
                return HttpContext.RequestServices.GetService<IMediator>();
            }
        }
    }
}
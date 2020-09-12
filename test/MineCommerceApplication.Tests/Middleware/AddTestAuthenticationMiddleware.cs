using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MineCommerceApplication.Tests.Helper;
using System.Threading.Tasks;

namespace MineCommerceApplication.Tests.Middlewares
{
    public class AddTestAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public AddTestAuthenticationMiddleware(
            RequestDelegate next,
            ILogger<AddTestAuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var auth = context.RequestServices.GetRequiredService<IAuthenticationSchemeProvider>();

            var bearerScheme = await auth.GetSchemeAsync("Bearer");
            if (bearerScheme != null && bearerScheme.HandlerType != typeof(TestAuthenticationHandler))
            {
                auth.RemoveScheme("Bearer");
                auth.RemoveScheme("BearerIdentityServerAuthenticationJwt");
                auth.RemoveScheme("BearerIdentityServerAuthenticationIntrospection");
                _logger.LogInformation("Remove all Bearer schemes success");

                auth.AddScheme(new AuthenticationScheme("Bearer", displayName: null, handlerType: typeof(TestAuthenticationHandler)));
                _logger.LogInformation("Add new Bearer scheme success");
            }

            await _next(context);
        }
    }
}

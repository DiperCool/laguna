using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Middlewares
{
    public class Error404Middleware
    {
        private readonly RequestDelegate _next;
        public Error404Middleware(RequestDelegate next)
        {
            _next = next;
        }
 
        public async Task InvokeAsync(HttpContext context)
        {
            await _next.Invoke(context);
            if (context.Response.StatusCode == 404)
            {
                context.Request.Path = "/error/error404";
                await _next.Invoke(context);
            }
        }
    }
}
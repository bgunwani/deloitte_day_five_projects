using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;

namespace coreWebAPIWithAuthentication.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string authHeader = httpContext.Request.Headers["Authorization"];
            if(authHeader != null)
            {
                string auth = authHeader.Split(' ')[1];
                Encoding encoding = Encoding.UTF8;
                var credentials = encoding.GetString(Convert.FromBase64String(auth));
                string username = credentials.Split(new char[] { ':' })[0];
                string password = credentials.Split(new char[] { ':' })[1];
                if(username == "admin" && password == "123")
                {
                    await _next(httpContext);
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }
            }
            else
            {
                httpContext.Response.StatusCode = 401;
                return;
            }
            /*return _next(httpContext);*/
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BasicAuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BasicAuthMiddleware>();
        }
    }
}

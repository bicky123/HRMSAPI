using HRMS.Comman.ApiResponse;
using System.Net;

namespace HRMS._Helpers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class APIKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string _apiKey = "hrms-key";

        public APIKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (!httpContext.Request.Headers.TryGetValue(_apiKey, out var value))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsJsonAsync(new Response((int)HttpStatusCode.Unauthorized, "Api Key not provided."));
                return;
            }

            var appSettings = httpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apiKeyValue = appSettings.GetValue<string>(_apiKey);
            if (!apiKeyValue.Equals(value))
            {
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsJsonAsync(new Response((int)HttpStatusCode.Unauthorized, "Unauthorized client."));
                return;
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class APIKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseAPIKeyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<APIKeyMiddleware>();
        }
    }
}

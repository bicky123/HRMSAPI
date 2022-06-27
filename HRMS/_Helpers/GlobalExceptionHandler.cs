using HRMS.Comman.ApiResponse;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace HRMS._Helpers
{
    public static class GlobalExceptionHandler
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsJsonAsync(new Response(context.Response.StatusCode, contextFeature.Error.Message));
                        //logger.LogError($"Error message: {contextFeature.Error.Message} & StackTrace: ${contextFeature.Error.StackTrace}");
                        return;
                    }
                    await context.Response.WriteAsJsonAsync(new Response(context.Response.StatusCode, "Some error occurs, contact to admin"));
                    return;
                });
            });
        }
    }
}

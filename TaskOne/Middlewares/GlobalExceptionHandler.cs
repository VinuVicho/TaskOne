using System.Net;
using System.Text.Json;
using TaskOne.Exceptions;

namespace TaskOne.Middlewares
{
    public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await WriteErrorMessage(context, e);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await WriteErrorMessage(context, e);
            }
        }

        private static async Task WriteErrorMessage(HttpContext context, Exception e)
        {
            context.Response.ContentType = "application/json";
            var jsonResponse = JsonSerializer.Serialize(new { e.Message });
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}

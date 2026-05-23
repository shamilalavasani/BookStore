
using System.Net;
using System.Text.Json;
namespace BookStore.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = ex switch
        {
            KeyNotFoundException => (int)HttpStatusCode.NotFound,           // 404
            ArgumentException => (int)HttpStatusCode.BadRequest,            // 400
            UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized, // 401
            InvalidOperationException => (int)HttpStatusCode.Conflict,       // 409
            NotImplementedException => (int)HttpStatusCode.NotImplemented,   // 501
            _ => (int)HttpStatusCode.InternalServerError                     // 500
        };
        var response = new
        {
            StatusCode = context.Response.StatusCode,
            Message = "An error occurred.",
            Detail = ex.Message
        };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

}

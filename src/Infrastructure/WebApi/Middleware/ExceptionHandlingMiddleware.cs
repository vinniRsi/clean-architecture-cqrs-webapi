using Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace WebApi.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            _logger.LogWarning(ex, "Not found: {Message}", ex.Message);
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await WriteResponseAsync(context, new { error = ex.Message });
        }
        catch (Application.Common.Exceptions.ValidationException ex)
        {
            _logger.LogWarning(ex, "Validation error");
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await WriteResponseAsync(context, new { errors = ex.Errors });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception");
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await WriteResponseAsync(context, new { error = "An unexpected error occurred." });
        }
    }

    private static Task WriteResponseAsync(HttpContext context, object body)
    {
        context.Response.ContentType = "application/json";
        return context.Response.WriteAsync(JsonSerializer.Serialize(body));
    }
}

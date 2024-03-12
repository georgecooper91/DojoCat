using DojoCat.Members.Common.Result;

namespace DojoCat.Members.Api.Middleware;

public class CancellationMiddleware
{
    private readonly RequestDelegate _next;
    public CancellationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try {
            await _next(context);
        } catch (TaskCanceledException e)
        {
            context.Response.StatusCode = 499;
            await context.Response.WriteAsJsonAsync("Request cancelled");
        }
    }
}

public static class CancellationMiddlewareExtension
{
    public static IApplicationBuilder UseCancellation(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CancellationMiddleware>();
    }
}

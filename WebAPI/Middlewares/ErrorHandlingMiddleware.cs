using Shared.Abstractions.Exceptions;
using WebAPI.Wrappers;

namespace WebAPI.Middlewares
{
    internal sealed class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (ApplicationUserException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new Response($"User exception. {ex.Message}", false));
            }
            catch (TabException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new Response($"Tab exception. {ex.Message}", false));
            }
            catch (DirectoryTabException ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new Response($"Directory exception. {ex.Message}", false));
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new Response(String.IsNullOrEmpty(ex.Message) ? "Something went wrong" : ex.Message, false));
            }
        }
    }
}

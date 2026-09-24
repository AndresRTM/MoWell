using Microsoft.AspNetCore.Mvc;
using MoWell.Exceptions;

namespace MoWell.Middleware
{
    public class GlobalExceptionMiddleware 
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) 
        {

            try
            {
                await _next(context);
            }

            catch(NotFoundException ex)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                var problemDetails = new ProblemDetails
                {
                    Title = "Not found",
                    Status = StatusCodes.Status404NotFound,
                    Detail = ex.Message
                };
                await context.Response.WriteAsJsonAsync(problemDetails);
            }


            catch(ArgumentException ex) 
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var problemDetails = new ProblemDetails
                {
                    Title = "Bad Request",
                    Status = StatusCodes.Status400BadRequest,
                    Detail = ex.Message
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }

            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var problemDetails = new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Status = StatusCodes.Status500InternalServerError,
                    Detail = "An unexpected error occurred"
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
        
    }
}

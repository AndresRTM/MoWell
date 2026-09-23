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
                    Status = StatusCodes.Status404NotFound,
                    Title = "Not found",
                    Detail = ex.Message
                };
            }

            catch(ArgumentException ex) 
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Title = "Vad Request",
                    Detail = ex.Message
                };
            }

            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Internal Server Error",
                    Detail = "Ett oväntat fel har inträffat"
                };

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
        
    }
}

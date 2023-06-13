using Newtonsoft.Json;
using System.Net;

namespace SCM_Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Invoke.
        /// </summary>
        /// <param name="context">context.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public async Task Invoke(HttpContext context)
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

        /// <summary>
        /// Handle Exception Async.
        /// </summary>
        /// <param name="context">context.</param>
        /// <param name="exception">exception.</param>
        /// <returns>Task.</returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Customize the response based on the exception
            // For example, you can set the response status code and return an error message
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var errorResponse = new
            {
                ErrorMessage = exception.Message,
                // Additional properties like stack trace, inner exceptions, etc.
            };

            // Serialize the error response to JSON
            var responseJson = JsonConvert.SerializeObject(errorResponse);

            return context.Response.WriteAsync(responseJson);

        }
    }
}

using WebApplication5.Exceptions;

namespace WebApplication5.RequestHandlers;

using System.Net;
using System.Text.Json;


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
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode;
            string errorType;
            string message = exception.Message;
            string details = exception.StackTrace;

            (statusCode, errorType) = exception switch
            {
                UnauthorizedException _ => (HttpStatusCode.Unauthorized, "Unauthorized"),
                ReasourceNotFound _ => (HttpStatusCode.NotFound, "Resource Not Found"),
                AlreadyHasSoftwareException _ => (HttpStatusCode.Conflict, "Already Has Software"),
                _ => (HttpStatusCode.InternalServerError, "Internal Server Error")
            };

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = new ErrorResponse
            {
                Error = errorType,
                Message = message,
                Details = details
            };

            var jsonResponse = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(jsonResponse);
        }

        private class ErrorResponse
        {
            public string Error { get; set; }
            public string Message { get; set; }
            public string Details { get; set; }
        }
    }

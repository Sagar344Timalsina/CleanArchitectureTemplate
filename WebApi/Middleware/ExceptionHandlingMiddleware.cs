using System.Net;
using System.Security;
using System.Text.Json;
using System.Text;
using ServiceLayer.Wrapper;

namespace WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate requestDelegate)
        {
            next = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception ex)
            {
                await this.HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = default(HttpStatusCode);

            object message = null;

            switch (exception)
            {
                case SecurityException security:
                    statusCode = HttpStatusCode.Forbidden;

                    message = new Response
                    {
                        Messages = "You shall not pass!"
                    };

                    break;
                case ArgumentException argumentInValid:
                    statusCode = HttpStatusCode.BadRequest;

                    message = new Response
                    {
                        Messages = argumentInValid.Message
                    };

                    break;

                case TaskCanceledException taskCanceled:
                default:
                    statusCode = HttpStatusCode.InternalServerError;

                    var defaultex = new Response
                    {
                        Messages = "Something is not right at our side. Please, call one of our developer "
                    };

                    defaultex.Messages = $"Exception: {exception.Message} - Inner: {exception.InnerException?.Message} - Stacktrace: {exception.StackTrace}";

                    message = defaultex;

                    break;
            }

            var result = JsonSerializer.Serialize(message);

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = (int)statusCode;

            await context.Response.WriteAsync(result, Encoding.UTF8);
        }
    }
}

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Wrapper;

namespace WebApi.Middleware
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = new ProblemDetails();
            problemDetails.Instance = httpContext.Request.Path;
            if(exception is BaseException e)
            {
                httpContext.Response.StatusCode = (int)e._StatusCode;
                problemDetails.Title = e.Message;
            }
            else
            {
                problemDetails.Title=exception.Message;
            }
            problemDetails.Status=httpContext.Response.StatusCode;
            var response = Response<string>.Fail(problemDetails.Title);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsJsonAsync(response,cancellationToken).ConfigureAwait(false);
            return true;
        }
    }
}

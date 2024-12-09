using System.Net;

namespace WebApi.Middleware
{
    public class BaseException:Exception
    {
        public HttpStatusCode _StatusCode { get; set; }
        public BaseException(string message,HttpStatusCode statusCode=HttpStatusCode.InternalServerError):base(message)
        {
            _StatusCode = statusCode;
        }
    }
}

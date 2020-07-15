using System.Net;

namespace Service.Exception
{
    public class RestException : System.Exception
    {
        public HttpStatusCode Code;
        public object Errors { get; }
        public RestException(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}

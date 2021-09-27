using System;
using System.Net;

namespace InterestCalcApi.Exceptions
{
    [Serializable]
    public class ApiExceptionBase : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public ApiExceptionBase(HttpStatusCode statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

    }
}

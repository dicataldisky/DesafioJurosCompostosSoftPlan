using System;
using System.Net;

namespace InterestTest.Models
{
    public class RequestResult<T>
    {
        public HttpStatusCode ResultCode { get; set; }
        public T Result { get; set; } = default;
        public Exception Exception { get; set; }

    }
}

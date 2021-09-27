using System;
using System.Net;

namespace InterestCalcApi.Exceptions
{
    [Serializable]
    public class BusinessException : ApiExceptionBase
    {
        public BusinessException(string message) : base( HttpStatusCode.ServiceUnavailable, message) { }
    }

}

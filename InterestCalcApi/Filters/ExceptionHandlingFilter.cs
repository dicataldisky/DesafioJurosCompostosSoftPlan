using InterestCalcApi.Exceptions;
using InterestCalcApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace InterestCalcApi.Filters
{
    public class ExceptionHandlingFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var response = new ApiResponse() { Message = "Erro interno", StatusCode = 500 };
            if (context.Exception is ApiExceptionBase ex)
            {
                response.Message = ex.Message;
                response.StatusCode = (int)ex.StatusCode;
            }
            else if (context.Exception is NotImplementedException notImplementedException)
            {
                response.Message = notImplementedException.Message;
                response.StatusCode = 400;
            }
            else if (context.Exception is NotSupportedException notSupportedException)
            {
                response.Message = notSupportedException.Message;
            }
            else
            {
                return;
            }
            context.Result = new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
            context.ExceptionHandled = true;
        }

    }
}

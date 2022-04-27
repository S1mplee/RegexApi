namespace RegexApi.Filters
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using RegexApi.Contracts.DTO;

    public class ServiceExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var error = new Error(
                Contracts.Enum.FailureReasonCode.None, 
                new string[] { "Something went wrong! Internal Server Error." });

            var objectResult = new ObjectResult(error);

            objectResult.StatusCode = 500;

            context.Result = objectResult;
        }
    }
}

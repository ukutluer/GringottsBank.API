using GringottsBank.Core.Entities.Base;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GringottsBank.API.Filters
{
    public class GringottsResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.Exception is null && context.Result is Microsoft.AspNetCore.Mvc.JsonResult)
            {
                var jsonResult = (Microsoft.AspNetCore.Mvc.JsonResult)context.Result;
                if(jsonResult.Value is BaseGringottsBankApiResponse)
                {
                    BaseGringottsBankApiResponse response = (BaseGringottsBankApiResponse)jsonResult.Value;
                    response.IsSuccess = true;
                    response.StatusCode = (int)HttpStatusCode.OK;
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}

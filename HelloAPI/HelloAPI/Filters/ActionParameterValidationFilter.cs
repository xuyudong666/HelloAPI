using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HelloAPI.Filters
{
    public class ActionParameterValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
            foreach (var parameter in descriptor.Parameters)
            {
                if(parameter.ParameterType == typeof(string))
                {
                    var argument = context.ActionArguments[parameter.Name];
                    if(argument.ToString().Contains(" "))
                    {
                        context.HttpContext.Response.Headers["X-ParameterValidation"] = "Fail";
                        context.Result = new BadRequestObjectResult($"不能包含空格:{parameter.Name}");
                        break;
                    }
                }
            }
            if(context.Result == null)
            {
                var resultContext = await next();

                context.HttpContext.Response.Headers["X-ParameterValidation"] = "Success";
            }
        }
    }
}

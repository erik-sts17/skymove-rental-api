using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SkyMove.Api.Filters
{
    public class ValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var arg in context.ActionArguments.Values)
            {
                if (arg == null) continue;

                var validatorType = typeof(IValidator<>).MakeGenericType(arg.GetType());
                var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

                if (validator != null)
                {
                    var result = validator.Validate(new ValidationContext<object>(arg));
                    if (!result.IsValid)
                    {
                        context.Result = new BadRequestObjectResult(result.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }));
                        return;
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}
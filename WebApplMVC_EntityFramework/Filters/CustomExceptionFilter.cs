using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplMVC_EntityFramework.Filters
{
    public class CustomExceptionFilter : Attribute, IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
           string actionName=context.ActionDescriptor.DisplayName;
           string exceptionStack =context.Exception.StackTrace;
           string exceptionMessage=context.Exception.Message;

            context.Result = new ContentResult
            {
                Content = $"В методі {actionName}\n" +
                  $"виникло виключення{exceptionMessage}\n" +
                  $"{exceptionStack}"
            };

          return Task.CompletedTask;
        }
    }
}

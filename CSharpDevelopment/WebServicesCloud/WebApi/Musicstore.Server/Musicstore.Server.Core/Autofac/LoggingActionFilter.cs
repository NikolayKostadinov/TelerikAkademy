using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac.Integration.WebApi;

namespace Musicstore.Server.Core.Autofac
{
    public class LoggingActionFilter : IAutofacActionFilter
    {
        readonly ILogger _logger;

        public LoggingActionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(HttpActionContext actionContext)
        {
            _logger.Write(actionContext.ActionDescriptor.ActionName);
        }

        public void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            _logger.Write(actionExecutedContext.ActionContext.ActionDescriptor.ActionName);
        }
    }
}

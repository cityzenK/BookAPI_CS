using Microsoft.AspNetCore.Mvc.Filters;

namespace BooksAPI.Filters
{
    public class ExceptionFilters: ExceptionFilterAttribute 
    {
        public readonly ILogger<ExceptionFilters> Logger;
        public ExceptionFilters(ILogger<ExceptionFilters> logger) {
            this.Logger= logger;   
        }

        public override void OnException(ExceptionContext context)
        {
            Logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);
        }
    }
}

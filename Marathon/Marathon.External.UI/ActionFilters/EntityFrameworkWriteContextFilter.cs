using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.Data.Common;

namespace Marathon.External.UI.ActionFilters
{
    public class EntityFrameworkWriteContextFilter : IActionFilter
    {
        public IContextProvider ContextProvider { get; set; }

        public EntityFrameworkWriteContextFilter(IContextProvider contextProvider)
        {
            this.ContextProvider = contextProvider;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ContextProvider.SaveChanges();
            ContextProvider.Dispose();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }
    }
}
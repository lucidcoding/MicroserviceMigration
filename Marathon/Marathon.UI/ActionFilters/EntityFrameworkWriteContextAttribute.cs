using System.Web;
using System.Web.Mvc;
using Marathon.Data.Common;
using Marathon.Data.Core;
using Ninject;

namespace Marathon.UI.ActionFilters
{
    public class EntityFrameworkWriteContextAttribute : ActionFilterAttribute
    {
        [Inject]
        public IContextProvider ContextProvider { get; set; }

        public EntityFrameworkWriteContextAttribute()
        {
            Order = 1000;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ContextProvider.SaveChanges();
            ContextProvider.Dispose();
        }
    }
}
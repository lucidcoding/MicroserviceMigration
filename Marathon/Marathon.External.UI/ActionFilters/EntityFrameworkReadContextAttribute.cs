using System.Web;
using System.Web.Mvc;
using Marathon.Data.Common;
using Marathon.Data.Core;
using Ninject;

namespace Marathon.External.UI.ActionFilters
{
    public class EntityFrameworkReadContextAttribute : ActionFilterAttribute
    {
        [Inject]
        public IContextProvider ContextProvider { get; set; }

        public EntityFrameworkReadContextAttribute()
        {
            Order = 1000;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ContextProvider.Dispose();
        }
    }
}
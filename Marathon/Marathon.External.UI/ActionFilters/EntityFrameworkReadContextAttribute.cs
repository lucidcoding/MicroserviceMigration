using System.Web;
using System.Web.Mvc;
using Marathon.Data.Common;
using Marathon.Data.Core;
using Ninject;

namespace Marathon.External.UI.ActionFilters
{
    public class EntityFrameworkReadContextAttribute : ActionFilterAttribute
    {
    }
}
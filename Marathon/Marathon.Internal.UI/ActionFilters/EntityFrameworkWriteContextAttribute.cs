﻿using System.Web;
using System.Web.Mvc;
using Marathon.Data.Common;
using Marathon.Data.Core;
using Ninject;

namespace Marathon.Internal.UI.ActionFilters
{
    public class EntityFrameworkWriteContextAttribute : ActionFilterAttribute
    {
    }
}
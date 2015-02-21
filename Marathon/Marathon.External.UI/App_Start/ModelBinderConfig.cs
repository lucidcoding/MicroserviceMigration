using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Marathon.External.UI.ModelBinders;

namespace Marathon.External.UI.App_Start
{
    public class ModelBinderConfig
    {
        public static void RegisterModelBinders(ModelBinderDictionary binder)
        {
            binder.Add(typeof(DateTime?), new DateModelBinder());
        }
    }
}
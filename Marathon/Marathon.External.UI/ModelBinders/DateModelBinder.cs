using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Marathon.External.UI.ModelBinders
{
    public class DateModelBinder : IModelBinder
    {
        /// <summary>
        /// Custom override of the BindModel method
        /// </summary>
        /// <param name="controllerContext">HTTP Request information encapsulated within an implementation of ControllerBase</param>
        /// <param name="bindingContext">Context in which the model is to be bound</param>
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            const string ValidationMessage = "Please enter a valid date";
            //const string dateFormatMask = "dd/MM/yyyy";
            var datePropertyName = bindingContext.ModelName;
            var dateDayPropertyName = bindingContext.ModelName + ".Day";
            var dateMonthPropertyName = bindingContext.ModelName + ".Month";
            var dateYearPropertyName = bindingContext.ModelName + ".Year";

            ////Attempt parsing if qualified value has been posted to controller
            //if (!string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form.Get(datePropertyName)))
            //{
            //    try
            //    {
            //        return DateTime.ParseExact(controllerContext.HttpContext.Request.Form.Get(datePropertyName), dateFormatMask, null);
            //    }
            //    catch (ArgumentOutOfRangeException)
            //    {
            //        //Append modelstate error and return prematurely if invalid range has been supplied
            //        bindingContext.ModelState.AddModelError(bindingContext.ModelName, ValidationMessage);
            //        return null;
            //    }
            //}

            //If constituent date values are all null, return prematurely
            if (string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form.Get(dateDayPropertyName))
            && string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form.Get(dateMonthPropertyName))
            && string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form.Get(dateYearPropertyName)))
            {
                return null;
            }

            //If constituent date values are only partially populated, append modelstate error and return.
            if (string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form.Get(dateDayPropertyName))
            || string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form.Get(dateMonthPropertyName))
            || string.IsNullOrEmpty(controllerContext.HttpContext.Request.Form.Get(dateYearPropertyName)))
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ValidationMessage);
                return null;
            }

            //Should the above have passed, construct a series of integer values representative of the selected date parameters
            var day = Convert.ToInt32(controllerContext.HttpContext.Request.Form.Get(dateDayPropertyName));
            var month = Convert.ToInt32(controllerContext.HttpContext.Request.Form.Get(dateMonthPropertyName));
            var year = Convert.ToInt32(controllerContext.HttpContext.Request.Form.Get(dateYearPropertyName));

            //Finally, parse the the provided date to a qualified datetime object
            try
            {
                return new DateTime(year, month, day);
            }
            catch (ArgumentOutOfRangeException) //Should the final date constructed be out of range, append modelstate error and return
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ValidationMessage);
                return null;
            }
        }
    }
}

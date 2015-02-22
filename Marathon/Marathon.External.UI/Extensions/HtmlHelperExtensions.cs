using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Globalization;

namespace Marathon.External.UI.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString BootstrapDatePickerFor<TModel, TProperty>(
             this HtmlHelper<TModel> htmlHelper,
             Expression<Func<TModel, TProperty>> expression)
        {
            var now = DateTime.Now;
            var dateCompilation = expression.Compile();
            var date = dateCompilation(htmlHelper.ViewData.Model) as DateTime?;
            string fullPropertyName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            var labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            string dayName = fullPropertyName + ".Day";
            string monthName = fullPropertyName + ".Month";
            string yearName = fullPropertyName + ".Year";
            //string yearName = !fullName ? fullPropertyName.Split('.').Last() + ".Year" : fullPropertyName + ".Year";

            var dayOptionsList = new List<object>();
            var monthOptionsList = new List<object>();
            var yearOptionsList = new List<object>();

            for (int dayIndex = 1; dayIndex <= 31; dayIndex++)
            {
                dayOptionsList.Add(new { Text = dayIndex.ToString(), Value = dayIndex.ToString() });
            }

            for(int monthIndex = 1; monthIndex <= 12; monthIndex ++)
            {
                monthOptionsList.Add(new { Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthIndex), Value = monthIndex.ToString() });
            }

            for(int yearIndex = 0; yearIndex < 10; yearIndex ++)
            {
                yearOptionsList.Add(new { Text = now.AddYears(yearIndex).Year.ToString(), Value = now.AddYears(yearIndex).Year.ToString() });
            }

            SelectList dayOptions = null;
            SelectList monthOptions = null;
            SelectList yearOptions = null;

            if (date.HasValue)
            {
                dayOptions = new SelectList(dayOptionsList, "Value", "Text", date.Value.Day.ToString()).AddDefaultOption();
                monthOptions = new SelectList(monthOptionsList, "Value", "Text", date.Value.Month.ToString()).AddDefaultOption();
                yearOptions = new SelectList(yearOptionsList, "Value", "Text", date.Value.Year.ToString()).AddDefaultOption();
            }
            else
            {
                dayOptions = new SelectList(dayOptionsList, "Value", "Text", null).AddDefaultOption();
                monthOptions = new SelectList(monthOptionsList, "Value", "Text", null).AddDefaultOption();
                yearOptions = new SelectList(yearOptionsList, "Value", "Text", null).AddDefaultOption();
            }

            var rowDiv = new TagBuilder("div");
            var dayDiv = new TagBuilder("div");
            var monthDiv = new TagBuilder("div");
            var yearDiv = new TagBuilder("div");
            rowDiv.AddCssClass("row date-picker-container");
            dayDiv.AddCssClass("col-sm-3");
            monthDiv.AddCssClass("col-sm-5");
            yearDiv.AddCssClass("col-sm-4");
            var dayAttributes = new Dictionary<string, object>();
            var monthAttributes = new Dictionary<string, object>();
            var yearAttributes = new Dictionary<string, object>();
            dayAttributes["class"] = "form-control date-picker-component date-picker-day";
            monthAttributes["class"] = "form-control date-picker-component date-picker-month";
            yearAttributes["class"] = "form-control date-picker-component date-picker-year";
            var dayDropDown = htmlHelper.DropDownList(dayName, dayOptions, null, dayAttributes);
            var monthDropDown = htmlHelper.DropDownList(monthName, monthOptions, null, monthAttributes);
            var yearDropDown = htmlHelper.DropDownList(yearName, yearOptions, null, yearAttributes);
            dayDiv.InnerHtml = dayDropDown.ToHtmlString();
            monthDiv.InnerHtml = monthDropDown.ToHtmlString();
            yearDiv.InnerHtml = yearDropDown.ToHtmlString();
            var validatorAttributes = new Dictionary<string, object>();
            validatorAttributes.Add("data-val", "true");
            validatorAttributes.Add("data-val-validdate", "The field " + labelText + " must be a valid date.");
            validatorAttributes.Add("class", "date-picker-validator");
            var validator = htmlHelper.Hidden(fullPropertyName, date.HasValue ? date.GetValueOrDefault().ToString("yyyy-MM-dd") : null, validatorAttributes);
            rowDiv.InnerHtml = dayDiv.ToString() + monthDiv.ToString() + yearDiv.ToString() + validator.ToHtmlString();
            var fullHtmlString = MvcHtmlString.Create(rowDiv.ToString());
            return fullHtmlString;
            ////Compile the provided expressions into a DateTime object
            //var dateCompilation = expression.Compile();
            //var date = dateCompilation(htmlHelper.ViewData.Model);
            //string fullPropertyName = htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            //var dateObj = date as DateTime?;

            ////Parse the received HTML attributes into a series of variables
            //var dayAttributes = new Dictionary<string, object>();
            //var monthAttributes = new Dictionary<string, object>();
            //var yearAttributes = new Dictionary<string, object>();

            ////If the readonly flag has been specified append the disabled attribute to each of the day/month/year selectors
            //if (readOnly)
            //{
            //    string fieldName = fullPropertyName + ".Date";
            //    string value = dateObj != null ? dateObj.GetValueOrDefault().ToString("dd/MM/yyyy") : string.Empty;
            //    return
            //        new MvcHtmlString(htmlHelper.Encode(value) + htmlHelper.HiddenFor(expression, new
            //        {
            //            Name = fieldName,
            //            Value = value
            //        }));
            //}

            ////Append internal CSS styling attributes
            //dayAttributes["class"] = "form-control ic-datepicker ic-datepicker-day";
            //monthAttributes["class"] = "form-control ic-datepicker ic-datepicker-month";
            //yearAttributes["class"] = "form-control ic-datepicker ic-datepicker-year";

            ////Get the individual values of the datetime by splitting the datetime by property
            //string dayName = !fullName ? fullPropertyName.Split('.').Last() + ".Day" : fullPropertyName + ".Day";
            //string monthName = !fullName ? fullPropertyName.Split('.').Last() + ".Month" : fullPropertyName + ".Month";
            //string yearName = !fullName ? fullPropertyName.Split('.').Last() + ".Year" : fullPropertyName + ".Year";

            //string dayId = !fullName ? fullPropertyName.Split('.').Last() + "_Day" : fullPropertyName + "_Day";
            //string monthId = !fullName ? fullPropertyName.Split('.').Last() + "_Month" : fullPropertyName + "_Month";
            //string yearId = !fullName ? fullPropertyName.Split('.').Last() + "_Year" : fullPropertyName + "_Year";

            ///*
            // * Declare div containers in which select boxes are to reside
            // * Due to a web-grid length of two causing readability issues for the month selector (i.e. full month name is cut-off by end of selector),
            // * the month selector has been given a web-grid value of 3
            // */
            //const string dayDivBegin = "<div class='col-xs-12 col-sm-4 date-padding'>";
            //const string monthDivBegin = "<div class='col-xs-12 col-sm-4 date-padding'>";
            //const string yearDivBegin = "<div class='col-xs-12 col-sm-4 date-padding'>";
            //const string divEnd = "</div>";

            ////Create select lists containing selectable day/month/year values
            //var day = dayDivBegin + htmlHelper.Label("Day", new { @class = "hidden", @for = dayId, aria_hidden = "true" }) + htmlHelper.DropDownList(dayName, SelectListExtensions.DayOptions(dateObj), dayAttributes) + divEnd;
            //var month = monthDivBegin + htmlHelper.Label("Month", new { @class = "hidden", @for = monthId, aria_hidden = "true" }) + htmlHelper.DropDownList(monthName, SelectListExtensions.MonthOptions(dateObj), monthAttributes) + divEnd;
            //var year = yearDivBegin + htmlHelper.Label("Year", new { @class = "hidden", @for = yearId, aria_hidden = "true" }) + htmlHelper.DropDownList(yearName, SelectListExtensions.YearOptions(dateObj, yearsToGoBack, futureYearsToBeAdded), yearAttributes) + divEnd;

            ////Conatenate (i.e. finalise) the date picker html string values into a single value for final presentation markup purposes
            //var datePickerString = "<div class=\"date-picker\">" + day + month + year + "</div>";
            //datePickerString = datePickerString.Replace("data-val=\"true\"", "");

            ////Calculate label text for nice validation messages.
            //string labelText = "";

            //if (string.IsNullOrEmpty(label))
            //{
            //    ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            //    string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            //    labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            //}
            //else
            //{
            //    labelText = label;
            //}

            ////Create the field to 
            //var validatorAttributes = new Dictionary<string, object>();
            //validatorAttributes.Add("class", "hidden-but-needs-validating validate-if-hidden");
            //validatorAttributes.Add("data-val", "true");
            ////validatorAttributes.Add("data-val-date", "The field '" + labelText + "' must be a valid date.");
            //validatorAttributes.Add("data-val-validdate", "The field '" + labelText + "' must be a valid date.");

            //if (required)
            //{
            //    validatorAttributes.Add("data-val-required", "The field '" + labelText + "' is required.");
            //}

            //if (ignoreDay)
            //{
            //    validatorAttributes.Add("data-ignore", "day");
            //}

            //var latestDate = DateTime.Now;
            //if (futureYearsToBeAdded > 0)
            //{
            //    latestDate = new DateTime(latestDate.Year + futureYearsToBeAdded, 12, 31);
            //}

            //var validatorName = !fullName ? fullPropertyName.Split('.').Last() + ".DateValidator" : fullPropertyName + ".DateValidator";
            //validatorAttributes.Add("data-val-datenotlaterthan", "The field '" + labelText + "' must not be later than " + latestDate.ToString("dd/MM/yyyy"));
            //validatorAttributes.Add("data-val-datenotlaterthan-date", latestDate.ToString("MM/dd/yyyy"));
            ////var validator = htmlHelper.Hidden("DateValidator", dateObj.HasValue ? dateObj.GetValueOrDefault().ToString("MM/dd/yyyy") : null, validatorAttributes);
            ////var validationMessage = htmlHelper.ValidationMessage("DateValidator");
            //var validator = htmlHelper.Hidden(validatorName, dateObj.HasValue ? dateObj.GetValueOrDefault().ToString("MM/dd/yyyy") : null, validatorAttributes);
            //var validationMessage = htmlHelper.ValidationMessage(validatorName);

            ////Create a div to contain any potential validation messages
            //var dateContainer = new TagBuilder("div");
            //dateContainer.AddCssClass("col-xs-12 col-sm-7 date-picker-container");
            //dateContainer.InnerHtml = validator + validationMessage.ToString() + datePickerString;

            ////Create an MVC html string using the combined values
            //var fullHtmlString = MvcHtmlString.Create(dateContainer.ToString());

            ////Return the MVC HTML string to the user
            //return fullHtmlString;
        }

		
    }
}
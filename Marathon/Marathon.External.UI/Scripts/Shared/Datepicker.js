Marathon.Shared.Datepicker = function () {

    var initialize = function () {

        //Gather all datepicker instances
        var datepickerComponent = $(".date-picker-component");

        //Attach function to the change event
        $(datepickerComponent).change(function () {

            //Navigate to parent container
            var datePickerContainer = $(this).parent().parent();

            //Get constituent components of date picker device
            var daySelect = $(datePickerContainer).find(".date-picker-day");
            var monthSelect = $(datePickerContainer).find(".date-picker-month");
            var yearSelect = $(datePickerContainer).find(".date-picker-year");

            //Get supplied values from components
            var selectedDayValue = daySelect.val();
            var selectedMonthValue = monthSelect.val();
            var selectedYearValue = yearSelect.val();

            //Find hidden control as unobtrusive validation is being done on this.
            var hiddenControlToValidate = $(datePickerContainer).find(".date-picker-validator").first();

            //Check whether a full date has been supplied
            var completeDateEntryPresent = selectedDayValue != null && selectedDayValue != "" && selectedDayValue != undefined
                                           && selectedMonthValue != null && selectedMonthValue != "" && selectedMonthValue != undefined
                                           && selectedYearValue != null && selectedYearValue != "" && selectedYearValue != undefined;

            //If a full date is present invoke client-side validation on the date picker device
            if (completeDateEntryPresent) {

                //Construct a month offset in recognition of differences between MVC & JS dates starting at 0 and 1, respectively
                var monthOffset = selectedMonthValue - 1;

                //Construct a javascript date object using the offset value for comparison purposes 
                var userSelectedDate = new Date(selectedYearValue, monthOffset, selectedDayValue);

                //Set value in hidden validation field, so unobtrusive validation can be done on it.
                selectedMonthValue = ("0" + selectedMonthValue);
                selectedMonthValue = selectedMonthValue.substr(selectedMonthValue.length - 2);
                selectedDayValue = ("0" + selectedDayValue);
                selectedDayValue = selectedDayValue.substr(selectedDayValue.length - 2);
                var dateFormat = selectedYearValue + "-" + selectedMonthValue + "-" + selectedDayValue;
                hiddenControlToValidate.val(dateFormat);

            } else {
                hiddenControlToValidate.val("");
            }
        });
    };

    var setupValidators = function () {

        $.validator.addMethod("validdate", function (currVal, element) {

            //Do not attempt to validate if not set.
            if (currVal == '' || currVal == null || currVal == undefined)
                return true;


            //Declare Regex 
            var rxDatePattern = /^(\d{4})(-)(\d{2})(-)(\d{2})$/;
            var dtArray = currVal.match(rxDatePattern); // is format OK?

            if (dtArray == null)
                return false;

            //Checks for yyyy-mm-dd format.
            dtDay = dtArray[5];
            dtMonth = dtArray[3];
            dtYear = dtArray[1];

            if (dtMonth < 1 || dtMonth > 12)
                return false;
            else if (dtDay < 1 || dtDay > 31)
                return false;
            else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31)
                return false;
            else if (dtMonth == 2) {
                var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));

                if (dtDay > 29 || (dtDay == 29 && !isleap))
                    return false;
            }

            return true;
        });

        $.validator.unobtrusive.adapters.addBool("validdate");

        $.validator.addMethod("notinpast", function (value, element, params) {
            var today = new Date().setHours(0, 0, 0, 0);
            return Date.parse(value) >= today;
        });

        $.validator.unobtrusive.adapters.addBool("notinpast");

        $.validator.addMethod("notlaterthan", function (value, element, params) {
            return Date.parse(value) <= Date.parse(params);
        });

        $.validator.unobtrusive.adapters.add("notlaterthan", ["date"], function (options) {
            options.rules["notlaterthan"] = options.params.date;
            options.messages["notlaterthan"] = options.message;
        });
    };

    return {
        initialize: initialize,
        setupValidators: setupValidators
    };
} ();

(function ($) {
    Marathon.Shared.Datepicker.setupValidators();
} (jQuery));

$(document).ready(function () {
    Marathon.Shared.Datepicker.initialize();
});
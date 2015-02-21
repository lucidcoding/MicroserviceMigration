Marathon = {};
Marathon.Layout = {};
Marathon.Customer = {};
Marathon.Booking = {};
Marathon.Shared = {};

Marathon.Shared.Layout = function () {

    var initialize = function () {
        $("form").each(function (index, element) {
            var validators = $(element).data("validator");
            validators.settings.ignore = ":hidden:not(.date-picker-container:visible .date-picker-validator)";
        });
    };

    return {
        initialize: initialize,
    };
} ();

$(document).ready(function () {
    Marathon.Shared.Layout.initialize();
});

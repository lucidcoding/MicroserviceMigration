Marathon = {};
Marathon.Booking = {};
Marathon.Invoice = {};

Marathon.Layout = function () {

    var initialize = function () {

        $('.input-group.date').datepicker({
            format: 'dd/mm/yyyy'
        });
    };

    return { initialize: initialize };
} ();


$(document).ready(function () {
    Marathon.Layout.initialize();
});
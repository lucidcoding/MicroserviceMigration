Marathon.Booking.Collect = function () {

    var initialize = function () {
        $('#getSummaryLink').click(function (event) {
            event.preventDefault();
            var bookingNumber = $("#BookingNumber").val();

            $.ajax({
                url: "GetSummary",
                data: "bookingNumber=" + bookingNumber,
                type: "GET",
                success: function (result) {
                    $("#summaryDiv").html(result);
                    //initialize();
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    alert('error: ' + jqXhr + ', ' + textStatus + ', ' + errorThrown);
                }
            });
        });
    };

    return { initialize: initialize };
} ();


$(document).ready(function () {
    Marathon.Booking.Collect.initialize();
});
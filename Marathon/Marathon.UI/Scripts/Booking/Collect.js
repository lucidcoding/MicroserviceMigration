Marathon.Booking.Collect = function () {

    var initialize = function () {
        $('#getCollectDetailsLink').click(function (event) {
            event.preventDefault();
            var bookingNumber = $("#BookingNumber").val();

            $.ajax({
                url: "GetCollectDetails",
                data: "bookingNumber=" + bookingNumber,
                type: "GET",
                success: function (result) {
                    $("#collectDetailsDiv").html(result);
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
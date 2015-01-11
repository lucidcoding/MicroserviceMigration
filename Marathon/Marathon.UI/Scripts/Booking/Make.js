Marathon.Booking.Make = function () {

    var initialize = function () {

        var datepickerParameters = {
            dateFormat: 'dd/mm/yy'
        };

        $('.input-group.date').datepicker({
            format: 'dd/mm/yyyy'
        });

        $('#VehicleId').change(function (event) {
            event.preventDefault();

            var vehicleId = $('#VehicleId').val();

            if (vehicleId == "" || vehicleId == null)
            {
                $("#pendingBookingsForVehicleDiv").empty();
            }
            else
            {
                $.ajax({
                    url: "GetPendingForVehicle",
                    data: "vehicleId=" + vehicleId,
                    type: "GET",
                    success: function (result) {
                        $("#pendingBookingsForVehicleDiv").html(result);
                        //initialize();
                    },
                    error: function (jqXhr, textStatus, errorThrown) {
                        alert('error: ' + jqXhr + ', ' + textStatus + ', ' + errorThrown);
                    }
                });
            }
        });

        //        var datepickerParameters = {
        //            firstDay: 1,
        //            dateFormat: 'dd/mm/yy',
        //            showOn: "button",
        //            defaultDate: new Date(),
        //            beforeShowDay: function (date) {
        //                var day = date.getDay();

        //                if (day == 1 || day == 5) {
        //                    return [true];
        //                } else {
        //                    return [false];
        //                }
        //            }/*,
        //            buttonImage: "/Content/Images/CalendarIcon.png"
        //            ,
        //            buttonImageOnly: true*/
        //        };

        //$("#StartDate").datepicker(datepickerParameters);
        //$("#EndDate").datepicker(datepickerParameters);

        //        $("#IsMainDriver").change(function (event) {
        //            if (this.checked == true) {
        //                $(".alternate-driver").addClass("hide");
        //            } else {
        //                $(".alternate-driver").removeClass("hide");
        //            }
        //        });
    };

    return { initialize: initialize };
} ();


$(document).ready(function () {
    Marathon.Booking.Make.initialize();
});
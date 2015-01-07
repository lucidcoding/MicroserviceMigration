Marathon.Customer.Register = function () {

    var initialize = function () {


//        document.getElementById("UserName").setCustomValidity("Testing");

//        function validatePassword() {
//            if ($("#Password").val() != $("#ConfirmPassword").val()) {
//                $("#ConfirmPassword")[0].setCustomValidity("Passwords Don't Match");
//                document.getElementById("ConfirmPassword").setCustomValidity("Passwords don't match");
//            } else {
//                $("#ConfirmPassword")[0].setCustomValidity('');
//            }
//        }

//        $("#Password").change(validatePassword);
//        $("#ConfirmPassword").keyup(validatePassword);

    };

    return { initialize: initialize };
} ();


$(document).ready(function () {
    Marathon.Customer.Register.initialize();
});
$(document).ready(function () {
    $("#btnOK").click(function (e) {
        window.location = "/BMI/NewPerson";
        e.stopPropagation();
    });
});
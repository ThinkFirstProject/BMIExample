$(document).ready(function() {
    $("#btnNewPerson").click(function (e) {
        window.location = "/BMI/NewPerson";
        e.stopPropagation();
    });
});
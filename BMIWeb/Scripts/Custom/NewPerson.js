$(document).ready(function() {
    $("#birthDate").datepicker({ dateFormat: 'dd-mm-yy' });
    $("#measurementDate").datepicker({ dateFormat: 'dd-mm-yy' });

    $("#btnCancel").click(function(e) {
        window.location = "/BMI/Overview";
        e.stopPropagation();
    });
});
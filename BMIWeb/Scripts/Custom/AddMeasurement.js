$(document).ready(function () {
    $("#measurementDate").datepicker({ dateFormat: 'dd-mm-yy' });
    
    $("#btnCancel").click(function (e) {
        window.location = "/BMI/Overview";
        e.stopPropagation();
    });
});
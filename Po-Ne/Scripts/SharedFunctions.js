$(document).ready(function () {
    WireButtons();
});

function WireButtons() {
    $("#btnFindOpinion").click(function() {
        var dataParm = $("#inSearch").val();
        ajaxPost("Home/RetrieveWatsonFeedback", dataParm, function (result) {
            $("#Result").text('Result: ' + result);
        });
    });

}

function ajaxPost(action, dataParm, Successfunc) {
    $.ajax({
        type: 'POST',
        url: RootPath + action,
        data: JSON.stringify({'dataRequest':dataParm}),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: Successfunc
    });
}
$(document).ready(function () {
    WireButtons();
});

function WireButtons() {
    $("#btnFindOpinion").click(function() {
        var dataParm = $("#inSearch").val();
        ajaxPost("Home/RetrieveWatsonFeedback", dataParm, function (result) {
            result = Math.round((result * 100) * 100) / 100;
            var resultProgressString = '<br/><div class="progress">' +
            '<div class="progress-bar" role="progressbar" aria-valuenow="' + result + '" ' +
            'aria-valuemin="0" aria-valuemax="100" style="width:'+result+'%">' +
           result + '% IBM Watson Approval </div></div>';

            $("#Result").html(resultProgressString);
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
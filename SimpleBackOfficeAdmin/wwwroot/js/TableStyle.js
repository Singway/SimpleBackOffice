
function DefaultStyle() {
    $(".table").removeClass("table-striped");
    $(".table").addClass("table-hover");
}
function StripedStyle() {
    $(".table").removeClass("table-hover");
    $(".table").addClass("table-striped");
}
function Detail(uniqueId) {
    $("#Detail_" + uniqueId).modal();
};
$("#Search").on('click', function () {
    var name = $("#searchName").val();
    $("table tbody tr").hide()
        .filter(":contains('" + name + "')")
        .show();
});
$(function () {
    var lines = $("table").find("tr").length-1;
    var info = "<br/><h4>本页共 " + lines + " 行数据</h4>";
    $("table").after(info);
});

$(function () {
    var _id = $("#errorId").val();
    if (!!_id) {
        $("#edit_" + _id).modal();
        $("#errorMessage_" + _id).removeAttr("hidden");
    }
});
$("#add").click(function () {
    $("#create").modal();
});
function Edit(uniqueId) {
    $("#edit_" + uniqueId).modal();
};
function AllotUser(uniqueId) {
    $("#allotUser_" + uniqueId).modal();
};
function AllotDept(uniqueId) {
    $("#allotDept_" + uniqueId).modal();
};
function confirmDelete(uniqueId, openOrClose) {
    var normalSpan = "normalSpan_" + uniqueId;
    var confirmSpan = "confirmSpan_" + uniqueId;
    if (openOrClose) {
        $("#" + normalSpan).hide();
        $("#" + confirmSpan).show();
    } else {
        $("#" + normalSpan).show();
        $("#" + confirmSpan).hide();
    }
}
function EditPosi(uniqueId) {
    var posi = $("#position_" + uniqueId).find('option:selected').val();
    $("#posi_" + uniqueId).val(posi);
};
function EditSub(uniqueId) {
    var sub = $("#subordinate_" + uniqueId).find('option:selected').val();
    $("#sub_" + uniqueId).val(sub);
};
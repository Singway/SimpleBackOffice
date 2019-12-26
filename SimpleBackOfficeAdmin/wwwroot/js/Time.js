
$(function () {
    var acc = $("#account").val();
    if (!!acc) {
        $("#info").append(acc);
    }
});
function startTime() {
    var today = new Date();
    var h = today.getHours();
    var m = today.getMinutes();
    var s = today.getSeconds();// 在小于10的数字前加一个‘0’
    h = checkTime(h);
    m = checkTime(m);
    s = checkTime(s);
    document.getElementById('time').innerHTML = h + ":" + m + ":" + s;
    t = setTimeout(function () { startTime() }, 500);
}
function checkTime(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}
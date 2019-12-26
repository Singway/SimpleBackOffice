
var prov = "";
var city = "";

$(function () {
    provices.forEach(provice => {
        var option = document.createElement("option");
        $(option).val(provice.name);
        $(option).text(provice.name)
        $(".prov").append(option);
    })
});

function showCity(uniqueId) {
    $("#addr_" + uniqueId).attr("value", "")
    $("#submit_" + uniqueId).attr("disabled", true);
    $("#citySpan_" + uniqueId).text("请选择城市");
    prov = $("#prov_" + uniqueId).find('option:selected').val();
    var index = $("#prov_" + uniqueId).get(0).selectedIndex - 1;
    $("#city_" + uniqueId).empty();
    var option = document.createElement("option");
    $(option).text("=请选择城市=")
    $("#city_" + uniqueId).append(option);
    provices[index].city.forEach(ci => {
        var option = document.createElement("option");
        $(option).val(ci.name);
        $(option).text(ci.name)
        $("#city_" + uniqueId).append(option);
    });
}

function putValue(uniqueId) {
    city = $("#city_" + uniqueId).find('option:selected').val();
    if (city == "=请选择城市=") {
        $("#citySpan_" + uniqueId).text("请选择城市");
        return;
    }
    if (prov == city) {
        $("#addr_" + uniqueId).val(city);
    }
    else {
        $("#addr_" + uniqueId).val(prov + city);
    }
    $("#submit_" + uniqueId).attr("disabled", false);
    $("#citySpan_" + uniqueId).text("");
}


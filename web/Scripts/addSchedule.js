$(window).load(function () {
    GetPlants();
});

function GetPlants() {
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        type: 'GET',
        url: 'http://localhost:56710/api/Plant',
        beforeSend: function (xhr) {

        },
        contentType: 'application/json; charset=utf-8',
    }).success(function (data) {
        console.log(data);
        var innerHtml = GenerateHtml(data);
        $("#plant-select").empty();
        $("#plant-select").append(innerHtml);
        GetResources();
    }).fail(function (data) {
        console.log(data);
    }).done(function (data) {

    });
};

function GetResources() {
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        type: 'GET',
        url: 'http://localhost:56710/api/Resource',
        beforeSend: function (xhr) {

        },
        contentType: 'application/json; charset=utf-8',
    }).success(function (data) {
        console.log(data);
        var innerHtml = GenerateHtmlAdvanced(data);
        $("#resource-select").empty();
        $("#resource-select").append(innerHtml);
        crear_select();
    }).fail(function (data) {
        console.log(data);
    }).done(function (data) {

    });
};

function GenerateHtml(data) {
    var result = "";
    for (var i = 0; i < data.length; i++) {
        result += "<option value='" + data[i].Id + "'>" + data[i].Name + "</option>";
    }
    return result;
}

function GenerateHtmlAdvanced(data){
    var result = "";
    for (var i = 0; i < data.length; i++) {
        var measure = "";
        if (data[i].Measure == 'l' || data[i].Measure == 'ml'){
            measure = 'milliliters';
        }
        if (data[i].Measure == 'g' || data[i].Measure == 'kg'){
            measure = 'grams';
        }
        if (data[i].Measure == 'amp'){
            measure = 'ampoules';
        }
        if (data[i].Measure == 'pack'){
            measure = 'packs';
        }
        result += "<option value='" + data[i].Id + "'>" + data[i].Name + ", " + measure + "</option>";
    }
    return result;
}

$(function () {
    $('#add-button').click(function (e) {
        e.preventDefault();
        var data = {
            PlantId: $('#plant-select').val(),
            ResourceId: $('#resource-select').val(),
            Interval: $('#schInterval').val(),
            Amount: $('#schAmount').val(),
            LastTimeDone: $('#schLastTime').val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56710/api/Schedule',
            xhrFields: { withCredentials: true },
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data)
        }).success(function (data) {
            location.href = "./schedules.html";
        }).fail(function (data) {
            console.log(data);
        });
    });
});
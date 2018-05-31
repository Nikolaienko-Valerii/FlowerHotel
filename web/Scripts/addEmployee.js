$(window).load(function () {
    GetHotels();
});

function GetHotels() {
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        type: 'GET',
        url: 'http://localhost:56710/api/Hotel',
        beforeSend: function (xhr) {

        },
        contentType: 'application/json; charset=utf-8',
    }).success(function (data) {
        console.log(data);
        var innerHtml = GenerateHtml(data);
        $("#hotel-select").empty();
        $("#hotel-select").append(innerHtml);
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

$(function () {
    $('#add-button').click(function (e) {
        e.preventDefault();
        var data = {
            hotelId: $('#hotel-select').val(),
            Email: $('#empEmail').val(),
            Password: $('#empPassword').val(),
            ConfirmPassword: $('#empConfirmPassword').val(),
            PhoneNumber: $('#empPhoneNumber').val(),
            Name: $('#empName').val(),
            Surname: $('#empSurname').val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56710/Account/Register',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data)
        }).success(function (data) {
            location.href = "./employees.html";
        }).fail(function (data) {
            alert("В процесе регистрации возникла ошибка");
        });
    });
});


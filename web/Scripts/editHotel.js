$(window).load( function () {
    var id = sessionStorage.getItem('hotelId');
    GetHotel(id);
});

function GetHotel(id) {
    var urlString = 'http://localhost:56710/api/Hotel/' + id;
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        type: 'GET',
        url: urlString,
        beforeSend: function (xhr) {
             
            var cookie = document.cookie;
            //xhr.setRequestHeader("Cookie", cookie);
        },
        contentType: 'application/json; charset=utf-8',
    }).success(function (data) {
        console.log(data);
        fillFields(data);
    }).fail(function (data) {
        console.log(data);
    });
}

function fillFields(data){
    document.getElementById('hotelId').value = data.Id;
    document.getElementById('hotelName').value = data.Name;
    document.getElementById('hotelLocation').value = data.Location;
    document.getElementById('hotelAmount').value = data.AmountOfPlaces;
}

$(function () {
    $('#editHotelButton').click(function (e) {
        e.preventDefault();
        var hotelData = {
            Id: $('#hotelId').val(),
            Name: $('#hotelName').val(),
            Location: $('#hotelLocation').val(),
            AmmountOfPlaces: $('#hotelAmount').val()
        };

        $.ajax({
            type: 'PUT',
            url: 'http://localhost:56710/api/Hotel',
            xhrFields: { withCredentials: true },
            data: hotelData
        }).success(function (data, status, xhr) {
            console.log(xhr);
        }).fail(function (data) {
            console.log('------------');
            console.log(data);
        }).done(function (data) {
            sessionStorage.removeItem('hotelId');
            location.href = './hotels.html';
        });
    });
});
$(function () {
    $('#addHotelButton').click(function (e) {
        e.preventDefault();
        var hotelData = {
            Name: $('#hotelName').val(),
            Location: $('#hotelLocation').val(),
            AmmountOfPlaces: $('#hotelAmount').val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56710/api/Hotel',
            xhrFields: { withCredentials: true },
            data: hotelData
        }).success(function (data, status, xhr) {
            console.log(xhr);
        }).fail(function (data) {
            console.log('------------');
            console.log(data);
        });
    });
});
$(function () {
    $('#add-button').click(function (e) {
        e.preventDefault();
        var hotelData = {
            Name: $('#plantName').val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56710/api/Plant',
            xhrFields: { withCredentials: true },
            data: hotelData
        }).success(function (data, status, xhr) {
            location.href = "./plants.html";
        }).fail(function (data) {
            console.log('------------');
            console.log(data);
        });
    });
});
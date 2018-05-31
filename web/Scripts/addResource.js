$(window).load(function () {
    crear_select();
});

$(function () {
    $('#add-button').click(function (e) {
        e.preventDefault();
        var resourceData = {
            Name: $('#resName').val(),
            Measure: $('#measure-select').val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56710/api/Resource',
            xhrFields: { withCredentials: true },
            data: resourceData
        }).success(function (data, status, xhr) {
            location.href = "./resources.html";
        }).fail(function (data) {
            console.log('------------');
            console.log(data);
        });
    });
});
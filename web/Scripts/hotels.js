$(window).load( function () {
    loadInfo();
});

function getCookie(name) {
    var matches = document.cookie.match(new RegExp(
      "(?:^|; )" + name.replace(/([\.$?*|{}\(\)\[\]\\\/\+^])/g, '\\$1') + "=([^;]*)"
    ));
    return matches ? decodeURIComponent(matches[1]) : undefined;
  };

function loadInfo()
{
    var hash = location.hash;
    if (hash == "") 
    {
        GetHotels();
    }
    else
    {
    }
};

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
        $(".page-container").empty();
        $(".page-container").append(innerHtml);
        EnableEditButtons();
    }).fail(function (data) {
        console.log(data);
    }).done(function (data) {
        
    });
}

function GenerateHtml(data){
    var result = "";
    for (var i = 0; i < data.length; i++) {
        result += "<div class='hotel-container'><p class='hotel-name'>" + data[i].Name + "</p><p class='hotel-location'>Location: " + data[i].Location + "</p><p class='hotel-free'>Free places: " + data[i].PlacesAvailable + "/" + data[i].AmountOfPlaces + "</p><button class='edit-button' id='" + data[i].Id + "' >Edit</button></div>";
    }
    result += "<button class='add-button'>Add new hotel</button>";
    return result;
}

function EnableEditButtons () {
    $(".edit-button").click(function () {
        var hotelId = $(this).attr('id');
        sessionStorage.setItem('hotelId', hotelId);
        window.location.href = './edit-hotel.html';
    });
    $(".add-button").click(function () {
        window.location.href = './add-hotel.html';
    });
};
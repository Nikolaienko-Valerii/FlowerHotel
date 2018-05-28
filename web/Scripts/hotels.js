$(window).load( function () {
    loadInfo();
});

$(window).on('hashchange', function() {
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
             
            var cookie = document.cookie;
            //xhr.setRequestHeader("Cookie", cookie);
        },
        contentType: 'application/json; charset=utf-8',
    }).success(function (data) {
        console.log(data);
    }).fail(function (data) {
        console.log(data);
    });
}
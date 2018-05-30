var url = '';

function CheckAuthorization() {
    var cookie = document.cookie;
    var currentLocation = location.href;
    var isOnLoginPage = false;
    if (currentLocation.includes('login.html')) {
        isOnLoginPage = true;
    }
    if (cookie != "") {
        $('.username').empty();
        $('.username').append(sessionStorage.getItem('user'));
        CheckRole();
    }
    else {
        if (!isOnLoginPage) {
            location.replace(url + '../login.html')
        }
    }
}

function CheckRole() {
    var isOnLoginPage = false;
    if (location.href.includes('login.html')) {
        isOnLoginPage = true;
    }
    if (!isOnLoginPage){
        url = '../';
    }
    var role = sessionStorage.getItem('role');
    var currentLocation = location.href;
    switch (role) {
        case 'user':
            if (!IsUserHere('user')) {
                location.replace(url + 'user/plants.html');
            }
            break;
        case 'employee':
            if (!IsUserHere('employee')) {
                location.replace(url + 'employee/schedules.html');
            }
            break;
        case 'admin':
            if (!IsUserHere('admin')) {
                location.replace(url + 'admin/hotels.html');
            }
            break;
    }
}

function IsUserHere(pathPart) {
    var query = pathPart + '/';
    return location.href.includes(query);
}

CheckAuthorization();

$(".logout-button").click(function () {
    
    Logout();
});

function Logout() {
    $.ajax({
        xhrFields: {
            withCredentials: true
        },
        type: 'POST',
        url: 'http://localhost:56710/Account/Logout',
        contentType: 'application/json; charset=utf-8',
    }).success(function (data) {
        }).fail(function (data) {
    }).done(function (data) {
        sessionStorage.removeItem('user');
        sessionStorage.removeItem('role');
        location.replace("../login.html");
        location.reload();
    });
}
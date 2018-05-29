var url = '';

function CheckAuthorization() {
    var cookie = document.cookie;
    var currentLocation = location.href;
    var isOnLoginPage = false;
    if (currentLocation.includes('login.html')) {
        isOnLoginPage = true;
    }
    if (cookie != "") {
        CheckRole();
    }
    else {
        if (!isOnLoginPage) {
            location.replace(url + '../login.html')
        }
    }
}

function CheckRole() {
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
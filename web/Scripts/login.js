$('.message a').click(function(){
   $('form').animate({height: "toggle", opacity: "toggle"}, "slow");
});

$(function () {
    var tokenKey = "tokenInfo";
    $('#submitLogin').click(function (e) {
        e.preventDefault();
        var loginData = {
            Email: $('#emailLogin').val(),
            Password: $('#passwordLogin').val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56710/Account/Login',
            xhrFields: { withCredentials: true },
            data: loginData
        }).success(function (data, status, xhr) {
            sessionStorage.setItem("user", data.UserName);
            sessionStorage.setItem("role", data.Role);
            CheckAuthorization();
        }).fail(function (data) {
            alert('При логине возникла ошибка');
        });
    });
});

$(function () {
    $('#registerButton').click(function (e) {
        e.preventDefault();
        var data = {
            Email: $('#regEmail').val(),
            Password: $('#regPassword').val(),
            ConfirmPassword: $('#regConfirmPassword').val(),
            PhoneNumber: $('#regPhoneNumber').val(),
            Name: $('#regName').val(),
            Surname: $('#regSurname').val()
        };

        $.ajax({
            type: 'POST',
            url: 'http://localhost:56710/Account/Register',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data)
        }).success(function (data) {
            window.location.replace("./Login.html");
        }).fail(function (data) {
            alert("В процесе регистрации возникла ошибка");
        });
    });
});
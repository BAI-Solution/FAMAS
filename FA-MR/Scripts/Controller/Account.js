_app.controller("AccountCtrl", function ($scope) {
    $scope.Account = {
        SignIn: function (pId, pURI) {
            window.location.href = "https://login.microsoftonline.com/common/oauth2/v2.0/authorize?client_id=" + pId + "&redirect_uri=" + pURI + "&response_type=code&scope=user.read%20mail.read";
        }
    };
});
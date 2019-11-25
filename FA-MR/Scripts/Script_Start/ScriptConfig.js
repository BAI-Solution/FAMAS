var _app = angular.module("script_start", ["ngMaterial", "ngMessages", "ngRoute"]);
_app.config(function ($routeProvider, $locationProvider, $mdThemingProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "Template/FixedAssets.html",
            controller: "FixedAssetsCtrl"
        })
        .when("/FixedAssets", {
            templateUrl: "Template/FixedAssets.html",
            controller: "FixedAssetsCtrl"
        })
        .when("/AssignedAssets", {
            templateUrl: "Template/AssignedAssets.html",
            controller: "AssignedAssetsCtrl"
        })
        .when("/Disposed", {
            templateUrl: "Template/Disposed.html",
            controller: "DisposedCntrl"
        })
        .when("/FixedAssetsMovement", {
            templateUrl: "Template/FixedAssetsMovement.html",
            controller: "FixedAssetsMovementCntrl"
        });
    $locationProvider.html5Mode(false).hashPrefix("!");
    //Theme Configuration
    $mdThemingProvider.definePalette('primaryPalette', {
        "50": "4682b4",
        "100": "4682b4",
        "200": "4682b4",
        "300": "4682b4",
        "400": "4682b4",
        "500": "4682b4",
        "600": "4682b4",
        "700": "4682b4",
        "800": "4682b4",
        "900": "4682b4",
        "A100": "a3c2db",
        "A200": "4682b4",
        "A400": "4682b4",
        "A700": "4682b4",
        "contrastDefaultColor": "light",    // whether, by default, text (contrast)
        // on this palette should be dark or light
        'contrastDarkColors': ["50"], //hues which contrast should be 'dark' by default
        'contrastLightColors': ["50"]    // could also specify this if default was 'dark'
    });
    $mdThemingProvider.definePalette('warnPalette', {
        "50": "bd2130",
        "100": "bd2130",
        "200": "bd2130",
        "300": "bd2130",
        "400": "bd2130",
        "500": "bd2130",
        "600": "bd2130",
        "700": "bd2130",
        "800": "bd2130",
        "900": "bd2130",
        "A100": "bd2130",
        "A200": "bd2130",
        "A400": "bd2130",
        "A700": "bd2130",
        "contrastDefaultColor": "light",    // whether, by default, text (contrast)
        // on this palette should be dark or light
        'contrastDarkColors': ["50"], //hues which contrast should be 'dark' by default
        'contrastLightColors': ["50"]    // could also specify this if default was 'dark'
    });
    $mdThemingProvider.theme("default")
        .primaryPalette("primaryPalette", {
            "hue-1": "A100"
        })
        .warnPalette("warnPalette");
    //Jquery Config
    $.noConflict();
});
_app.controller("MainCtrl", function ($scope, $rootScope, $location, Dialog) {
    //Location
    $scope.location = $location.path();
    $rootScope.$on('$routeChangeSuccess', function () {
        $scope.location = $location.path();
    });
    //Dialog
    $scope.$on("Dialog", function (pEv, pData) {
        if ("Error" === pData.type)
            Dialog.Error(pData, $scope);
        else if ("Success" === pData.type)
            Dialog.Success(pData, $scope);
        else if ("BWorker" === pData.type)
            Dialog.BWorker(pData, $scope);
        else if ("Modal" === pData.type)
            Dialog.Modal(pData.ev, $scope, pData.IdName);
    });
    //Logout
    $scope.Account = {
        Load: function (pUser) {
            $scope.UserLog = pUser;
        },
        Logout: function () {
            window.location.href = "/Account/Logout";
        }
    };
});
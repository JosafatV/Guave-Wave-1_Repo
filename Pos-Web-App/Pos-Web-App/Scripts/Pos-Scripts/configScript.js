﻿angular.module('DrPhischelApp').config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    /*.when('/DrPhischel/Login/CrearPerfil', {
        templateUrl: 'Login/creacionUsuario.html',
        controller: 'creacionUsuarioController'
    })*/
    .otherwise({
        templateUrl: 'Login/login.html',
        controller: 'loginController'
    })
}]);

/*
angular.module('DrPhischelApp').config(function ($httpProvider) {
    //$httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.useXDomain = true;
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8';
    //$httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
    //$httpProvider.defaults.withCredentials = true;
    //delete $httpProvider.defaults.headers.common["X-Requested-With"];
    //$httpProvider.defaults.headers.common = {};
    /*$httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.put = {};
    $httpProvider.defaults.headers.patch = {};
});*/
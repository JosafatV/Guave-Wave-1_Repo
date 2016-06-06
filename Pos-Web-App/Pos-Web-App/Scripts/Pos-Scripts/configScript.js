angular.module('NigmaFacturationApp').config(['$routeProvider', function ($routeProvider) {
    $routeProvider
/*-------------------------------------Cashier-------------------------------------------*/
    .when('/NigmaFacturation/CashierView/cashDeskOpening', {
        templateUrl: 'HtmlPages/CashierView/cashDeskOpening.html',
        controller: 'cashDeskOpeningController'
    })
    .when('/NigmaFacturation/CashierView/sales', {
        templateUrl: 'HtmlPages/Login/sales.html',
        controller: 'salesController'
    })
/*-------------------------------------Admin--------------------------------------------*/
    .when('/NigmaFacturation/AdminView/adminMenu', {
        templateUrl: 'HtmlPages/AdminView/adminMenu.html',
        controller: 'adminMenuController'
    })
    .when('/NigmaFacturation/AdminView/branchCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/branchMenu.html',
        controller: 'branchCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/employeesCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/employeesMenu.html',
        controller: 'employeesCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/productsCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/productsMenu.html',
        controller: 'productsCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/clientsCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/clientsMenu.html',
        controller: 'clientsCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/supplierCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/supplierMenu.html',
        controller: 'supplierCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/reports', {
        templateUrl: 'HtmlPages/AdminView/reports.html',
    controller: 'reportsController'
    })
/*-------------------------------------Login--------------------------------------------*/

    .when('/NigmaFacturation/LoginView/signIn', {
        templateUrl: 'HtmlPages/LoginView/signIn.html',
        controller: 'signInLoginController'
    })
    .otherwise({
        templateUrl: 'HtmlPages/LoginView/login.html',
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
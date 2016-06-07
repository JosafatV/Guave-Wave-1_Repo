angular.module('NigmaFacturationApp').controller('menuCashierController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCashDeskOpeningController = function () {
            $location.path('/NigmaFacturation/CashierView/cashDeskOpening');
        };
        $scope.goCashDeskClosingController = function () {
            $location.path('/NigmaFacturation/CashierView/cashDeskClosing');
        };
        $scope.goSales = function () {
            $location.path('/NigmaFacturation/CashierView/sales');
        };
        $scope.goLogin = function () {
            $location.path('default')
        };
    }]);
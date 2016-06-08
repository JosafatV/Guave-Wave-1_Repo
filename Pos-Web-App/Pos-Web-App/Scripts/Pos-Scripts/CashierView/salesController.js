angular.module('NigmaBillingApp').controller('salesController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCreateClient = function () {
            $location.path('/NigmaFacturation/CashierView/createClient');
        };
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier');
        };
        $scope.goBillingSystem = function () {
            $location.path('/NigmaFacturation/CashierView/sales/billingSystem');
        };
    }]);
angular.module('NigmaBillingApp').controller('supervisorLogController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/sales/billingSystem');
        };
        $scope.goProductsToRemove = function () {
            $location.path('/NigmaFacturation/CashierView/sales/productsToRemove');
        };
    }]);
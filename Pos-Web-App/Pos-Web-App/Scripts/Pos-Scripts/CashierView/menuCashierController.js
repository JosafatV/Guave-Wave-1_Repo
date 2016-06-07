angular.module('NigmaFacturationApp').controller('menuCashierController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goCashDeskOpeningController = function () {
            $location.path('/NigmaFacturation/CashierView/cashDeskOpening');
        };
        $scope.goCashDeskClosingController = function () {
            $location.path('/NigmaFacturation/CashierView/cashDeskClosing');
        };
        $scope.goSales = function () {
            $location.path('/NigmaFacturation/CashierView/sales');
        };
    }]);
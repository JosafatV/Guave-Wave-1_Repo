angular.module('NigmaBillingApp').controller('cashDeskClosingController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goCashier = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier')
        }

    }]);
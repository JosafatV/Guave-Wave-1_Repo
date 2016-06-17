angular.module('NigmaBillingApp').controller('cashDeskClosingController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.goCashier = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier')
        }

    }]);
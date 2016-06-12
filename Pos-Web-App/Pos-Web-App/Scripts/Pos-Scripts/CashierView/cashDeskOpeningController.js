angular.module('NigmaBillingApp').controller('cashDeskOpeningController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goCashier = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier')
        }

    }]);
angular.module('NigmaFacturationApp').controller('salesController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        alert('Estoy en el sales');
        $scope.goCreateClient = function () {
            $location.path('/NigmaFacturation/CashierView/createClient');
        };
    }]);
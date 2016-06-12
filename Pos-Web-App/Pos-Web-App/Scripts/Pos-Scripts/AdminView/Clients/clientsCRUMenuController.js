angular.module('NigmaBillingApp').controller('clientsCRUDMenuController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goCreateClients = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/createClients');
        };
        $scope.goReadClients = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/readClients');
        };
        $scope.goUpdateClients = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/updateClients');
        };
        $scope.goDeleteClients = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/deleteClients');
        };
        $scope.goReturn = function () {
            $location.path('/NigmaFacturation/AdminView/adminMenu');
        };
    }]);
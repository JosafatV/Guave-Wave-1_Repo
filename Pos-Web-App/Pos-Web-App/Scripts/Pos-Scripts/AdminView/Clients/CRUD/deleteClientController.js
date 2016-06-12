angular.module('NigmaBillingApp').controller('deleteClientController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goClientsCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
        };
    }]);

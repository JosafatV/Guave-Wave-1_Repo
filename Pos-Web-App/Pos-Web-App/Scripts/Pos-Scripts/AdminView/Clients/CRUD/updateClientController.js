angular.module('NigmaBillingApp').controller('updateClientController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
    $scope.goClientsCRUD = function () {
        $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
        };
    }]);

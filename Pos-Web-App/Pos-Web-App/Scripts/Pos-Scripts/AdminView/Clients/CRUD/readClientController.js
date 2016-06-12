angular.module('NigmaBillingApp').controller('readClientController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Clients
        $scope.listOfClients = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Clientes' }).$promise.then(function (data) {
            $scope.listOfClients = data;
        });
        $scope.goClientsCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
        };
    }]);

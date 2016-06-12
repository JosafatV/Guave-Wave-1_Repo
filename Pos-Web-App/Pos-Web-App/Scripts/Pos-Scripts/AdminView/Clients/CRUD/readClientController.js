angular.module('NigmaBillingApp').controller('readClientController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        //List of the Clients
        $scope.listOfClients = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Clientes' }).$promise.then(function (data) {
            $scope.listOfClients = data;
        });
    }]);

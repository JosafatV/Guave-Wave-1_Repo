angular.module('NigmaBillingApp').controller('readEmployeeController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        //List of the Clients
        $scope.listOfEmployee = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Clientes' }).$promise.then(function (data) {
            $scope.listOfEmployee = data;
        });
    }]);

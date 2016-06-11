angular.module('NigmaBillingApp').controller('readEmployeeController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        //List of the Branch
        $scope.listOfEmployees = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Empleados'}).$promise.then(function (data) {
            $scope.listOfEmployees = data;
        });
    }]);

angular.module('NigmaBillingApp').controller('deleteEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Employees
        $scope.listOfEmployee = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Empleados' }).$promise.then(function (data) {
            $scope.listOfEmployee = data;
        });
        $scope.sendDelete = function (emp) {
            waveWebApiResource.delete({ type: 'Empleado', extension1: emp.IdEmpleado });
        };
    }]);

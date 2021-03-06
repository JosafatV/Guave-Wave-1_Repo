angular.module('NigmaBillingApp').controller('deleteEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Employees
        $scope.listOfEmployee = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Empleados' }).$promise.then(function (data) {
            $scope.listOfEmployee = data;
        });
        //This function sen the new branch to the database in order to be save
        $scope.sendDelete = function (emp) {
            waveWebApiResource.delete({ type: 'Empleado', extension1: emp.IdEmpleado }).$promise.then(function () {
                //here I ask the list again to update it in the view at the same time
                waveWebApiResource.query({ type: 'Empleados' }).$promise.then(function (data) {
                    $scope.listOfEmployee = data;
                });
            });
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/employeesCRUDMenu')
        }
    }]);

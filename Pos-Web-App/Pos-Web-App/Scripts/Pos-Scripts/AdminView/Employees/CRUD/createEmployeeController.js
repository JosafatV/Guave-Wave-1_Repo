angular.module('NigmaBillingApp').controller('createEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.rolList = '';
        waveWebApiResource.query({ type: 'Roles' }).$promise.then(function (data) {
           $scope.rolList = data;
        });
        $scope.rolSelected = '';
        $scope.newEmployee = { Contrasena: '', Cedula: '', Nombre: '', Apellidos: '', Estado: 'A', IdRol: '', };
        $scope.changeRol = function () {
            $scope.newEmployee.IdRol = $scope.rolSelected.IdRol;
        };
        $scope.sendNewEmployee = function () {
            waveWebApiResource.save({ type: 'Empleado' }, $scope.newEmployee);
        };
        $scope.goCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/employeesCRUDMenu')
        }

     
    }]);

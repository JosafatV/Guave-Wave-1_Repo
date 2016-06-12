angular.module('NigmaBillingApp').controller('updateEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.rolList = '';
        waveWebApiResource.query({ type: 'Roles' }).$promise.then(function (data) {
            $scope.rolList = data;
        });
        $scope.rolSelected = '';
        $scope.boolHideModify = true;
        $scope.updatedEmployee = { Apellidos: '', Nombre: '', Cedula: '', IdRol: ''};
        //List of the Clients
        $scope.listOfEmployee = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Empleados' }).$promise.then(function (data) {
            $scope.listOfEmployee = data;
        $scope.changeRol = function (rol) {
            $scope.updatedEmployee.IdRol = $scope.rolSelected.IdRol;
            alert(angular.toJson($scope.updatedEmployee));
        };
        });
        $scope.unHideMod = function (emp) {
            $scope.boolHideModify = false;
            $scope.updatedEmployee.Nombre = emp.Nombre;
            $scope.updatedEmployee.Apellidos = emp.Apellidos;
            $scope.updatedEmployee.Cedula = emp.Cedula;
            $scope.updatedEmployee.Contrasena = emp.Contrasena;
            $scope.updatedEmployee.IdRol = emp.IdRol;
        };
        $scope.sendUpdate = function () {
            waveWebApiResource.update({ type: 'Empleado', extension1: $scope.updatedBranch.IdSucursal }, $scope.updatedBranch);
        };
    }]);

angular.module('NigmaBillingApp').controller('createEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.rolList = '';
        waveWebApiResource.query({ type: 'Roles' }).$promise.then(function (data) {
           $scope.rolList = data;
        });
        $scope.rolSelected = '';
        $scope.newEmployee = { Nombre: '', Apellidos: '', Cedula: '', Contrasena: '', IdRol:'',Estado:'A' };
        $scope.sendNewEmployee = function () {
            alert(angular.toJson($scope.newEmployee));
            //waveWebApiResource.save({ type: 'Empleados' }, $scope.newEmployee);
        };
        $scope.changeRol = function () {
            $scope.newEmployee.IdRol = $scope.rolSelected.IdRol;
            alert(angular.toJson($scope.newEmployee));
        };
    }]);

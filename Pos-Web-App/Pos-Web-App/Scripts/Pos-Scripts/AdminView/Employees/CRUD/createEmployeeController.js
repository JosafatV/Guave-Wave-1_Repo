angular.module('NigmaBillingApp').controller('createEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.rolList = '';
        waveWebApiResource.query({ type: 'Roles' }).$promise.then(function (data) {
            $scope.rolList = data;
        });
        $scope.rolSelected = '';
        $scope.newEmployee = { Nombre: '', Apellidos: '', Cedula: 'A', Contrasena: '', IdRol:'' };
        $scope.sendNewEmployee = function () {
            waveWebApiResource.save({ type: 'Sucursales' }, $scope.newEmployee);
        };
        $scope.changeRol = function () {
            $scope.newEmployee.IdRol = $scope.rolSelected.IdRol;
            alert(angular.toJson($scope.newEmployee));
        };
    }]);

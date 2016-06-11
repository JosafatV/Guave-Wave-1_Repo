angular.module('NigmaBillingApp').controller('createEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //Lista de los roles
        $scope.rolList = [];
        //Rol Selected
        $scope.rolSelected = '';
        //Get the rols from the database
        waveWebApiResource.query({ type: 'Roles' }).$promise.then(function (data) {
            $scope.rolList = data;
        });
        //New employee to create
        $scope.newEmployee = { Nombre: '', Contraseia: '', Cedula: '', Estado:'A', Apellidos: '', IdRol: '' };

        $scope.sendNewEmployee = function () {
            $scope.newEmployee.IdRol = $scope.rolSelected.IdRol;
            alert(angular.toJson($scope.newEmployee));
            waveWebApiResource.save({ type: 'Sucursales' }, $scope.newEmployee);
        };

    }]);

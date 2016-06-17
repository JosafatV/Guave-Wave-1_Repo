angular.module('NigmaBillingApp').controller('updateClientController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
    $scope.goClientsCRUD = function () {
        $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
    };
        $scope.boolHideModify = true;
        $scope.updatedClient = {IdCliente:'', Cedula: '', Nombre: '', Apellidos: '', FechaNacimiento: '', Estado: 'A' };
        //List of the eMPLOYEES
        $scope.listOfClient = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Clientes' }).$promise.then(function (data) {
            $scope.listOfClient = data;
        });

        $scope.changeRol = function (rol) {
            alert(angular.toJson($scope.updatedEmployee));
        };
        //Function that shows the hide elements to be modify
        $scope.unHideMod = function (emp) {
            $scope.boolHideModify = false;
            $scope.updatedClient.IdCliente = emp.IdCliente;
            $scope.updatedClient.Nombre = emp.Nombre;
            $scope.updatedClient.Apellidos = emp.Apellidos;
            $scope.updatedClient.Cedula = emp.Cedula;
            $scope.updatedClient.FechaNacimiento = emp.FechaNacimiento;
        };
        //Function that save the new data into the database
        $scope.sendUpdate = function () {
            waveWebApiResource.update({ type: 'Clientes', extension1: $scope.updatedClient.IdCliente }, $scope.updatedClient).$promise.then(function () {
                waveWebApiResource.query({ type: 'Clientes' }).$promise.then(function (data) {
                    $scope.listOfClient = data;
                });
            });
        };
    }]);

angular.module('NigmaBillingApp').controller('createClientController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {

    $scope.newClient = { Cedula: '', Nombre: '', Apellidos: 'A', FechaNacimiento: '', Estado: '' };
    $scope.sendNewClient = function () {
        waveWebApiResource.save({ type: 'Clientes' }, $scope.newClient);
    };

    }]);

angular.module('NigmaBillingApp').controller('createClientController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.newClient = { Cedula: '', Nombre: '', Apellidos: '', FechaNacimiento: '',Estado:'A'};
        $scope.sendnewClient = function () {
            alert(angular.toJson($scope.newClient));
            //waveWebApiResource.save({ type: 'Clientes' }, $scope.newClient);
        };
        $scope.goClientsCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
        };
    }]);

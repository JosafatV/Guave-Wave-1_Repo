angular.module('NigmaBillingApp').controller('createClientController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //-----------------Create the new object to save
        $scope.newClient = { Cedula: '', Nombre: '', Apellidos: '', FechaNacimiento: '', Estado: 'A' };
        //Function to save the data to the database
        $scope.sendnewClient = function () {
            waveWebApiResource.save({ type: 'Clientes' }, $scope.newClient);
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goClientsCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
        };
    }]);

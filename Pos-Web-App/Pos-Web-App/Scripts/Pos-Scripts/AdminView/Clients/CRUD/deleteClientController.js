angular.module('NigmaBillingApp').controller('deleteClientController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.goClientsCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
        };
        //List of the Cliente
        $scope.listOfClient = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Clientes' }).$promise.then(function (data) {
            $scope.listOfClient = data;
        });
        $scope.alerte = function (branch) {
            alert(angular.toJson(branch));
        };
        //This function sen the new branch to the database in order to be save
        $scope.sendDelete = function (cli) {
            waveWebApiResource.delete({ type: 'Clientes', extension1: cli.IdCliente }).$promise.then(function () {
                //here I ask the list again to update it in the view at the same time
                waveWebApiResource.query({ type: 'Clientes' }).$promise.then(function (data) {
                    $scope.listOfClient = data;
                });
            });
        };
    }]);

angular.module('NigmaBillingApp').controller('deleteSupplierController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {

        //List of the Branch
        $scope.listOfSupplier = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
            $scope.listOfSupplier = data;
        });
        $scope.alerte = function (branch) {
            alert(angular.toJson(branch));
        };
        //This function send the request to the database and save it
        $scope.sendDelete = function (sup) {
            waveWebApiResource.delete({ type: 'Proveedores', extension1: sup.IdProveedor }).$promise.then(function () {
                //Ask the list again to refresh it
                waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
                    $scope.listOfSupplier = data;
                });
            });
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
    }]);

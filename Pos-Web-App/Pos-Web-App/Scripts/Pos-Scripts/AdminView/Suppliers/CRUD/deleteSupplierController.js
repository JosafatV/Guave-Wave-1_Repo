angular.module('NigmaBillingApp').controller('deleteSupplierController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
        //List of the Branch
        $scope.listOfSupplier = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
            $scope.listOfSupplier = data;
        });
        $scope.alerte = function (branch) {
            alert(angular.toJson(branch));
        };
        $scope.sendDelete = function (sup) {
            waveWebApiResource.delete({ type: 'Proveedores', extension1: sup.IdProveedor }).$promise.then(function () {
                waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
                    $scope.listOfSupplier = data;
                });
            });
        };
    }]);

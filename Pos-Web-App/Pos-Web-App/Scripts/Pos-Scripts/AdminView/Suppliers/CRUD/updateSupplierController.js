angular.module('NigmaBillingApp').controller('updateSupplierController', ['$scope', '$routeParams', '$location','waveWebApiResource',
function ($scope, $routeParams, $location,waveWebApiResource) {
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
        $scope.boolHideModify = true;
        $scope.updatedSupplier = { IdProveedor: '', Nombre: '', Estado:'A'};
        //List of the eMPLOYEES
        $scope.listOfSupplier = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
            $scope.listOfSupplier = data;
        });

        $scope.changeRol = function (rol) {
            alert(angular.toJson($scope.updatedEmployee));
        };
        $scope.unHideMod = function (sup) {
            $scope.boolHideModify = false;
            $scope.updatedSupplier.IdProveedor = sup.IdProveedor;
            $scope.updatedSupplier.Nombre = sup.Nombre;
        };
        $scope.sendUpdate = function () {
            waveWebApiResource.update({ type: 'Proveedores', extension1: $scope.updatedSupplier.IdProveedor }, $scope.updatedSupplier).$promise.then(function () {
                waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
                    $scope.listOfSupplier = data;
                });
            });
        };
    }]);

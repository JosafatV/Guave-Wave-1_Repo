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
        //change the rol as the user selects another
        $scope.changeRol = function (rol) {
            alert(angular.toJson($scope.updatedEmployee));
        };
    //Function that shows the hide elements to be modify
        $scope.unHideMod = function (sup) {
            $scope.boolHideModify = false;
            $scope.updatedSupplier.IdProveedor = sup.IdProveedor;
            $scope.updatedSupplier.Nombre = sup.Nombre;
        };
    //Function that save the new data into the database
        $scope.sendUpdate = function () {
            waveWebApiResource.update({ type: 'Proveedores', extension1: $scope.updatedSupplier.IdProveedor }, $scope.updatedSupplier).$promise.then(function () {
            //Ask the list again to refresh
                waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
                    $scope.listOfSupplier = data;
                });
            });
        };
    }]);

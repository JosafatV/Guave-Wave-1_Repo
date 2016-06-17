angular.module('NigmaBillingApp').controller('createSupplierController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.newSupplier = { Nombre: '', Estado: 'A' };
        $scope.sendNewSupplier = function () {
            waveWebApiResource.save({ type: 'Proveedores' }, $scope.newSupplier);
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
    }]);

angular.module('NigmaBillingApp').controller('createSupplierController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.newSupplier = { Nombre: '', Estado: 'A' };
        $scope.sendNewSupplier = function () {
            waveWebApiResource.save({ type: 'Proveedores' }, $scope.newSupplier);
        };
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
    }]);

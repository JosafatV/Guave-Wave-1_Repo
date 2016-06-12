angular.module('NigmaBillingApp').controller('createSupplierController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.newSupplierC = { Nombre: '', Estado: 'A'};
        $scope.sendNewSupplier = function () {
            alert(angular.toJson($scope.newSupplierC));
            //waveWebApiResource.save({ type: 'Sucursales' }, $scope.newSupplier);
        };
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
    }]);

angular.module('NigmaBillingApp').controller('suppliersCRUDMenuController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goCreateSupplier = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/createSuppliers');
        };
        $scope.goReadSupplier = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/readSuppliers');
        };
        $scope.goUpdateSupplier = function () {
            $location.path('/NigmaFacturation/AdminView/Products/updateSuppliers');
        };
        $scope.goDeleteSupplier = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/deleteSuppliers');
        };
        $scope.goReturn = function () {
            $location.path('/NigmaFacturation/AdminView/adminMenu');
        };
    }]);
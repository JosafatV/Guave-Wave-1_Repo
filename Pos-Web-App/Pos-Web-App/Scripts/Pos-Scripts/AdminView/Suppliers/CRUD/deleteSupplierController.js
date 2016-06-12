angular.module('NigmaBillingApp').controller('deleteSupplierController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
    }]);

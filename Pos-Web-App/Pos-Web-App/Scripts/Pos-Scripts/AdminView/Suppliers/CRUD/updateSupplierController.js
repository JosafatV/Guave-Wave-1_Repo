angular.module('NigmaBillingApp').controller('updateSupplierController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
    }]);

angular.module('NigmaBillingApp').controller('deleteProductController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goProductosCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
        };
    }]);

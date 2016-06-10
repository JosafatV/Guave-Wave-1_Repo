angular.module('NigmaBillingApp').controller('productsCRUDMenuController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        alert('Estoy en el productsCRUDMenuController');
        $scope.goCreateProducts = function () {
            $location.path('/NigmaFacturation/AdminView/Products/createProducts');
        };
        $scope.goReadProducts = function () {
            $location.path('/NigmaFacturation/AdminView/Products/readProducts');
        };
        $scope.goUpdateProducts = function () {
            $location.path('/NigmaFacturation/AdminView/Products/updateProducts');
        };
        $scope.goDeleteProducts = function () {
            $location.path('/NigmaFacturation/AdminView/Products/deleteProducts');
        };
        $scope.goReturn = function () {
            $location.path('/NigmaFacturation/AdminView/adminMenu');
        };
    }]);
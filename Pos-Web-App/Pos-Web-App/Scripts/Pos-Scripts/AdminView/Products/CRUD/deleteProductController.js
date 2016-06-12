angular.module('NigmaBillingApp').controller('deleteProductController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.goProductosCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
        };
        //List of the Branch
        $scope.listOfProduct = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Productos' }).$promise.then(function (data) {
            $scope.listOfProduct = data;
        });
        $scope.alerte = function (branch) {
            alert(angular.toJson(branch));
        };
        $scope.sendDelete = function (prod) {
            alert(angular.toJson(prod.IdProducto));
            waveWebApiResource.delete({ type: 'Productos', extension1: prod.IdProducto }).$promise.then(function () {
                waveWebApiResource.query({ type: 'Productos' }).$promise.then(function (data) {
                    $scope.listOfProduct = data;
                });
            });
        };
    }]);

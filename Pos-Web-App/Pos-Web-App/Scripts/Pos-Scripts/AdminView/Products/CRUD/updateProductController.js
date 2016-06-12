angular.module('NigmaBillingApp').controller('updateProductController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.boolHideModify = true;
        $scope.updatedProduct= {IdProducto:'', EAN: '', Nombre: '', Precio: '',Estado:'A'};
        //List of the Branch
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Productos' }).$promise.then(function (data) {
            $scope.listOfProducts = data;
        });
        $scope.goProductosCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
        };
        $scope.unHideMod = function (prod) {
            $scope.boolHideModify = false;
            $scope.updatedProduct.IdProducto = prod.IdProducto;
            $scope.updatedProduct.EAN = prod.EAN;
            $scope.updatedProduct.Nombre = prod.Nombre;
            $scope.updatedProduct.Precio = prod.Precio;
        };
        $scope.sendUpdate = function () {
            waveWebApiResource.update({ type: 'Productos', extension1: $scope.updatedProduct.IdProducto }, $scope.updatedProduct).$promise.then(function () {
                waveWebApiResource.query({ type: 'Productos' }).$promise.then(function (data) {
                    $scope.listOfProducts = data;
                });
            });
        };
    }]);

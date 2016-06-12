angular.module('NigmaBillingApp').controller('createProductController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //NewProduct to sell
        $scope.newProduct= { EAN: '', Nombre: '', Precio: '',Estado:'A'};
        //Function that save to the database
            $scope.sendNewProduct = function () {
                alert(angular.toJson($scope.newProduct))
            //waveWebApiResource.save({ type: 'Productos' }, $scope.newProduct);
            };
            $scope.goProductosCRUD = function () {
                $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
            };

    }]);

angular.module('NigmaBillingApp').controller('createProductController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //NewProduct to sell
        $scope.newProduct= { EAN: '', Nombre: '', Precio: '',Estado:'A'};
        //Function that save to the database
        $scope.sendNewProduct = function () {
                waveWebApiResource.save({ type: 'Productos' }, $scope.newProduct);
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goProductosCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
        };

    }]);

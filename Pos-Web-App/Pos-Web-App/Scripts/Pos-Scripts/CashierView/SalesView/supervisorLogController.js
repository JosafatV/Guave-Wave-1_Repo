angular.module('NigmaBillingApp').controller('supervisorLogController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.listaProductos = listaActualPedido;
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/sales/billingSystem');
        };
        $scope.goProductsToRemove = function () {
            $location.path('/NigmaFacturation/CashierView/sales/productsToRemove');
        };
        $scope.deleteProduc = function (index) {
            $scope.indexDevolver = listaCodesTotal.indexOf(listaActualPedido[index].EAN);
            $scope.stockADevolver = listaActualPedido[index].Stock;
            listaTotal[$scope.indexDevolver].Stock = parseInt(listaTotal[$scope.indexDevolver].Stock) + parseInt($scope.stockADevolver);
            listaForSales.splice(index, 1);
            listaActualPedido.splice(index,1);
            $scope.listaProductos = listaActualPedido;

        };
    }]);
angular.module('NigmaBillingApp').controller('paymentReceiptController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.forSaleProductListAux = listaActualPedidoAux;
        $scope.valorTotal = 0;
        angular.forEach($scope.forSaleProductListAux, function (value, key) {
            $scope.valorTotal += (value.Precio * value.Stock)
        });
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/sales');
        };
    }]);
angular.module('NigmaBillingApp').controller('menuCashierController', ['$scope', '$routeParams', '$location','waveWebApiResource',
function ($scope, $routeParams, $location,waveWebApiResource) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCashDeskOpeningController = function () {
            $location.path('/NigmaFacturation/CashierView/cashDeskOpening');
        };
        $scope.goCashDeskClosingController = function () {
            $location.path('/NigmaFacturation/CashierView/cashDeskClosing');
        };
        $scope.goSales = function () {
            //Quitar Este:
            //$location.path('/NigmaFacturation/CashierView/sales');
            //Poner Este:
            waveWebApiResource.query({ type: 'ProductoPorSucursal', extension1: sucursalActual}).$promise.then(function (data) {
                   listaTotal = data;
                   $location.path('/NigmaFacturation/CashierView/sales');
            });
        };
        $scope.goLogin = function () {
            $location.path('default')
        };
    }]);
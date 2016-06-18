angular.module('NigmaBillingApp').controller('salesController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        tiempo_inicial = new Date();

        $scope.puedeVender = cajaAbierta;
        $scope.alerteNoExisteCliente = function () {
            alert('No es un cliente registrado');
        };

        $scope.reviseCliente = function () {
            $scope.boolNoEsCliente = false;
            $scope.boolSiEsCliente = false;
            waveWebApiResource.get({ type: 'Clientes', extension1: $scope.textCedBool }).$promise.then(function (data) {
                clienteActual = data;
                $scope.boolSiEsCliente = true;
            }, function (error) {
                $scope.boolNoEsCliente = true;
            });
        };

        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCreateClient = function () {
            $location.path('/NigmaFacturation/CashierView/createClient');
        };
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier');
        };
        $scope.goBillingSystem = function () {
            $location.path('/NigmaFacturation/CashierView/sales/billingSystem');
        };
    }]);
angular.module('NigmaBillingApp').controller('cashDeskClosingController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //-----Datos a mostrar del cliente
        $scope.nombreCajero = empleadoActual.Nombre;
        $scope.apellidosCajero = empleadoActual.Apellidos;
        $scope.cedulaCajero = empleadoActual.Cedula;
        //Funcion que realiza la apertura de la caja
        $scope.cerrarCaja = function () {
            cajaAbierta = false;
            waveWebApiResource.update({ type: 'Cajas', extension1: 'Cierre', extension2: cajaActual, extension3: $scope.dineroFinal }, {
                IdCaja: cajaActual,
                Dinero: $scope.dineroFinal,
                Estado: "I"
            }).$promise.then(function () {
                cajaAbierta = false;
            });

        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCashier = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier')
        }

    }]);
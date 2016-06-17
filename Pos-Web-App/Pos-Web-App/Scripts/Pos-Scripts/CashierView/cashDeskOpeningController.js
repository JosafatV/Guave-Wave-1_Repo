angular.module('NigmaBillingApp').controller('cashDeskOpeningController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.nombreCajero = empleadoActual.Nombre;
        $scope.apellidosCajero = empleadoActual.Apellidos;
        $scope.cedulaCajero = empleadoActual.Cedula;
        //Funcion que realiza la apertura de la caja
        $scope.aperturaCaja = function () {
            waveWebApiResource.update({ type: 'Cajas', extension1: cajaActual },{ 
                    IdCaja: cajaActual,
                    Dinero: $scope.dineroInicial,
                    Estado: "A"
            }).$promise.then(function () {
                cajaAbierta = true;
            })

        };

        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCashier = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier')
        }


    }]);
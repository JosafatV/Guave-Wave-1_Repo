angular.module('NigmaBillingApp').controller('cashDeskOpeningController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.nombreCajero = empleadoActual.Nombre;
        $scope.apellidosCajero = empleadoActual.Apellidos;
        $scope.cedulaCajero = empleadoActual.Cedula;
        //Funcion que realiza la apertura de la caja
        $scope.aperturaCaja = function () {


                waveWebApiResource.update({ type: 'Cajas', extension1: $scope.cajaIngresada }, {
                    IdCaja: $scope.cajaIngresada,
                    Dinero: $scope.dineroInicial,
                    Estado: "A"
                }).$promise.then(function () {
                    cajaActual = $scope.cajaIngresada;
                    cajaAbierta = true;
                    alert('Se abrio la caja');
                    waveWebApiResource.query({ type: 'CajaPorSucursal', extension1: $scope.cajaIngresada }).$promise.then(function (data) {
                        sucursalActual = data[0].IdSucursal;
                })

            });
        };

        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCashier = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier')
        }


    }]);
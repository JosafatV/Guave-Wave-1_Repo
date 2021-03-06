﻿angular.module('NigmaBillingApp').controller('createClientControllerSales', ['$scope', '$routeParams', '$location','waveWebApiResource',
function ($scope, $routeParams, $location, waveWebApiResource) {
    /*--------------New Client to save----------------*/
    $scope.newClient = { Cedula: '', Nombre: '', Apellidos: '', FechaNacimiento: '', Estado: 'A' };
    /*--------------Functions that sends to the database---------------*/
    $scope.sendnewClient = function () {
        waveWebApiResource.save({ type: 'Clientes' }, $scope.newClient).$promise.then(function () {
            alert('Se creo el cliente correctamente');
        });
    };
    /*--------------Functions to redirect the user as he/she do something----------------*/
    $scope.goBack = function () {
        $location.path('/NigmaFacturation/CashierView/sales');
    };
    }]);
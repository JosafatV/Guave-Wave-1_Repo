﻿angular.module('NigmaBillingApp').controller('createClientController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/sales');
        };
    }]);
﻿angular.module('NigmaFacturationApp').controller('adminMenuController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        alert('Estoy en el admin');
        $scope.goBranch = function () {
            $location.path('/NigmaFacturation/AdminView/branchCRUDMenu');
        };
        $scope.goEmployees = function () {
            $location.path('/NigmaFacturation/AdminView/employeesCRUDMenu');
        };
        $scope.goSuppliers = function () {
            $location.path('/NigmaFacturation/AdminView/supplierCRUDMenu');
        };
        $scope.goClients = function () {
            $location.path('/NigmaFacturation/AdminView/clientsCRUDMenu');
        };
        $scope.goProducts = function () {
            $location.path('/NigmaFacturation/AdminView/productsCRUDMenu');
        };
        $scope.goReports = function () {
            $location.path('/NigmaFacturation/AdminView/reports');
        };
    }]);
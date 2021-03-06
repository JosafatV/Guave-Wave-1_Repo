﻿angular.module('NigmaBillingApp').controller('adminMenuController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goBranch = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/branchCRUDMenu');
        };
        $scope.goEmployees = function () {
            $location.path('/NigmaFacturation/AdminView/employeesCRUDMenu');
        };
        $scope.goSuppliers = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
        $scope.goClients = function () {
            $location.path('/NigmaFacturation/AdminView/Clients/clientsCRUDMenu');
        };
        $scope.goProducts = function () {
            $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
        };
        $scope.goReports = function () {
            $location.path('/NigmaFacturation/AdminView/reports');
        };
        $scope.goReports = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/SuppliersProducts');
        };
        $scope.getOut = function () {
            $location.path('cuca');
        };
    }]);
angular.module('NigmaBillingApp').controller('readSupplierController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Branch
        $scope.listOfSuppliers = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Proveedores' }).$promise.then(function (data) {
            $scope.listOfSuppliers = data;
        });
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goSuppliersCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Suppliers/supplierCRUDMenu');
        };
    }]);

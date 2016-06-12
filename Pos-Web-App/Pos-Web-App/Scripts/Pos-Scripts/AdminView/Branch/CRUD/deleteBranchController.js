angular.module('NigmaBillingApp').controller('deleteBranchController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.goSucursalCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/branchCRUDMenu');
        };
        //List of the Branch
        $scope.listOfBranch = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Sucursales' }).$promise.then(function (data) {
            $scope.listOfBranch = data;
        });
        $scope.alerte = function (branch) {
            alert(angular.toJson(branch));
        };
        $scope.sendDelete = function (branch) {
            waveWebApiResource.delete({ type: 'Sucursales', extension1: branch.IdSucursal }).$promise.then(function () {
                waveWebApiResource.query({ type: 'Sucursales' }).$promise.then(function (data) {
                    $scope.listOfBranch = data;
                });
            });
        };
    }]);

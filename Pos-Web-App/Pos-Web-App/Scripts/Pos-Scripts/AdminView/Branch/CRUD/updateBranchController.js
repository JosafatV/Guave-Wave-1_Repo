angular.module('NigmaBillingApp').controller('updateBranchController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //Branch to modify 
        $scope.updatedBranch = { IdSucursal:'' ,Nombre: '', Direccion: '', Estado: 'A', Telefono: '' };
        $scope.boolHideModify = true;
        //List of the Branch
        $scope.listOfBranch = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Sucursales' }).$promise.then(function (data) {
            $scope.listOfBranch = data;
        });
        //This function when a row is clicked shows the modification
        $scope.unHideMod = function (branch) {
            $scope.boolHideModify = false;
            $scope.updatedBranch.Nombre = branch.Nombre;
            $scope.updatedBranch.Direccion = branch.Direccion;
            $scope.updatedBranch.Telefono = branch.Telefono;
            $scope.updatedBranch.IdSucursal = branch.IdSucursal;
        };
        //Function that save the new data into the database
        $scope.sendUpdate = function () {
            waveWebApiResource.update({ type: 'Sucursales', extension1: $scope.updatedBranch.IdSucursal }, $scope.updatedBranch).$promise.then(function () {
                waveWebApiResource.query({ type: 'Sucursales' }).$promise.then(function (data) {
                    $scope.listOfBranch = data;
                });
            });
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goSucursalCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/branchCRUDMenu');
        };
    }]);

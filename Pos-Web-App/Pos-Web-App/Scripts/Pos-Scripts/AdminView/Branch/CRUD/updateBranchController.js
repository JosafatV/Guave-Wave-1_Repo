angular.module('NigmaBillingApp').controller('updateBranchController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //Id de la Branch
        $scope.idActual = '';
        //Branch to modify 
        $scope.updatedBranch = { Nombre: '', Direccion: '', Estado: 'A', Telefono: '' };
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
            $scope.idActual = branch.IdSucursal;
        };
        //Function that sends te PUT
        $scope.sendUpdate = function () {
            //alert(angular.toJson($scope.updatedBranch));
            waveWebApiResource.update({ Type: 'Sucursales', extension1: $scope.idActual }, $scope.updatedBranch);
        };
    }]);

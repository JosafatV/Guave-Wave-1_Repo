angular.module('NigmaBillingApp').controller('createBranchController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //-----------------Create the new object to save
        $scope.newBranch = { Nombre: '', Direccion: '', Estado: 'A', Telefono: '' };
        //Function to save the data to the database
        $scope.sendNewBranch = function () {
            waveWebApiResource.save({ type: 'Sucursales' }, $scope.newBranch);
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goSucursalCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/branchCRUDMenu');
        };

    }]);

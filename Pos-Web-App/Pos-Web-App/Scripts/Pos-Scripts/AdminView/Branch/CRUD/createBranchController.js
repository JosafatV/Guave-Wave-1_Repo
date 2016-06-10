angular.module('NigmaBillingApp').controller('createBranchController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location,waveWebApiResource) {
        $scope.newBranch = { Nombre: '', Direccion: '', Estado: 'A', Telefono:''};
        $scope.sendNewBranch = function () {
            waveWebApiResource.save({ type: 'Sucursales' }, $scope.newBranch);
        };

    }]);

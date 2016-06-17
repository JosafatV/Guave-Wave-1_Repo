angular.module('NigmaBillingApp').controller('readBranchController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Branch
        $scope.listOfBranch = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Sucursales' }).$promise.then(function (data) {
            $scope.listOfBranch = data;
        });
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goSucursalCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/branchCRUDMenu');
        };
    }]);

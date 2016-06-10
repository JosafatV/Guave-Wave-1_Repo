angular.module('NigmaBillingApp').controller('readBranchController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Branch
        $scope.listOfBranch = [];
        waveWebApiResource.query({ type: 'Sucursales' }).$promise.then(function (data) {
            $scope.listOfBranch = data;
            alert(angular.toJson(data));
        });



    }]);

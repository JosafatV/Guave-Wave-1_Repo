angular.module('NigmaBillingApp').controller('deleteBranchController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        $scope.goSucursalCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/branchCRUDMenu');
        };
    }]);

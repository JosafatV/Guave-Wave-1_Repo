angular.module('NigmaBillingApp').controller('branchCRUDMenuController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCreateBranch = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/createBranch');
        };
        $scope.goDeleteBranch = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/deleteBranch');
        };
        $scope.goUpdateBranch = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/updateBranch');
        };
        $scope.goReadBranch = function () {
            $location.path('/NigmaFacturation/AdminView/Branch/readBranch');
        };
        $scope.goReturn = function () {
            $location.path('/NigmaFacturation/AdminView/adminMenu');
        };
        
    }]);
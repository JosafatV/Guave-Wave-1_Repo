angular.module('NigmaBillingApp').controller('employeesCRUDMenuController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCreateEmployee = function () {
            $location.path('/NigmaFacturation/AdminView/Employee/createEmployee')
        }
        $scope.goSeeEmployee = function () {
            $location.path('/NigmaFacturation/AdminView/Employee/readEmployee')
        }
        $scope.goUpdateEmployee = function () {
            $location.path('/NigmaFacturation/AdminView/Employee/updateEmployee')
        }
        $scope.goDeleteEmployee = function () {
            $location.path('/NigmaFacturation/AdminView/Employee/deleteEmployee')
        }
        $scope.goReturn = function () {
            $location.path('/NigmaFacturation/AdminView/adminMenu')
        }
    }]);
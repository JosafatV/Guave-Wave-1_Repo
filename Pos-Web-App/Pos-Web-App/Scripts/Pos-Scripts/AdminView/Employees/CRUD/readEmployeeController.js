angular.module('NigmaBillingApp').controller('readEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Clients
        $scope.listOfEmployee = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Empleados' }).$promise.then(function (data) {
            $scope.listOfEmployee = data;
        });
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/employeesCRUDMenu')
        }
    }]);

angular.module('NigmaBillingApp').controller('createEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.rolList = '';
        //Here we get the full list of roles and save it to show it into a list
        waveWebApiResource.query({ type: 'Roles' }).$promise.then(function (data) {
           $scope.rolList = data;
        });
        $scope.rolSelected = '';
        //-----------------Create the new object to save
        $scope.newEmployee = { Contrasena: '', Cedula: '', Nombre: '', Apellidos: '', Estado: 'A', IdRol: '', };
        //change the rol as selected for update
        $scope.changeRol = function () {
            $scope.newEmployee.IdRol = $scope.rolSelected.IdRol;
        };
        //Function to save the data to the database
        $scope.sendNewEmployee = function () {
            waveWebApiResource.save({ type: 'Empleado' }, $scope.newEmployee);
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/employeesCRUDMenu')
        }

     
    }]);

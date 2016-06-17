angular.module('NigmaBillingApp').controller('updateEmployeeController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.rolList = '';
        //Ask de roles to be shown
        waveWebApiResource.query({ type: 'Roles' }).$promise.then(function (data) {
            $scope.rolList = data;
        });
        $scope.rolSelected = '';
        $scope.boolHideModify = true;
        $scope.updatedEmployee = { IdEmpleado:'', Apellidos: '', Nombre: '', Cedula: '', IdRol: '',Estado:'A'};
        //List of the eMPLOYEES
        $scope.listOfEmployee = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Empleados' }).$promise.then(function (data) {
            $scope.listOfEmployee = data;
        });

        $scope.changeRol = function (rol) {
            $scope.updatedEmployee.IdRol = $scope.rolSelected.IdRol;
            alert(angular.toJson($scope.updatedEmployee));
        };
        //Function that shows the hide elements to be modify
        $scope.unHideMod = function (emp) {
            $scope.boolHideModify = false;
            $scope.updatedEmployee.IdEmpleado = emp.IdEmpleado;
            $scope.updatedEmployee.Nombre = emp.Nombre;
            $scope.updatedEmployee.Apellidos = emp.Apellidos;
            $scope.updatedEmployee.Cedula = emp.Cedula;
            $scope.updatedEmployee.Contrasena = emp.Contrasena;
            $scope.updatedEmployee.IdRol = emp.IdRol;
        };
        //Function that save the new data into the database
        $scope.sendUpdate = function () {
            waveWebApiResource.update({ type: 'Empleado', extension1: $scope.updatedEmployee.IdEmpleado }, $scope.updatedEmployee).$promise.then(function () {
                waveWebApiResource.query({ type: 'Empleados' }).$promise.then(function (data) {
                    $scope.listOfEmployee = data;
                });
            });
        };
        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/employeesCRUDMenu')
        }
    }]);

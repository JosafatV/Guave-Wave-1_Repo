var clienteActual =  1;
var sucursalActual = 3;
var tiempo_inicial = '';
var cajaActual = 1;
var cajaAbierta = false;
var listaActualPedido = [];
var listaTotal = [
            { EAN: '556095512398  ', Nombre: 'sideocaina', Stock: '10', Precio: '1000' },
            { EAN: '2', Nombre: 'crack', Stock: '15', Precio: '55000' },
            { EAN: '3', Nombre: 'mariguanol', Stock: '1', Precio: '40' },
            { EAN: '4', Nombre: 'dorival', Stock: '5', Precio: '500' },
];
var listaCodesTotal = [];
var listaForSales = [];
var empleadoActual = {
    IdEmpleado: 11,
    Contrasena: "4343           ",
    Cedula: "21231     ",
    Nombre: "Josef          ",
    Apellidos: "Vargas                        ",
    Estado: "A",
    IdRol: 5,
    NombreRol: "Misceláneo     ",
    EstadoRol: "A"
}

angular.module('NigmaBillingApp').controller('loginController', ['$scope', '$routeParams', '$location','ModalService',
    function ($scope, $routeParams, $location, ModalService) {

        /*--------------Functions to redirect the user as he/she do something----------------*/
        $scope.goCashier = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier');
        };
        $scope.goAdminMenu = function () {
            $location.path('/NigmaFacturation/AdminView/adminMenu');
        };
        $scope.goModal = function () {
            ModalService.showModal({
                templateUrl: 'HtmlPages/LoginView/modal.html',
                controller: "loginController"
            }).then(function (modal) {

                //it's a bootstrap element, use 'modal' to show it
                modal.element.modal();
                modal.close.then(function (result) {
                    console.log(result);
                });
            });
        };



        /*$scope.contra = '';
        $scope.cedula = '';
        $scope.listaRoles = [];
        $scope.listaRolesLength = 100;
        $scope.doctorDisponible = false;
        $scope.pacienteDisponible = false;
        $scope.adminDisponible = false;
        $scope.pediLosRoles = false;
        //$scope.cedula = 0;
        //$scope.contra = 0;
        //This function is used to send the login request to the server 
        $scope.ingresar = function () {
            $scope.listaRoles = '';
            $scope.doctorDisponible = false;
            $scope.pacienteDisponible = false;
            $scope.adminDisponible = false;
            drPhischelApiResource.query({
                type: 'LogInUser', extension: 'Cedula', extension2: $scope.cedula,
                extension3: 'Password', extension4: $scope.contra
            }).$promise.then(function (data) {
                $scope.listaRolesLength = data.length;
                $scope.listaRoles = data;
                $scope.pediLosRoles = true;
            });
        };
        //Function that alert no register member
        $scope.alerteNoRegistrado = function () {
            alert('No es un usuario registrado');
        };
        //Check if the client is a patient
        $scope.esPaciente = function (rol) {
            return rol === '1';
        };
        //Check if the client is a doctor
        $scope.esDoctor = function (rol) {
            return rol === '2';
        };
        //Check if the client is a admin
        $scope.esAdmin = function (rol) {
            return rol === '3';
        };

        //Activate the button to the doctor 
        $scope.activeDoctor = function () {
            $scope.doctorDisponible = true;
            docActual = $scope.listaRoles[0].id;
            usuarioActual = $scope.listaRoles[0].id;
        };
        //Activate the button to the patient 
        $scope.activePaciente = function () {
            $scope.pacienteDisponible = true;
            docActual = $scope.listaRoles[0].id;
            usuarioActual = $scope.listaRoles[0].id;
        };
        //Activate the button to the admin 
        $scope.activeAdmin = function () {
            $scope.adminDisponible = true;
            docActual = $scope.listaRoles[0].id;
            usuarioActual = $scope.listaRoles[0].id;
        };
        //go admin view 
        $scope.goAdminView = function () {
            $location.path('/DrPhischel/Admin/Menu');
        };
        //go doctor view
        $scope.goDoctorView = function () {
            $location.path('/DrPhischel/DoctorMenu');
        };
        //go patient view
        $scope.goPacienteView = function () {
            $location.path('/DrPhischel/Patient');
        };
        $scope.goSolicitarCreacion = function () {
            $location.path('/DrPhischel/Login/CrearPerfil');
        };*/
    }]);
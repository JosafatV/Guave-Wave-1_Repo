var clienteActual =  1;
var sucursalActual = 3;
var tiempo_inicial = '';
var cajaActual = 1;
var cajaAbierta = false;
var listaActualPedidoAux = [];
var listaActualPedido = [];
var listaTotal = [
            { EAN: '556095512398  ', Nombre: 'nemo', Stock: '10', Precio: '1000' },
            { EAN: '2', Nombre: 'anemia', Stock: '15', Precio: '55000' },
            { EAN: '3', Nombre: 'cancer', Stock: '1', Precio: '40' },
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

angular.module('NigmaBillingApp').controller('loginController', ['$scope', '$routeParams', '$location','ModalService','waveWebApiResource',
    function ($scope, $routeParams, $location, ModalService, waveWebApiResource) {
        $scope.advierteAdminOCajero = false ;
        //Cambio del Login         
        $scope.contra = '';
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
            $scope.banderaAlerte = false;
            $scope.listaRoles = '';
            $scope.cajeroDisponible = false
            $scope.adminDisponible = false;
            waveWebApiResource.query({
                type: 'EmpleadoLogIn', extension1: $scope.cedBool, extension2: $scope.passwBool
            }).$promise.then(function (data) {
                $scope.listaRolesLength = data.length;
                $scope.listaRoles = data;
                $scope.pediLosRoles = true;
            });
        };

        $scope.pruebeRolesMalUsuario = function () {
            return $scope.listaRolesLength == 0;
        };

        //Function that alert no register member
        $scope.alerteNoRegistrado = function () {
            alert('No es un administrador o cajero registrado');
            $scope.listaRoles = '';
        };
        //Check if the employee is a cashier
        $scope.esCajero = function (rol) {            
            return rol == '3';
        };
        //Check if the employee is a admin
        $scope.esAdmin = function (rol) {
            return rol == '1';
        };

        //Activate the button to the doctor 
        $scope.activeCajero = function (empleado) {
            $scope.cajeroDisponible = true;
            empleadoActual = empleado;
            //docActual = $scope.listaRoles[0].id;
            //usuarioActual = $scope.listaRoles[0].id;
        };

        //Activate the button to the admin 
        $scope.activeAdmin = function (empleado) {
            $scope.adminDisponible = true;
            empleadoActual = empleado;
           // docActual = $scope.listaRoles[0].id;
            //usuarioActual = $scope.listaRoles[0].id;
        };

        $scope.banderAlerteOn = function () {
            $scope.banderaAlerte = true;
        };

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

    }]);
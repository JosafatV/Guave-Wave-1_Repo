angular.module('NigmaBillingApp').controller('billingSystemController', ['$scope', '$routeParams', '$location','waveWebApiResource',
function ($scope, $routeParams, $location,waveWebApiResource) {
        //cantidad minima para la cual se puede hacer un producto, aqui tambien se guarda la cantidad que pide el cajero       
        $scope.quantity = 1;
        $scope.wrongCode = true;
        //-------------------------------------------------Nuevo
        
            $scope.allProductList = listaTotal;
       
        //-------------------------------------------------/Nuevo
        //lista de todos los productos disponibles

        //list of only all codeslistaForSales
        $scope.allProductCodes = [];
        //function that save only all the codes in one list
        $scope.getAllCodes = function () {
            angular.forEach($scope.allProductList, function (value, key) {
                $scope.allProductCodes.push(value.EAN);
            });
        };
        $scope.getAllCodes();
        //list of all codes for sale products
        $scope.forSaleProductCodes = listaForSales;
        //lista de todos los productos que pide el cajero
        $scope.forSaleProductList = listaActualPedido;
/*--------------Functions to redirect the user as he/she do something----------------*/        
        $scope.goCreateClient = function () {
            $location.path('/NigmaFacturation/CashierView/createClient');
        };
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier');
        };
        $scope.goReceipt = function () {
            //Esto me da los segundos que duro y los guarda en var duracion
            var duracion = (new Date() - tiempo_inicial) / 1000;
            var ventaActual = '';
            //-------------------------------------------------Nuevo
            //Obtengo el numero de venta con esto-------------------------------------------------Nuevo
            waveWebApiResource.save({ type: 'Ventas' }, { IdCaja: cajaActual, Duracion: duracion, IdCliente: clienteActual })
                .$promise.then(function (data) {
                    ventaActual = data.IdVenta;
                    //guardo los productos que el cliente compro
                    angular.forEach($scope.forSaleProductList, function (value, key) {
                        waveWebApiResource.save({ type: 'ProductoPorVenta' },
                            { IdProducto: value.EAN, IdVenta: ventaActual, IdCaja: cajaActual, Cantidad: value.Stock }).$promise.then(function (data) {
                            });
                    })
                        //No se si funciona esto: hay que probarlo:
                    .$promise.then(function (data) {
                        $location.path('/NigmaFacturation/CashierView/sales/paymentReceipt');
                        //esta linea es muy importante debe buscar donde colocarse;------------------------------------------------------------------------
                        //si no sirve se redirecciona afuera y se coloca vacia ahí
                        listaActualPedido = [];
                    });
                });
            //-------------------------------------------------/Nuevo
        };
        $scope.goSupervisorLog = function () {
            //-------------------------------------------------Nuevo
            listaActualPedido = $scope.forSaleProductList;
            listaCodesTotal = $scope.allProductCodes;
            listaForSales = $scope.forSaleProductCodes;
            //-------------------------------------------------/Nuevo
            $location.path('/NigmaFacturation/CashierView/sales/productsToRemove');
        };
/*--------------Function to save a new product-----------------------------------------*/
        $scope.saveNewProduct = function (newProductcode, newProductQuantity) {
            $scope.agregateProductCode = newProductcode;
            $scope.agregateProductQuantity = newProductQuantity;
            $scope.boolCheckAddedProduct = true;
            $scope.boolCheckAddedProductCode = true;
            $scope.codBool.EAN = '';
        };
        $scope.addTheProduct = function (productToSale) {
            $scope.wrongCode = false;
            $scope.boolCheckAddedProduct = false;
            $scope.forSaleProductList.push({
                EAN: productToSale.EAN, Nombre: productToSale.Nombre,
                Precio: productToSale.Precio, Stock: $scope.agregateProductQuantity
            });
            $scope.forSaleProductCodes.push(productToSale.EAN);
            $scope.prodPos = $scope.allProductList.indexOf(productToSale);
            $scope.allProductList[$scope.prodPos].Stock -= $scope.agregateProductQuantity;
        };
        $scope.compareProductsQuantitiesLess = function (originalP,newP) {
            return parseInt(originalP) < parseInt(newP);
        };
        $scope.compareProductsQuantitiesMore = function (originalP, newP) {
            return parseInt(originalP) >= parseInt(newP);
        };
/*--------------Function to alert something went wrong---------------------------------*/
        $scope.alerteNoExisteCodigo = function (productWrongCode) {
            alert('Código erroneo: ' + productWrongCode);
            $scope.boolCheckAddedProductCode = false
        };
        $scope.alerteCantidad = function (productFullQuantityToSale) {
            alert('La cantidad máxima disponible es de: ' + productFullQuantityToSale);
            $scope.boolCheckAddedProduct = false;
        };
        $scope.alerteYaExiste = function (g) {
            alert('Ya ingreso este codigo para la venta: ' + g);
            $scope.boolCheckAddedProduct = false;
        };
    }]);
angular.module('NigmaBillingApp').controller('billingSystemController', ['$scope', '$routeParams', '$location',
    function ($scope, $routeParams, $location) {
        //cantidad minima para la cual se puede hacer un producto, aqui tambien se guarda la cantidad que pide el cajero       
        $scope.quantity = 1;
        $scope.wrongCode = true;
        //lista de todos los productos disponibles
        $scope.allProductList = [
            { code: '1', name: 'sideocaina', quantity: '10', price: '1000' },
            { code: '2', name: 'crack', quantity: '15', price: '55000' },
            { code: '3', name: 'mariguanol', quantity: '1', price: '40' },
            { code: '4', name: 'dorival', quantity: '5', price: '500' },
        ];
        //list of only all codes
        $scope.allProductCodes = [];
        //function that save only all the codes in one list
        $scope.getAllCodes = function () {
            angular.forEach($scope.allProductList, function (value, key) {
                $scope.allProductCodes.push(value.code);
            });
        };
        $scope.getAllCodes();
        //list of all codes for sale products
        $scope.forSaleProductCodes = [];
        //lista de todos los productos que pide el cajero
        $scope.forSaleProductList = [];
/*--------------Functions to redirect the user as he/she do something----------------*/        
        $scope.goCreateClient = function () {
            $location.path('/NigmaFacturation/CashierView/createClient');
        };
        $scope.goBack = function () {
            $location.path('/NigmaFacturation/CashierView/menuCashier');
        };
        $scope.goReceipt = function () {
            $location.path('/NigmaFacturation/CashierView/sales/paymentReceipt');
        };
        $scope.goSupervisorLog = function () {
            $location.path('/NigmaFacturation/CashierView/sales/supervisorLog');
        };
/*--------------Function to save a new product-----------------------------------------*/
        $scope.saveNewProduct = function (newProductcode, newProductQuantity) {
            $scope.agregateProductCode = newProductcode;
            $scope.agregateProductQuantity = newProductQuantity;
            $scope.boolCheckAddedProduct = true;
            $scope.boolCheckAddedProductCode = true;
        };
        $scope.addTheProduct = function (productToSale) {
            $scope.wrongCode = false;
            $scope.boolCheckAddedProduct = false;
            productToSale.quantity = $scope.agregateProductQuantity;
            $scope.forSaleProductList.push(productToSale);
            $scope.forSaleProductCodes.push(productToSale.code);
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
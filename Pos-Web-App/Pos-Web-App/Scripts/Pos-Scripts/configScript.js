angular.module('NigmaBillingApp').config(['$routeProvider', function ($routeProvider) {
    $routeProvider
/*-------------------------------------Cashier-------------------------------------------*/

    .when('/NigmaFacturation/CashierView/menuCashier', {
        templateUrl: 'HtmlPages/CashierView/menuCashier.html',
        controller: 'menuCashierController'
    })
    .when('/NigmaFacturation/CashierView/createClient', {
        templateUrl: 'HtmlPages/CashierView/createClient.html',
        controller: 'createClientController'
    })
    .when('/NigmaFacturation/CashierView/cashDeskOpening', {
        templateUrl: 'HtmlPages/CashierView/cashDeskOpening.html',
        controller: 'cashDeskOpeningController'
    })
    .when('/NigmaFacturation/CashierView/cashDeskClosing', {
        templateUrl: 'HtmlPages/CashierView/cashDeskClosing.html',
        controller: 'cashDeskClosingController'
    })
    .when('/NigmaFacturation/CashierView/sales', {
        templateUrl: 'HtmlPages/CashierView/sales.html',
        controller: 'salesController'
    })
/*------------------Cashier Sales--------------------*/

    .when('/NigmaFacturation/CashierView/sales/billingSystem', {
        templateUrl: 'HtmlPages/CashierView/SalesView/billingSystem.html',
        controller: 'billingSystemController'
    })
    .when('/NigmaFacturation/CashierView/sales/inventory', {
        templateUrl: 'HtmlPages/CashierView/SalesView/inventory.html',
        controller: 'inventoryController'
    })
    .when('/NigmaFacturation/CashierView/sales/paymentReceipt', {
        templateUrl: 'HtmlPages/CashierView/SalesView/paymentReceipt.html',
        controller: 'paymentReceiptController'
    })
    .when('/NigmaFacturation/CashierView/sales/productsToRemove', {
        templateUrl: 'HtmlPages/CashierView/SalesView/productsToRemove.html',
        controller: 'productsToRemoveController'
    })
    .when('/NigmaFacturation/CashierView/sales/supervisorLog', {
        templateUrl: 'HtmlPages/CashierView/SalesView/supervisorLog.html',
        controller: 'supervisorLogController'
    })

/*-------------------------------------Admin--------------------------------------------*/

    .when('/NigmaFacturation/AdminView/adminMenu', {
        templateUrl: 'HtmlPages/AdminView/adminMenu.html',
        controller: 'adminMenuController'
    })
/*------------------Branch----------------------*/
    .when('/NigmaFacturation/AdminView/Branch/branchCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/Branch/branchCRUDMenu.html',
        controller: 'branchCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/Branch/readBranch', {
        templateUrl: 'HtmlPages/AdminView/Branch/readBranch.html',
        controller: 'readBranchController'
    })
    .when('/NigmaFacturation/AdminView/Branch/createBranch', {
        templateUrl: 'HtmlPages/AdminView/Branch/createBranch.html',
        controller: 'createBranchController'
    })
    .when('/NigmaFacturation/AdminView/Branch/deleteBranch', {
        templateUrl: 'HtmlPages/AdminView/Branch/deleteBranch.html',
        controller: 'deleteBranchController'
    })
    .when('/NigmaFacturation/AdminView/Branch/updateBranch', {
        templateUrl: 'HtmlPages/AdminView/Branch/updateBranch.html',
        controller: 'updateBranchController'
    })
/*------------------Employees-------------------*/
    .when('/NigmaFacturation/AdminView/employeesCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/Employees/employeesCRUDMenu.html',
        controller: 'employeesCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/Employee/readEmployee', {
    templateUrl: 'HtmlPages/AdminView/Employees/readEmployee.html',
    controller: 'readEmployeeController'
    })
    .when('/NigmaFacturation/AdminView/Employee/createEmployee', {
        templateUrl: 'HtmlPages/AdminView/Employees/createEmployee.html',
        controller: 'createEmployeeController'
    })
    .when('/NigmaFacturation/AdminView/Employee/deleteEmployee', {
        templateUrl: 'HtmlPages/AdminView/Employees/deleteEmployee.html',
        controller: 'deleteEmployeeController'
    })
    .when('/NigmaFacturation/AdminView/Employee/updateEmployee', {
        templateUrl: 'HtmlPages/AdminView/Employees/updateEmployee.html',
        controller: 'updateEmployeeController'
    })
/*------------------Products--------------------*/
    .when('/NigmaFacturation/AdminView/productsCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/productsMenu.html',
        controller: 'productsCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/Products/readProducts', {
        templateUrl: 'HtmlPages/AdminView/Products/readProducts.html',
        controller: 'readProductController'
    })
    .when('/NigmaFacturation/AdminView/Products/createProducts', {
        templateUrl: 'HtmlPages/AdminView/Products/createProducts.html',
        controller: 'createProductController'
    })
    .when('/NigmaFacturation/AdminView/Products/deleteProducts', {
        templateUrl: 'HtmlPages/AdminView/Products/deleteProducts.html',
        controller: 'deleteProductsController'
    })
    .when('/NigmaFacturation/AdminView/Products/updateProducts', {
        templateUrl: 'HtmlPages/AdminView/Products/updateProducts.html',
        controller: 'updateProductsController'
    })
/*------------------Clients---------------------*/
    .when('/NigmaFacturation/AdminView/clientsCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/clientsMenu.html',
        controller: 'clientsCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/Clients/readClients', {
        templateUrl: 'HtmlPages/AdminView/Clients/readClients.html',
        controller: 'readClientController'
    })
    .when('/NigmaFacturation/AdminView/Clients/createClients', {
        templateUrl: 'HtmlPages/AdminView/Products/createClientAdminView.html',
        controller: 'createClientController'
    })
    .when('/NigmaFacturation/AdminView/Clients/deleteClients', {
        templateUrl: 'HtmlPages/AdminView/Clients/deleteClient.html',
        controller: 'deleteClientController'
    })
    .when('/NigmaFacturation/AdminView/Clients/updateClients', {
        templateUrl: 'HtmlPages/AdminView/Clients/updateClients.html',
        controller: 'updateClientController'
    })
/*------------------Suppliers----------------------*/
    .when('/NigmaFacturation/AdminView/supplierCRUDMenu', {
        templateUrl: 'HtmlPages/AdminView/supplierMenu.html',
        controller: 'supplierCRUDMenuController'
    })
    .when('/NigmaFacturation/AdminView/Suppliers/readSuppliers', {
        templateUrl: 'HtmlPages/AdminView/Products/readProducts.html',
        controller: 'readSupplierController'
    })
    .when('/NigmaFacturation/AdminView/Suppliers/createSuppliers', {
        templateUrl: 'HtmlPages/AdminView/Suppliers/createSuppliers.html',
        controller: 'createSupplierController'
    })
    .when('/NigmaFacturation/AdminView/Suppliers/SuppliersProducts', {
        templateUrl: 'HtmlPages/AdminView/Suppliers/deleteSuppliers.html',
        controller: 'deleteSupplierController'
    })
    .when('/NigmaFacturation/AdminView/Products/updateSuppliers', {
        templateUrl: 'HtmlPages/AdminView/Suppliers/updateSuppliers.html',
        controller: 'updateSupplierController'
    })
/*------------------Reports---------------------*/
    .when('/NigmaFacturation/AdminView/reports', {
        templateUrl: 'HtmlPages/AdminView/reports.html',
    controller: 'reportsController'
    })
/*-------------------------------------Login--------------------------------------------*/

    .when('/NigmaFacturation/LoginView/signIn', {
        templateUrl: 'HtmlPages/LoginView/signIn.html',
        controller: 'signInLoginController'
    })
/*-------------------------------------Default--------------------------------------------*/
    .otherwise({
        templateUrl: 'HtmlPages/LoginView/login.html',
        controller: 'loginController'
    })
}]);

angular.module('NigmaBillingApp').config(function ($httpProvider) {
    //$httpProvider.defaults.headers.common = {};
    $httpProvider.defaults.useXDomain = true;
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/json;charset=utf-8';
    //$httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
    //$httpProvider.defaults.withCredentials = true;
    //delete $httpProvider.defaults.headers.common["X-Requested-With"];
    //$httpProvider.defaults.headers.common = {};
    //$httpProvider.defaults.headers.post = {};
    //$httpProvider.defaults.headers.put = {};
    //$httpProvider.defaults.headers.patch = {};
});
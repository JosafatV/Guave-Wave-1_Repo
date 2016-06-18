angular.module('NigmaBillingApp').controller('deleteProductController', ['$scope', '$routeParams', '$location','waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        $scope.goProductosCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
        };
        //List of the Branch
        $scope.listOfProduct = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Productos' }).$promise.then(function (data) {
            $scope.listOfProduct = data;
        });
        $scope.alerte = function (branch) {
            alert(angular.toJson(branch));
        };
        //This function sen the new branch to the database in order to be save
        $scope.sendDelete = function (prod) {
            waveWebApiResource.delete({ type: 'Productos', extension1: prod.IdProducto }).$promise.then(function () {
                //here I ask the list again to update it in the view at the same time
                waveWebApiResource.query({ type: 'Productos' }).$promise.then(function (data) {
                    $scope.listOfProduct = data;
                });
            });
        };
    }]);

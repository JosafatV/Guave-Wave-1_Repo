angular.module('NigmaBillingApp').controller('readProductController', ['$scope', '$routeParams', '$location', 'waveWebApiResource',
    function ($scope, $routeParams, $location, waveWebApiResource) {
        //List of the Branch
        $scope.listOfProducts = [];
        //This line called the API for the information
        waveWebApiResource.query({ type: 'Productos' }).$promise.then(function (data) {
            $scope.listOfProducts = data;
        });
        $scope.goProductosCRUD = function () {
            $location.path('/NigmaFacturation/AdminView/Products/productsCRUDMenu');
        };
       
    }]);

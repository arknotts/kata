//define the angular app
var kataApp = angular.module('kataApp', []);

//define a controller for the checkout process
kataApp.controller('CheckoutController', ['$scope', '$http', function ($scope, $http) { //include http service for api communication

    //declare itemsScanned in the scope. This will hold all items that have been scanned, and the quantity
    $scope.itemsScanned = [];

    //call API to get items in stock
    $http.get('/api/items').then(function (result) //TODO this URL could be generated dynamically (would help with future refactoring)
    {
        //store them in the scope
        $scope.itemsInStock = result.data;
    });

    $scope.scan = function (item)
    {
        //TODO
    };
}]);
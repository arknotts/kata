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

    //callback function to scan an item
    $scope.scan = function (scannedItem)
    {
        //will be set to true if this item has already been scanned
        var existingItemFound = false;
        angular.forEach($scope.itemsScanned, function (orderItem) {
            if (orderItem.item.Code == scannedItem.Code) //scanned item matches this item in the order
            {
                orderItem.quantity++; //increment the quanity
                existingItemFound = true; //set to true so we know a match was found
            }
        });

        if (!existingItemFound)
        {
            //push a new item on the array
            $scope.itemsScanned.push({
                item: scannedItem,
                quantity: 1
            });
        }
    };
}]);
//define the angular app
var kataApp = angular.module('kataApp', []);

//define a controller for the checkout process
kataApp.controller('CheckoutController', ['$scope', '$http', function ($scope, $http) { //include http service for api communication

    //declare itemsScanned in the scope. This will hold all items that have been scanned, and the quantity
    $scope.itemsScanned = [];

    //initialize totalPrice (so it displays something on the screen at least)
    $scope.totalPrice = 0;

    //call API to get items in stock
    $http.get('/api/items').then(function (result) //TODO this URL could be generated dynamically (would help with future refactoring)
    {
        //store them in the scope
        $scope.itemsInStock = result.data;
    });

    //callback function to scan an item
    $scope.scan = function (scannedItem)
    {
        var thisOrderItem;

        //will be set to true if this item has already been scanned
        var existingItemFound = false;
        angular.forEach($scope.itemsScanned, function (orderItem)
        {
            if (orderItem.item.Code == scannedItem.Code) //scanned item matches this item in the order
            {
                thisOrderItem = orderItem;
                thisOrderItem.quantity++; //increment the quanity
                existingItemFound = true; //set to true so we know a match was found
            }
        });

        if (!existingItemFound)
        {
            //create a new order item
            thisOrderItem = {
                item: scannedItem,
                quantity: 1
            };

            //push a new item on the array
            $scope.itemsScanned.push(thisOrderItem);
        }

        //make API call to calculate price
        $http.get('/api/items/totalitemprice?code=' + scannedItem.Code + '&quantity=' + thisOrderItem.quantity).then(function (result)
        {
            var data = result.data;

            //store data in the scope object
            thisOrderItem.totalPrice = data.TotalPrice;
            thisOrderItem.discountApplied = data.DiscountApplied;
        });

        //make API call to recalculate total price of entire order
        $http.post('/api/items/totalprice',
                    JSON.stringify($scope.itemsScanned))
        .then(function (result) {
            var data = result.data;

            $scope.totalPrice = data.TotalPrice;
        })
    };
}]);
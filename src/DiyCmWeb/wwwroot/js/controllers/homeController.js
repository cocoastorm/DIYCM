// controller for the home page
//app.controller('homeController', function ($scope, $http) {
//    $scope.message = 'Everyone come and look!';
//});

app.controller('homeController', ['$scope', '$http', 'ReportsService', function ($scope, $http, ReportsService) {

    $scope.message = 'Everyone come and look!';
    var onGetAllComplete = function (data) {
        console.log(data);
    };
    var onGetAllError = function (reason) {
        console.log(reason);
    };

    ReportsService.getAllProjectsBudgetActual()
        .then(onGetAllComplete, onGetAllError);
    ReportsService.getCategoryDetailsAndSummary()
        .then(onGetAllComplete, onGetAllError);
    ReportsService.getSubCategoryDetailsAndSummary()
        .then(onGetAllComplete, onGetAllError);
    ReportsService.getActivities()
        .then(onGetAllComplete, onGetAllError);
}]);
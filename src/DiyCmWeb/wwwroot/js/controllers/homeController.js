// controller for the home page
//app.controller('homeController', function ($scope, $http) {
//    $scope.message = 'Everyone come and look!';
//});

app.controller('homeController', ['$scope', '$http', 'ReportsService', function ($scope, $http, ReportsService) {

    $scope.message = 'Everyone come and look!';

    var onGetAllBudgetActual = function (data) {
        $scope.tableProjects = data;
        console.log(data);
    };
    var onGetAllError = function (reason) {
        console.log(reason);
    };

    ReportsService.getAllProjectsBudgetActual()
        .then(onGetAllBudgetActual, onGetAllError);
}]);
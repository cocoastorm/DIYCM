// controller for the home page
//app.controller('homeController', function ($scope, $http) {
//    $scope.message = 'Everyone come and look!';
//});

app.controller('homeController', ['$scope', '$http', 'ReportsService', function ($scope, $http, ReportsService) {

    $scope.message = 'Everyone come and look!';

    var onGetAllBudgetActual = function (data) {
        $scope.tableProjects = data;
        //console.log($scope.tableProjects);
    };
    var onGetAllCategories = function (data) {
        $scope.tableCategories = data;
        //console.log($scope.tableCategories);
    };
    var onGetAllSubCategories = function (data) {
        $scope.tableSubCategories = data;
        //console.log($scope.tableSubCategories);
    };
    var onGetAllActivities = function (data) {
        $scope.tableActivities = data;
        //console.log($scope.tableActivities);
    }
    var onGetAllError = function (reason) {
        console.log(reason);
    };

    ReportsService.getAllProjectsBudgetActual()
        .then(onGetAllBudgetActual, onGetAllError);

    ReportsService.getCategoryDetailsAndSummary()
        .then(onGetAllCategories, onGetAllError);

    ReportsService.getSubCategoryDetailsAndSummary()
        .then(onGetAllSubCategories, onGetAllError);

    ReportsService.getActivities()
        .then(onGetAllActivities, onGetAllError);
}]);
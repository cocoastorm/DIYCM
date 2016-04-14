// controller for the home page
//app.controller('homeController', function ($scope, $http) {
//    $scope.message = 'Everyone come and look!';
//});

app.controller('homeController', ['$scope', '$http', 'QuotesService', 'ReportsService', function ($scope, $http, QuotesService, ReportsService) {

    $scope.message = 'Everyone come and look!';

    var onGetAllBudgetActual = function (data) {
        $scope.tableProjects = data;
        console.log(data);
    };
    var onGetAllCategories = function (data) {
        $scope.tableCategories = data;
        console.log($scope.tableCategories);
    };
    var onGetAllSubCategories = function (data) {
        $scope.tableSubCategories = data;
        console.log($scope.tableSubCategories);
    };
    var onGetAllActivities = function (data) {
        $scope.tableActivities = data;
        console.log($scope.tableActivities);
    };
    var onGetAllError = function (reason) {
        console.log(reason);
    };

    var getProjectsOverBudget = function(data){
        //filter projects over their budget
        
        $scope.overBudgetProjects = data;
        console.log(data);
    };
    var getAllQuotes = function(quotelist){
        $scope.tableQuotes = quotelist;
        console.log("QUOTES:");
        console.log(quotelist);
    };

    ReportsService.getAllProjectsBudgetActual()
        .then(onGetAllBudgetActual, onGetAllError);
    ReportsService.getCategoryDetailsAndSummary()
       .then(onGetAllCategories, onGetAllError);
    ReportsService.getSubCategoryDetailsAndSummary()
        .then(onGetAllSubCategories, onGetAllError);
    ReportsService.getActivities()
        .then(onGetAllActivities, onGetAllError);
    ReportsService.getAllProjectsBudgetActual()
        .then(getProjectsOverBudget, onGetAllError);
    QuotesService.getAllQuoteHeaders()
        .then(getAllQuotes, onGetAllError);
}]);

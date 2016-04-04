app.controller('projectsController', ['$scope', '$http', 'ReportsService', function ($scope, $http, ReportsService) {

    $scope.message = 'Everyone come and look!';

    var onGetAllBudgetActual = function (data) {
        $scope.tableProjects = data;
        console.log(data);
    };
    var onGetAllProjects = function (data) {
        $scope.allProjects = data;
        console.log(data);
    };

    var onGetAllComplete = function (data) {
        //console.log(data);
    };
    var onGetAllError = function (reason) {
        console.log(reason);
    };

    ReportsService.getAllProjectsBudgetActual()
    .then(onGetAllBudgetActual, onGetAllError);
    ReportsService.getAllProjects()
    .then(onGetAllProjects, onGetAllError);
    //ReportsService.getAllProjectsBudgetActual()
    //    .then(onGetAllComplete, onGetAllError);
    ReportsService.getCategoryDetailsAndSummary()
        .then(onGetAllComplete, onGetAllError);
    ReportsService.getSubCategoryDetailsAndSummary()
        .then(onGetAllComplete, onGetAllError);
    ReportsService.getActivities()
        .then(onGetAllComplete, onGetAllError);
}]);
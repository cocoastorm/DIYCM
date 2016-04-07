app.controller('documentsController', ['$scope', '$http', 'ReportsService', function ($scope, $http, ReportsService) {

    $scope.message = 'Everyone come and look!';
    var onGetAllDocuments = function (data) {
        $scope.tableDocuments = data;
        console.log(data);
    };
    //var onGetAllCategories = function (data) {
    //    $scope.tableCategories = data;
    //    console.log($scope.tableCategories);
    //};
    //var onGetAllSubCategories = function (data) {
    //    $scope.tableSubCategories = data;
    //    console.log($scope.tableSubCategories);
    //};
    //var onGetAllActivities = function (data) {
    //    $scope.tableActivities = data;
    //    console.log($scope.tableActivities);
    //};
    var onGetAllError = function (reason) {
        console.log(reason);
    };

    ReportsService.getAllDocuments()
        .then(onGetAllDocuments, onGetAllError);
    //ReportsService.getCategoryDetailsAndSummary()
    //   .then(onGetAllCategories, onGetAllError);
    //ReportsService.getSubCategoryDetailsAndSummary()
    //    .then(onGetAllSubCategories, onGetAllError);
    //ReportsService.getActivities()
    //    .then(onGetAllActivities, onGetAllError);
}]);
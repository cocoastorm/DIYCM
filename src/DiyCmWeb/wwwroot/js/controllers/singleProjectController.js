app.controller('singleProjectController', ['$scope', '$http', '$routeParams', 'ProjectsService', function ($scope, $http, $routeParams, ProjectsService) {
    $scope.message = 'Everyone come and look!';

    var ProjectId = $routeParams["id"];
    var baseUrl = 'http://diycm-api.azurewebsites.net/api/';

    var onGetProject = function(data) {
        $scope.ActualFinishDate    = (data.ActualFinishDate + "").substring(0, 15);
        $scope.ActualStartDate     = (data.ActualStartDate + "").substring(0, 15);
        $scope.ProjectedStartDate  = (data.ProjectedStartDate + "").substring(0, 15);
        $scope.ProjectedFinishDate = (data.ProjectedFinishDate + "").substring(0, 15);
        $scope.project = data;
        //console.log(data);
    };

    var onGetProjectCategories = function (data) {
        $scope.Categories = data;
    };



    var onGetProjectError = function(reason) {
        //console.error(reason);
    };

    ProjectsService.getProject(ProjectId)
        .then(onGetProject, onGetProjectError);
    ProjectsService.getProjectCategories(ProjectId)
        .then(onGetProjectCategories, onGetProjectError);
}]);

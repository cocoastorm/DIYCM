(function () {
    var ProjectsService = function ($http) {
        var baseUrl = 'http://diycm-api.azurewebsites.net/api/projects/';
        var _getProject = function (id) {
            return $http.get(baseUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };
        var _getAllProjects = function () {
            return $http.get(baseUrl)
              .then(function (response) {
                  return response.data;
              });
        };
        return {
            getProject: _getProject,
            getAllProjects: _getAllProjects
        };
    };
    var module = angular.module("diycm");
    module.factory("ProjectsService", ProjectsService);
}());
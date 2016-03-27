
(function () {
    var projects = null;
    var ProjectsService = function ($http) {
        var baseUrl = 'http://localhost:49983/api/';
        var _getProject = function (id) {
            return $http.get(baseUrl + id)
             .then(function (response) {
                 return response.data;
             });
        };
        //returns project with summed budget and actual from categories api
        var _getAllProjectsBudgetActual = function () {
            return $http.get(baseUrl + 'projects').then(function (response) {
                projects = response.data;
                $http.get(baseUrl + 'categories').then(function (response) {
                    var costs = response.data;
                    projects.forEach(function(project) {
                        var sum = 0;
                        costs.forEach(function (cost) {
                            if (project.ProjectId == cost.ProjectId) {
                                sum += cost.BudgetAmount;
                            }
                        });
                        project.BudgetActual = sum;
                    }); 
                });
                return projects;
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
            getAllProjectsBudgetActual: _getAllProjectsBudgetActual,
            getAllProjects: _getAllProjects
        };
    };
    var module = angular.module("diycm");
    module.factory("ProjectsService", ProjectsService);
}());
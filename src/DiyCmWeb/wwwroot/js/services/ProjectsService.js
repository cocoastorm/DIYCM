(function() {
  var ProjectsService = function ($http, $q) {
    var baseUrl = 'http://diycm-api.azurewebsites.net/api/Projects/';
    //var baseUrl = 'http://localhost:5000/api/Projects/';


    var _getProject = function (id) {
        return $http.get(baseUrl + id)
         .then(function (response) {
             return response.data;
         });
    };

    var _addProject = function (data) {
      $.support.cors = true;
       return $http.post(baseUrl, data)
         .then(function (response) {
             return response.data;
         });
   };

   var _editProject = function (data, id) {
     $.support.cors = true;
      return $http.put(baseUrl + id, data)
        .then(function (response) {
            return response.data;
        });
  };

  var _deleteProject = function (id) {
    $.support.cors = true;
    return $http.delete(baseUrl + id)
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
      addProject: _addProject,
      editProject: _editProject,
      deleteProject: _deleteProject,
      getAllProjects: _getAllProjects
    };
  };

  var module = angular.module("diycm");
  module.factory("ProjectsService", ['$http', '$q', ProjectsService]);
}());

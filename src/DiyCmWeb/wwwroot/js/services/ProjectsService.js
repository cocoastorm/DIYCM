(function() {
  var ProjectsService = function ($http, $q) {
    var baseUrl = 'http://diycm-api.azurewebsites.net/api/Projects/';
    var url = 'http://diycm-api.azurewebsites.net/api/';
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

    var _ongetProjectCategories = function(id){
          var reqCategories = $http.get(url + 'categories');
          var reqProjects = $http.get(url + 'projects/' + id);
          var arr = new Array();
          console.log(id);
          return $q.all([reqCategories, reqProjects]).then(function (values) {
              var categories = values[0].data;
              var project = values[1].data;
              categories.forEach(function (category) {
              console.log(category.ProjectId)
                      if (id == category.ProjectId) {
                        var obj = {
                          CategoryId      : category.CategoryId,
                          CategoryName    : category.CategoryName,
                          Description     : category.CategoryId,
                          BudgetAmount    : category.BudgetAmount,
                          ActualAmount    : category.ActualAmount,
                          PercentCompleted: category.PercentCompleted,
                          VarianceAmount  : category.VarianceAmount
                        };
                        arr.push(obj);
                      }
              });
              return arr;
          });
    }

    return {
      getProject: _getProject,
      addProject: _addProject,
      editProject: _editProject,
      deleteProject: _deleteProject,
      getAllProjects: _getAllProjects,
      getProjectCategories: _ongetProjectCategories
    };
  };

  var module = angular.module("diycm");
  module.factory("ProjectsService", ['$http', '$q', ProjectsService]);
}());
